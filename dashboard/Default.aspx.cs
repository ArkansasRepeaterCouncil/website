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
			bool showAdminTools = false;

			foreach (dynamic obj in data)
			{
				if (obj.ID < 0)
				{
					showAdminTools = true;
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

			if (showAdminTools)
			{
				pnlAdminTools.Visible = true;
				loadExpiredRepeatersReport();
				loadOpenRequestsReport();
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
			case "saveNote":
				string repeaterId = ((Button)sender).CommandArgument;
				TextBox tb = (TextBox)pnlExpiredRepeaters.FindControl("txt" + repeaterId);
				string note = tb.Text;
				using (var webClient = new System.Net.WebClient())
				{
					string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "AddRepeaterNote?callsign={0}&password={1}&repeaterid={2}&note={3}", creds.Username, creds.Password, repeaterId, note);
					string json = webClient.DownloadString(url);
				}
				ViewState["expiredRepeatersReport"] = null;
				Response.Redirect("~/dashboard/?t=1");
				break;
		}
	}

	protected void loadExpiredRepeatersReport()
	{
		System.Web.UI.ControlCollection pnl = pnlExpiredRepeaters.Controls;
		string json = "";

		if (ViewState["expiredRepeatersReport"] == null)
		{
			using (var webClient = new System.Net.WebClient())
			{
				string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ReportExpiredRepeaters?callsign={0}&password={1}", creds.Username, creds.Password);
				json = webClient.DownloadString(url);
				ViewState["expiredRepeatersReport"] = json;
			}
		}
		else
		{
			json = ViewState["expiredRepeatersReport"].ToString();
		}

		dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

		Table table = new Table();
		if (data.Report != null)
		{
			foreach (dynamic item in data.Report.Data)
			{
				dynamic repeater = item.Repeater;

				using (TableRow headerRow = new TableRow())
				{
					headerRow.AddCell("Expired");
					headerRow.AddCell("ID");
					headerRow.AddCell("Callsign");
					headerRow.AddCell("Xmit freq");
					headerRow.AddCell("City");
					headerRow.AddCell("Sponsor");
					headerRow.AddCell("Trustee");
					headerRow.AddCell("Contact info");
					headerRow.CssClass = "expiredRepeaterHeader";
					table.Rows.Add(headerRow);
				}

				using (TableRow row = new TableRow())
				{
					row.AddCell((string)repeater.YearsExpired + " years");
					row.AddCell(string.Format("<a target='_blank' href='/update/?id={0}'>{0}</a>", (string)repeater.ID));
					row.AddCell(string.Format("<a target='_blank' href='https://qrz.com/db/{0}'>{0}</a>", (string)repeater.Callsign));
					row.AddCell((string)repeater.Output);
					row.AddCell((string)repeater.City);
					row.AddCell((string)repeater.Sponsor);
					row.AddCell(string.Format("<a target='_blank' href='https://qrz.com/db/{0}'>{1}</a>", (string)repeater.Trustee.Callsign, (string)repeater.Trustee.Name));

					string strContact = string.Empty;
					if ((string)repeater.Trustee.Email != string.Empty)
					{
						if (strContact != string.Empty) { strContact += ", "; }
						strContact += "<a href='mailto:" + (string)repeater.Trustee.Email + "'>" + (string)repeater.Trustee.Email + "</a> ";
					}
					if ((string)repeater.Trustee.CellPhone != string.Empty)
					{
						if (strContact != string.Empty) { strContact += ", "; }
						strContact += (string)repeater.Trustee.CellPhone + " (cell)";
					}
					if ((string)repeater.Trustee.HomePhone != string.Empty)
					{
						if (strContact != string.Empty) { strContact += ", "; }
						strContact += (string)repeater.Trustee.HomePhone + " (home)";
					}
					if ((string)repeater.Trustee.WorkPhone != string.Empty)
					{
						if (strContact != string.Empty) { strContact += ", "; }
						strContact += (string)repeater.Trustee.WorkPhone + " (work)";
					}
					row.AddCell(strContact);
					row.CssClass = "expiredRepeaterData";
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
							strNotes += string.Format("<li>{0} - {1} ({2}, {3})</li>", obj.Note.Timestamp, obj.Note.Text, obj.Note.User.Name, obj.Note.User.Callsign);
						}
						strNotes += "</ul>";
					}
					else
					{
						strNotes = "<ul><li><em>There are no notes on record for this repeater.</em></li></ul>";
					}
					row.AddCell(strNotes, 8);
					row.CssClass = "expiredRepeaterNotes";
					table.Rows.Add(row);
				}

				using (TableRow row = new TableRow())
				{
					Label label = new Label();
					label.Text = "Note: ";
					TextBox textbox = new TextBox();
					textbox.ID = "txt" + repeater.ID;
					textbox.CssClass = "expiredRepeaterNote";
					Button button = new Button();
					button.CommandArgument = repeater.ID;
					button.CommandName = "saveNote";
					button.Click += Button_Click;
					button.Text = "Save";

					TableCell cell = new TableCell();
					cell.Controls.Add(label);
					cell.Controls.Add(textbox);
					cell.Controls.Add(button);
					cell.ColumnSpan = 8;
					row.Cells.Add(cell);
					row.CssClass = "expiredRepeaterNewNote";
					table.Rows.Add(row);
				}
			}
		}
		pnlExpiredRepeaters.Controls.Add(table);

	}

	protected void loadOpenRequestsReport()
	{
		System.Web.UI.ControlCollection pnl = pnlExpiredRepeaters.Controls;
		string json = "";

		if (ViewState["ReportOpenCoordinationRequests"] == null)
		{
			using (var webClient = new System.Net.WebClient())
			{
				string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ReportOpenCoordinationRequests?callsign={0}&password={1}", creds.Username, creds.Password);
				json = webClient.DownloadString(url);
				ViewState["ReportOpenCoordinationRequests"] = json;
			}
		}
		else
		{
			json = ViewState["ReportOpenCoordinationRequests"].ToString();
		}

		dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

		Table table = new Table();
		if ((data.Report != null) && (data.Report.Data != null))
		{
			foreach (dynamic item in data.Report.Data)
			{
				dynamic request = item.Request;

				using (TableRow headerRow = new TableRow())
				{
					headerRow.AddCell("ID", "requestHeader");
					headerRow.AddCell("Requested on");
					headerRow.AddCell("Requested by");
					headerRow.AddCell("Latitude");
					headerRow.AddCell("Longitude");
					headerRow.AddCell("Transmit frequency");
					headerRow.CssClass = "requestHeader";
					table.Rows.Add(headerRow);
				}

				using (TableRow row = new TableRow())
				{
					row.AddCell((string)request.ID);
					row.AddCell((string)request.RequestedDate);
					row.AddCell((string)request.RequestedBy);
					row.AddCell((string)request.Latitude);
					row.AddCell((string)request.Longitude);
					row.AddCell((string)request.OutputFrequency);
					row.CssClass = "requestDetails";
					table.Rows.Add(row);
				}

				using (TableRow row = new TableRow())
				{
					row.AddCell("Workflows", 6);
					row.CssClass = "workflowDivider";
					table.Rows.Add(row);
				}

				using (TableRow headerRow = new TableRow())
				{
					headerRow.AddCell("&nbsp;");
					headerRow.AddCell("State");
					headerRow.AddCell("Status");
					headerRow.AddCell("Time stamp");
					headerRow.AddCell("Last reminder");
					headerRow.AddCell("Note");
					headerRow.CssClass = "workflowHeader";
					table.Rows.Add(headerRow);
				}

				foreach (dynamic thing in request.Workflows)
				{
					dynamic workflow = thing.Workflow;
					using (TableRow row = new TableRow())
					{
						row.AddCell((string)"&nbsp;");
						row.AddCell((string)workflow.State);
						row.AddCell((string)workflow.Status);
						row.AddCell((string)workflow.TimeStamp);
						row.AddCell((string)workflow.LastReminderSent);
						row.AddCell((string)workflow.Note);
						row.CssClass = "workflowDetails";
						table.Rows.Add(row);
					}
				}
			}
			pnlOpenRequests.Controls.Add(table);
		}
	}
}