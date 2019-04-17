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
				if (obj.ID == -1)
				{
					TabPanel2.Visible = true;
				}
				else
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

	protected void btnRunReportExpiredRepeaters_Click(object sender, EventArgs e)
	{
		System.Web.UI.ControlCollection pnl = pnlRunReportExpiredRepeaters.Controls;
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ReportExpiredRepeaters?callsign={0}&password={1}", creds.Username, creds.Password);
			string json = webClient.DownloadString(url);

			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			Table table = new Table();

			foreach (dynamic item in data.Report.Data)
			{
				dynamic repeater = item.Repeater;

				using (TableRow row = new TableRow())
				{
					row.AddCell((string)repeater.YearsExpired);
					row.AddCell((string)repeater.ID);
					row.AddCell((string)repeater.Callsign);
					row.AddCell((string)repeater.Output);
					row.AddCell((string)repeater.City);
					row.AddCell((string)repeater.Sponsor);
					row.AddCell((string)repeater.Trustee.Name);
					row.AddCell((string)repeater.Trustee.Email);
					row.AddCell((string)repeater.Trustee.CellPhone);
					row.AddCell((string)repeater.Trustee.HomePhone);
					row.AddCell((string)repeater.Trustee.WorkPhone);
					table.Rows.Add(row);
				}

				using (TableRow row = new TableRow())
				{
					string strNotes = "";
					if (repeater.Notes != null)
					{
						strNotes = "<ul>";
						foreach (dynamic obj in repeater.Notes)
						{
							strNotes += "<li>" + obj.Note.Text + " -" + obj.Note.User.Name + ", " + obj.Note.User.Callsign + " (" + obj.Note.Timestamp + ")</li>";
						}
						strNotes += "</ul>";
					}
					row.AddCell(strNotes, 11);
					table.Rows.Add(row);
				}

				using (TableRow row = new TableRow())
				{
					TextBox textbox = new TextBox();
					textbox.ID = repeater.ID;
					Button button = new Button();
					button.CommandArgument = repeater.ID;
					button.Text = "Save";

					TableCell cell = new TableCell();
					cell.Controls.Add(textbox);
					cell.Controls.Add(button);
					cell.ColumnSpan = 11;
					row.Cells.Add(cell);
					
					table.Rows.Add(row);
				}
			}
			pnlRunReportExpiredRepeaters.Controls.Add(table);
		}
	}



	protected void btnRunReportOpenRequests_Click(object sender, EventArgs e)
	{

	}
}