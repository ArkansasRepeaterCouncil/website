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
		loadOpenRequestsReport();

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

	protected void loadOpenRequestsReport()
	{
		System.Web.UI.ControlCollection pnl = pnlOpenRequests.Controls;
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
					row.AddCell("", "workflowDivider", 6);
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

				using (TableRow row = new TableRow())
				{
					row.AddCell("", "workflowDivider", 6);
					table.Rows.Add(row);
				}
			}
			pnl.Add(table);
		}
		else
		{
			Label label = new Label();
			label.Text = "There are no coordination requests currently open.";
			pnl.Add(label);
		}
	}

	private void Button_Click(object sender, EventArgs e)
	{
		Button btn = (Button)sender;
		switch (btn.CommandName)
		{

		}
	}
}