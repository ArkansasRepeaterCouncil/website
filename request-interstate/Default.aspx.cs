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
            string latitude = txtLatitude.Text;
            string longitude = txtLongitude.Text;

            if (rbCoordinates.SelectedValue == "Degrees, minutes, seconds")
            {
                latitude = ConvertDmsToDecimal(txtLatitudeDeg.Text, txtLatitudeMin.Text, txtLatitudeSec.Text).ToString();
                longitude = ConvertDmsToDecimal(txtLongitudeDeg.Text, txtLongitudeMin.Text, txtLongitudeSec.Text).ToString();
            }

            CoordinationRequestInterstate req = new CoordinationRequestInterstate(latitude, longitude, txtTransmitFrequency.Text, txtReceiveFrequency.Text, creds);
            CoordinationRequestInterstateAnswer answer = req.Save();

            Panel1.Visible = false;
            Panel2.Visible = true;
            lblAnswer.Text = string.Format("Your request to coordinate a repeater at {0}, {1} transmitting on {2} and receiving on {3} is {4}. {5}", latitude, longitude, answer.TransmitFrequency.ToString(), answer.ReceiveFrequency.ToString(), answer.Answer.ToUpper(), answer.Comment);
		}
	}

    private double ConvertDmsToDecimal(string Deg, string Min, string Sec)
    {
        int deg; int min; double sec; double dec = 0;
        if ((double.TryParse(Sec, out sec)) && (int.TryParse(Min, out min)) && (int.TryParse(Deg, out deg)))
        {
            dec = deg + (min / 60) + (sec / 3600);
        }
        else
        {
            dec = 0.0;
        }
        return dec;
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
        
        CustomValidator v = (CustomValidator)source;
        if (v.ID == "validatorLatitudeDms")
        {
            if (ConvertDmsToDecimal(txtLatitudeDeg.Text, txtLatitudeMin.Text, txtLatitudeSec.Text) == 0.0)
            {
                validatorLatitudeDms.ErrorMessage = "The latitude you provided is invalid.";
            }
            else
            {
                args.IsValid = true;
            }
        }
        else
        {
            double decLat = double.Parse(txtLatitude.Text);
            if ((25.001 < decLat) && (decLat < 48.001))
            {
                args.IsValid = true;
            }
        }
	}

	protected void validatorLongitude_ServerValidate(object source, ServerValidateEventArgs args)
	{
        args.IsValid = false;
        CustomValidator v = (CustomValidator)source;
        if (v.ID == "validatorLongitudeDms")
        {
            if (ConvertDmsToDecimal(txtLongitudeDeg.Text, txtLongitudeMin.Text, txtLongitudeSec.Text) == 0.0)
            {
                validatorLongitudeDms.ErrorMessage = "The longitude you provided is invalid.";
            }
            else
            {
                args.IsValid = true;
            }
        }
        else
        {
            double decLon = double.Parse(txtLongitude.Text);
            if ((-130.653571 < decLon) && (decLon < -71.056832))
            {
                args.IsValid = true;
            }
        }
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
        SubmitRequest();
	}

    protected void rbCoordinates_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool dms = (rbCoordinates.SelectedValue == "Degrees, minutes, seconds");

        RequiredFieldValidator3.Enabled = !dms;
        validatorLatitude.Enabled = !dms;
        validatorLongitude.Enabled = !dms;
        pnlCoordDec.Visible = !dms;

        validatorLatitudeDms.Enabled = dms;
        validatorLongitudeDms.Enabled = dms;
        pnlCoordDms.Visible = dms;
    }
}