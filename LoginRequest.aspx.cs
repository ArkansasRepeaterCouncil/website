using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


public partial class LoginRequest : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void sendNewAccountRequest()
	{
		if (IsValid)
		{
			try
			{
				using (var webClient = new System.Net.WebClient())
				{
					string parameters = string.Format("callsign={0}&email={1}&fullname={2}&address={3}&city={4}&state={5}&zip={6}", txtCallsign.Text, txtEmail.Text, hdnName.Value, hdnAddress.Value, hdnCity.Value, hdnState.Value, hdnZip.Value);
					string strUrl = string.Format("{0}{1}{2}", System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"], "CreateNewUser?", parameters);
					string json = webClient.DownloadString(strUrl);
					dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
				}

				lblDirections.Text = "A new password has been created and queued to send to the email address we have on file. It may take up to 15 minutes before you receive it.";
			}
			catch (Exception ex)
			{
				new ExceptionReport(ex);
				lblDirections.Text = "An error occurred while processing your reset request.  We have logged this error.  In the meantime you are welcome to browse to the home page, then back here to try again.";
			}
			btnSubmit.Visible = false;
			txtCallsign.Visible = false;
			txtEmail.Visible = false;
			Label1.Visible = false;
			Label2.Visible = false;
		}
	}

	protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
	{
		// Look up the call sign and make sure it is a valid license
		string response = Utilities.GetResponseFromUrl("https://callook.info/" + txtCallsign.Text + "/json");

		try
		{
			dynamic data = JsonConvert.DeserializeObject(response);
			if (data.status == "VALID")
			{
				args.IsValid = true;
				hdnAddress.Value = data.address.line1;
				hdnName.Value = data.name;

				// Parse line2 to get other address values
				string address2 = data.address.line2;
				string[] arrAddress = address2.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries) ;
				hdnCity.Value = arrAddress[0];
				hdnState.Value = arrAddress[1];
				hdnZip.Value = arrAddress[2];
			}
			else
			{
				args.IsValid = false;
			}
		}
		catch (Exception ex)
		{
			args.IsValid = false;

			new ExceptionReport(ex);
		}
	}



	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		sendNewAccountRequest();
	}
}