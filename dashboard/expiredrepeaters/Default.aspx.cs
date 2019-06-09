using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dashboard_expiredrepeaters_Default : System.Web.UI.Page
{
	Credentials creds;

	protected void Page_Load(object sender, EventArgs e)
	{
		creds = Utilities.GetExistingCredentials();
		loadExpiredRepeatersReport();
	}

	protected void loadExpiredRepeatersReport()
	{
		System.Web.UI.ControlCollection pnl = pnlExpiredRepeaters.ContentTemplateContainer.Controls;
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
		pnlExpiredRepeaters.ContentTemplateContainer.Controls.Add(table);

	}

	private void Button_Click(object sender, EventArgs e)
	{
		Button btn = (Button)sender;
		switch (btn.CommandName)
		{
			case "getRequest":
				Response.Redirect(string.Format("~/request/details/?id={0}", btn.CommandArgument.ToString()));
				break;
			case "saveNote":
				string repeaterId = ((Button)sender).CommandArgument;
				TextBox tb = (TextBox)pnlExpiredRepeaters.ContentTemplateContainer.FindControl("txt" + repeaterId);
				string note = tb.Text;
				using (var webClient = new System.Net.WebClient())
				{
					string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "AddRepeaterNote?callsign={0}&password={1}&repeaterid={2}&note={3}", creds.Username, creds.Password, repeaterId, note);
					string json = webClient.DownloadString(url);
				}
				ViewState["expiredRepeatersReport"] = null;
				break;
		}
	}
}