using Newtonsoft.Json;
using System;
using System.Web.UI.WebControls;

public partial class dashboard_Default : System.Web.UI.Page
{
	Credentials creds;

	protected void Page_Load(object sender, EventArgs e)
	{
		creds = Utilities.GetExistingCredentials();
		LoadUsersRepeaters();
		LoadUsersCoordinationRequests();
	}

	private void LoadUsersRepeaters()
	{
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetUsersRepeaters?callsign={0}&password={1}", creds.Username, creds.Password);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			string[] fields = { "Callsign", "OutputFrequency", "City", "Status", "DateUpdated" };

			foreach (dynamic obj in data)
			{
				TableRow row = new TableRow();
				TableCell cell = new TableCell();
				Button btn = new Button();
				btn.Text = "Update";
				btn.CausesValidation = false;
				btn.CommandArgument = obj.ID;
				btn.CommandName = "getRepeater";
				btn.Click += Button_Click;
				cell.Controls.Add(btn);
				row.Cells.Add(cell);

				for (int i = 0; i < fields.Length; i++)
				{
					cell = new TableCell();
					cell.Text = obj[fields[i]];
					row.Cells.Add(cell);
				}

				RepeatersTable.Rows.Add(row);
			}
		}
	}

	private void LoadUsersCoordinationRequests()
	{
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetUsersCoordinationRequests?callsign={0}&password={1}", creds.Username, creds.Password);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			string[] fields = { "ID", "OutputFrequency", "Description", "LastUpdated" };

			foreach (dynamic obj in data)
			{
				TableRow row = new TableRow();
				TableCell cell = new TableCell();
				Button btn = new Button();
				btn.Text = "Details";
				btn.CausesValidation = false;
				btn.CommandArgument = obj.ID;
				btn.CommandName = "getRequest";
				btn.Click += Button_Click;
				cell.Controls.Add(btn);
				row.Cells.Add(cell);

				for (int i = 0; i < fields.Length; i++)
				{
					cell = new TableCell();
					cell.Text = obj[fields[i]];
					row.Cells.Add(cell);
				}

				tblRequests.Rows.Add(row);
				pnlRequests.Visible = true;
			}
		}
	} 

	private void Button_Click(object sender, EventArgs e)
	{
		Button btn = (Button)sender;
		switch (btn.CommandName)
		{
			case "getRepeater":
				Response.Redirect(string.Format("~/update/?id={0}", btn.CommandArgument.ToString()));
				break;
			case "getRequest":
				Response.Redirect(string.Format("~/request/details/?id={0}", btn.CommandArgument.ToString()));
				break;
		}

		
	}
}