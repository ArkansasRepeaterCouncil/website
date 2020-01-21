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
            CoordinationRequestInterstate req = new CoordinationRequestInterstate(txtLatitude.Text, txtLongitude.Text, txtTransmitFrequency.Text, txtReceiveFrequency.Text, creds);
            CoordinationRequestInterstateAnswer answer = req.Save();

            Panel1.Visible = false;
            Panel2.Visible = true;
            lblAnswer.Text = string.Format("Your request to coordinate a repeater at {0}, {1} transmitting on {2} and receiving on {3} is {4}. {5}", txtLatitude.Text, txtLongitude.Text, answer.TransmitFrequency.ToString(), answer.ReceiveFrequency.ToString(), answer.Answer, answer.Comment);
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

	protected void btnSubmit_Click(object sender, EventArgs e)
	{

	}
}