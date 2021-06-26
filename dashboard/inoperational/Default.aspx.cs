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

		if (Request.QueryString["s"] != null)
		{
			// Define the name and type of the client scripts on the page.
			String csName = "onloadScrollTo";
			Type csType = this.GetType();

			// Get a ClientScriptManager reference from the Page class.
			ClientScriptManager cs = Page.ClientScript;

			// Check to see if the startup script is already registered.
			if (!cs.IsStartupScriptRegistered(csType, csName))
			{
				cs.RegisterStartupScript(csType, csName, string.Format("$(function() {0} $('html').animate({0} scrollTop: {2} {1}, 0);{1});", "{", "}", Request.QueryString["s"].ToString()), true);
			}
		}
	}

	protected void loadExpiredRepeatersReport()
	{
		System.Web.UI.ControlCollection pnl = pnlExpiredRepeaters.Controls;
		string json = "";

		if (ViewState["expiredRepeaters"] == null)
		{
			using (var webClient = new System.Net.WebClient())
			{
				string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ReportInoperationalRepeaters?callsign={0}&password={1}", creds.Username, creds.Password);
				json = webClient.DownloadString(url);
				ViewState["expiredRepeaters"] = json;
			}
		}
		else
		{
			json = ViewState["expiredRepeaters"].ToString();
		}

		dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
		lblTitle.Text = data.Report.Title;
		lblTitle2.Text = data.Report.Title;

		Table table = new Table();
		if (data.Report != null)
		{
			foreach (dynamic item in data.Report.Data)
			{
				dynamic repeater = item.Repeater;

				using (TableRow headerRow = new TableRow())
				{
					headerRow.AddCell("Status");
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
					row.AddCell((string)repeater.Status);
					row.AddCell(string.Format("<a target='_blank' href='/update/?id={0}'>{0}</a>", (string)repeater.ID));
					row.AddCell(string.Format("<a target='_blank' href='https://qrz.com/db/{0}'>{0}</a>", (string)repeater.Callsign));
					row.AddCell((string)repeater.Output);
					row.AddCell(string.Format("<a target='_blank' href='https://www.google.com/maps/search/?api=1&query={1},{2}'>{0}</a>", (string)repeater.City, (string)repeater.Latitude, (string)repeater.Longitude));
					row.AddCell((string)repeater.Sponsor);
					row.AddCell(string.Format("<a target='_blank' href='https://qrz.com/db/{0}'>{1}</a>", (string)repeater.Trustee.Callsign, (string)repeater.Trustee.Name));

					string strContact = string.Empty;
					if ((string)repeater.Trustee.Email != string.Empty)
					{
						if (strContact != string.Empty) { strContact += ", "; }
						strContact += "<a href='mailto:" + (string)repeater.Trustee.Email + "'>" + (string)repeater.Trustee.Email + "</a> ";
					}

                    string strPhone = string.Empty;
					if ((string)repeater.Trustee.CellPhone != string.Empty)
					{
						if (strContact != string.Empty) { strContact += ", "; }
                        strPhone = (string)repeater.Trustee.CellPhone;
                        strContact += "<a href='tel:" + strPhone + "'>" + strPhone + "</a> (cell)";
					}
					if ((string)repeater.Trustee.HomePhone != string.Empty)
					{
						if (strContact != string.Empty) { strContact += ", "; }
                        strPhone = (string)repeater.Trustee.HomePhone;
                        strContact += "<a href='tel:" + strPhone + "'>" + strPhone + "</a> (home)";
					}
					if ((string)repeater.Trustee.WorkPhone != string.Empty)
					{
						if (strContact != string.Empty) { strContact += ", "; }
                        strPhone = (string)repeater.Trustee.WorkPhone;
                        strContact += "<a href='tel:" + strPhone + "'>" + strPhone + "</a> (work)";
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
							string note = ((string)obj.Note.Text).Replace("â€¢", "<br>&bull;");
							strNotes += string.Format("<li>{0} - {1} ({2}, {3})</li>", obj.Note.Timestamp, note, obj.Note.User.Name, obj.Note.User.Callsign);
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

	private void Button_Click(object sender, EventArgs e)
	{
		Button btn = (Button)sender;
		switch (btn.CommandName)
		{
			case "saveNote":
				string repeaterId = ((Button)sender).CommandArgument;
				TextBox tb = (TextBox)pnlExpiredRepeaters.FindControl("txt" + repeaterId);
				string note = tb.Text;
				using (var webClient = new System.Net.WebClient())
				{
					string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "AddRepeaterNote?callsign={0}&password={1}&repeaterid={2}&note={3}", creds.Username, creds.Password, repeaterId, note);
					string json = webClient.DownloadString(url);
				}
				ViewState["expiredRepeaters"] = null;
				Response.Redirect(string.Format("{0}?s={1}", Request.Url.AbsolutePath, scrollPosition.Value));
				break;
		}
	}
}