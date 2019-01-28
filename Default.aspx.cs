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

		string json = Utilities.GetResponseFromUrl(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetRepeaterUpdateNumbers");
		dynamic stats = JsonConvert.DeserializeObject<dynamic>(json);

		lblCount.Text = stats.TotalRepeaters;
		hdnPercentCurrent.Value = stats.PercentageCurrent;
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
	}
}