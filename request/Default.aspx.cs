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

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		decimal decAltitude = GetAltitude(txtLatitude.Text, txtLongitude.Text);
		string strAltitude = Math.Round(decAltitude).ToString();

		new CoordinationRequest(txtLatitude.Text, txtLongitude.Text, txtOutputPower.Text, strAltitude, txtAntennaHeight.Text, txtFrequency.Text, creds).Save();
		Response.Redirect("~/Dashboard/");
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
}