using Newtonsoft.Json;
using System;
using System.Web.UI.WebControls;

public partial class dashboard_Default : System.Web.UI.Page
{
	Credentials creds;

	protected void Page_Init(object sender, EventArgs e)
	{
		creds = Utilities.GetExistingCredentials();
		LoadUsersRepeaters();
		LoadUsersCoordinationRequests();
	}

	protected void Page_Load(object sender, EventArgs e)
	{

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
				if (obj.ID < 0)
				{
					pnlAdminTools.Visible = true;
					if (!Page.IsPostBack)
					{
						loadExpiredRepeatersReport();
					}
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

	protected void loadExpiredRepeatersReport()
	{
		System.Web.UI.ControlCollection pnl = pnlExpiredRepeaters.Controls;
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ReportExpiredRepeaters?callsign={0}&password={1}", creds.Username, creds.Password);
			string json = webClient.DownloadString(url);

			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			Table table = new Table();

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
					table.Rows.Add(headerRow);
				}

				using (TableRow row = new TableRow())
				{
					row.AddCell((string)repeater.YearsExpired + " years");
					row.AddCell((string)repeater.ID);
					row.AddCell((string)repeater.Callsign);
					row.AddCell((string)repeater.Output);
					row.AddCell((string)repeater.City);
					row.AddCell((string)repeater.Sponsor);
					row.AddCell((string)repeater.Trustee.Name);

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
					else
					{
						strNotes = "<ul><li><em>There are no notes on record for this repeater.</em></li></ul>";
					}
					row.AddCell(strNotes, 8);
					table.Rows.Add(row);
				}

				using (TableRow row = new TableRow())
				{
					Label label = new Label();
					label.Text = "Note: ";
					TextBox textbox = new TextBox();
					textbox.ID = "txt" + repeater.ID;
					Button button = new Button();
					button.CommandArgument = repeater.ID;
					button.Click += SaveNoteButton_Click;
					button.Text = "Save";

					TableCell cell = new TableCell();
					cell.Controls.Add(label);
					cell.Controls.Add(textbox);
					cell.Controls.Add(button);
					cell.ColumnSpan = 8;
					row.Cells.Add(cell);

					table.Rows.Add(row);
				}
			}
			pnlExpiredRepeaters.Controls.Add(table);
		}
	}

	private void SaveNoteButton_Click(object sender, EventArgs e)
	{
		string repeaterId = ((Button)sender).CommandArgument;
		TextBox tb = (TextBox)pnlExpiredRepeaters.FindControl("txt" + repeaterId);
		string note = tb.Text;

		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "AddRepeaterNote?callsign={0}&password={1}&repeaterid={2}&note={3}", creds.Username, creds.Password, repeaterId, note);
			string json = webClient.DownloadString(url);
		}

		loadExpiredRepeatersReport();
	}
}