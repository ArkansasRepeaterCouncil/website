using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class request_Default : System.Web.UI.Page
{
	Credentials creds;
	protected void Page_Load(object sender, EventArgs e)
	{
		creds = Utilities.GetExistingCredentials();
		ARC.User user = ARC.User.Load(creds);

		if (!Page.IsPostBack)
		{
			txtPersonCallsign.Text = user.Callsign;
			txtEmail.Text = user.Email;
			txtPersonName.Text = user.FullName;
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/Dashboard/");
	}

	private void SubmitRequest()
	{
		if (Page.IsValid)
		{
			decimal decAltitude = GetAltitude(txtLatitude.Text, txtLongitude.Text);
			string strAltitude = Math.Round(decAltitude).ToString();

			new CoordinationRequest(txtLatitude.Text, txtLongitude.Text, txtOutputPower.Text, strAltitude, txtAntennaHeight.Text, ddlFrequency.SelectedValue, creds).Save();
			Response.Redirect("~/Dashboard/");
		}
	}

	private decimal GetAltitude(string latitude, string longitude)
	{
		decimal output = 0M;
		string apiKey = System.Configuration.ConfigurationManager.AppSettings["googleMapApiKey"];
		string url = String.Format("https://maps.googleapis.com/maps/api/elevation/json?key={0}&locations={1},{2}", apiKey, latitude, longitude);

		try
		{
			using (var webClient = new System.Net.WebClient())
			{
				string json = webClient.DownloadString(url);
				dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

				decimal.TryParse(data.results[0].elevation.ToString(), out output);
			}
		}
		catch (Exception)
		{

		}


		return output;
	}

	protected void doNext()
	{
		if (Page.IsValid)
		{
			LoadAvailableFrequencies(txtLatitude.Text, txtLongitude.Text, ddlBand.SelectedValue);
		}
	}

	private void LoadAvailableFrequencies(string latitude, string longitude, string band)
	{
		using (var webClient = new System.Net.WebClient())
		{
			try
			{
				string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ListUnusedFrequenciesNearPoint?lat={0}&lon={1}&miles={2}&band={3}", latitude, longitude, "90", band);
				string json = webClient.DownloadString(url);
				dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

				try
				{
					ddlFrequency.Items.Clear();

					if (data != null)
					{
						foreach (dynamic obj in data)
						{
							if ((obj != null) && (obj.outputFreq != null) && (obj.inputFreq != null))
							{
								ListItem li = new ListItem(string.Format("Tx {0}, Rx {1}", obj.outputFreq.ToString(), obj.inputFreq.ToString()), obj.outputFreq.ToString());
								ddlFrequency.Items.Add(li);
							}
						}
					}

					ddlBand.Enabled = false;
					bttnNext.Visible = false;
					txtLatitude.ReadOnly = true;

					ddlFrequency.SelectedIndex = 0;
					ddlFrequency.Visible = true;
					lblFrequency.Visible = true;
					btnSubmit.Visible = true;
				}
				catch (Exception ex2)
				{
					new ExceptionReport(ex2, "Unable to iterate frequencies for coordination request.", null);
				}
			}
			catch (Exception ex)
			{
				new ExceptionReport(ex, "Unable to load frequencies for coordination request", null);
			}
		}
	}





	protected void validatorLatitude_ServerValidate(object source, ServerValidateEventArgs args)
	{
		args.IsValid = false;
		double decLat = double.Parse(txtLatitude.Text);
		if ((25.001 < decLat) && (decLat < 48.001))
		{
			args.IsValid = true;
		}
	}

	protected void validatorLongitude_ServerValidate(object source, ServerValidateEventArgs args)
	{
		args.IsValid = false;
		double decLon = double.Parse(txtLongitude.Text);
		if ((-130.653571 < decLon) && (decLon < -71.056832))
		{
			args.IsValid = true;
		}
	}

	protected void bttnNext_Click(object sender, EventArgs e)
	{
		doNext();
	}



	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		SubmitRequest();
	}
}