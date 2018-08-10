using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class update_Default : System.Web.UI.Page
{
	Credentials creds;

	protected void Page_Load(object sender, EventArgs e)
	{
		creds = Utilities.GetExistingCredentials();

		LoadRepeaterDetails();
	}

	private void LoadRepeaterDetails()
	{
		string repeaterId = "0";
		try
		{
			repeaterId = Request.QueryString["id"].ToString();
		}
		catch (Exception)
		{
			
		}
		

		// Call web service to get all data for the repeater with this ID
		dynamic repeaterData;
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetRepeaterDetails?callsign={0}&password={1}&repeaterid={2}", creds.Username, creds.Password, repeaterId);
			string json = webClient.DownloadString(url);
			repeaterData = JsonConvert.DeserializeObject<dynamic>(json);
		}

		//// Load data into new controls
		lblRepeaterName.Text = repeaterData[0].Callsign.Value + " (" + repeaterData[0].OutputFrequency.Value + ")";

		foreach (dynamic property in repeaterData[0])
		{
			RepeaterProperty rp = new RepeaterProperty(property);
			
			switch (rp.Type)
			{
				case "Boolean":
					CheckBox cb = new CheckBox();
					cb.Text = rp.FriendlyName;
					cb.ID = rp.Name;
					cb.Checked = rp.Value;
					cb.Enabled = !rp.ReadOnly;
					formPanel.Controls.Add(cb);
					break;
				default:
					Label lbl = new Label();
					lbl.Text = rp.FriendlyName;
					lbl.Width = 400;
					lbl.CssClass = "formLabel";
					formPanel.Controls.Add(lbl);

					TextBox tb = new TextBox();
					tb.Text = rp.Value;
					tb.ID = rp.Name;
					tb.Enabled = !rp.ReadOnly;
					formPanel.Controls.Add(tb);
					break;
			}
			Label newline = new Label();
			newline.Text = "<br>";
			formPanel.Controls.Add(newline);
		}
	}
}