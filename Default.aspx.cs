using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string urlKey = Request.QueryString["nopc"];
		if ((urlKey != null) && (urlKey != ""))
		{
			Response.Redirect("~/nopc/?nopc=" + urlKey);
		}

		string fbclid = Request.QueryString["fbclid"];
		if ((fbclid != null) && (fbclid != ""))
		{
			Response.Redirect("~/");
		}

		string json = Utilities.GetResponseFromUrl(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetRepeaterUpdateNumbers");
		dynamic stats = JsonConvert.DeserializeObject<dynamic>(json);

		lblCount.Text = stats.TotalRepeaters;
		hdnCountCurrent.Value = stats.RepeatersCurrent;
		hdnCountExpired.Value = stats.RepeatersExpired;
		lblCoordinationCount.Text = stats.TotalCoordinationRequests;
		lblAverageDaysPerCoordination.Text = stats.AverageDays;

		json = Utilities.GetResponseFromUrl(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ListRecentChangesPublic");
		dynamic changes = JsonConvert.DeserializeObject<dynamic>(json);

		lblRecentChanges.Text = "<h3>Recent updates</h3><ul>";

		foreach (dynamic change in changes)
		{
			string desc = change.ChangeDescription;
			desc = "<ul>" + desc.Replace("• ", "<li>").Replace("\r\n", "</li>") + "</ul>";

			lblRecentChanges.Text += string.Format("<li><a href='/repeaters/details/?id={3}'>{0} ({1})</a> {2}</li>", change.RepeaterCallsign, change.Frequency, desc, change.RepeatersID);
		}

		lblRecentChanges.Text += "</ul>";

		loadMostWanted();
	}

	protected void loadMostWanted()
	{
		//lblMostWanted.Text = "<h3>10 most wanted</h3>";
		System.Web.UI.ControlCollection pnl = pnlMostWanted.Controls;
		string json = "";

		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format("{0}{1}", System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"], "ReportExpiredRepeaters");
			json = webClient.DownloadString(url);
			ViewState["expiredRepeaters"] = json;
		}

		dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

		if (data.Report != null)
		{
			Label lbl = new Label();
			lbl.Text = string.Format("<h3>{0}</h3><p>These repeaters have expired their coordination. If you know anything that may lead to the <del>arrest and conviction</del> updating of this record, please contact us or the repeater owner.", data.Report.Title);
			pnl.Add(lbl);

			Table table = new Table();
			using (TableRow headerRow = new TableRow())
			{
				headerRow.AddCell("Expired");
				headerRow.AddCell("Repeater");
				headerRow.AddCell("City");
				headerRow.AddCell("Sponsor");
				headerRow.AddCell("Trustee");
				headerRow.CssClass = "expiredRepeaterHeader";
				table.Rows.Add(headerRow);
			}

            if (data.Report.Data != null)
            {
                foreach (dynamic item in data.Report.Data)
                {
                    dynamic repeater = item.Repeater;

                    using (TableRow row = new TableRow())
                    {
                        row.AddCell((string)repeater.YearsExpired + " yrs");
                        row.AddCell(string.Format("<a target='_blank' title='Details' href='/repeaters/details/?id={0}'>{1}<br>{2}</a>", (string)repeater.ID, (string)repeater.Output, (string)repeater.Callsign));
                        row.AddCell((string)repeater.City);
                        row.AddCell((string)repeater.Sponsor);
                        row.AddCell(string.Format("<a target='_blank' title='QRZ' href='https://qrz.com/db/{0}'>{1}</a>", (string)repeater.Trustee.Callsign, (string)repeater.Trustee.Name));
                        row.CssClass = "expiredRepeaterData";
                        table.Rows.Add(row);
                    }
                }
            }
            else
            {
                using (TableRow row = new TableRow())
                {
                    row.AddCell("None! We're all current! Yay!", 5);
                    row.CssClass = "expiredRepeaterData";
                    table.Rows.Add(row);
                }
            }
			pnl.Add(table);
		}
	}
}