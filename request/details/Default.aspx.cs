using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class request_details_Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Credentials creds = Utilities.GetExistingCredentials();
		string requestid = Request.QueryString["id"];
		LoadRequestDetails(creds, requestid);
	}

	private void LoadRequestDetails(Credentials creds, string requestid)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string rootUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"].ToString();
			string url = String.Format("{0}GetCoordinationRequestDetails?callsign={1}&password={2}&requestid={3}", rootUrl, creds.Username, creds.Password, requestid);
			string strJson = webClient.DownloadString(url);
			dynamic json = JsonConvert.DeserializeObject<dynamic>(strJson);

			lblAltitude.Text = json.Request.Altitude;
			lblAntennaHeight.Text = json.Request.AntennaHeight;
			lblID.Text = String.Format("Coordination Request #{0}{1}", json.Request.State, json.Request.ID);
			lblLatitude.Text = json.Request.Latitude;
			lblLongitude.Text = json.Request.Longitude;
			lblOutputFrequency.Text = json.Request.OutputFrequency;
			lblPower.Text = json.Request.OutputPower;
			lblRequestor.Text = String.Format("{0}, {1}", json.Request.Requestor.Name, json.Request.Requestor.Callsign);
			lblStatus.Text = json.Request.Status.Description;

			foreach (dynamic note in json.Request.Notes)
			{
				using (TableRow row = new TableRow())
				{
					using (TableCell cell = new TableCell())
					{
						cell.Text = String.Format("{0}, {1}", note.Note.User.Name, note.Note.User.Callsign);
						cell.HorizontalAlign = HorizontalAlign.Left;
						row.Cells.Add(cell);
					}

					using (TableCell cell = new TableCell())
					{
						cell.Text = String.Format("{0}", note.Note.Timestamp);
						cell.HorizontalAlign = HorizontalAlign.Right;
						row.Cells.Add(cell);
					}

					tblNotes.Rows.Add(row);
				}

				using (TableRow row = new TableRow())
				{
					TableCell cell = new TableCell();
					cell.Text = note.Note.Text;
					cell.ColumnSpan = 2;
					row.Cells.Add(cell);
					tblNotes.Rows.Add(row);
				}
			}

			foreach (dynamic step in json.Request.Workflow)
			{
				using (TableRow row = new TableRow())
				{
					using (TableCell cell = new TableCell())
					{
						cell.Text = step.Step.State;
						row.Cells.Add(cell);
					}

					using (TableCell cell = new TableCell())
					{
						cell.Text = step.Step.Status.Description;
						row.Cells.Add(cell);
					}

					using (TableCell cell = new TableCell())
					{
						cell.Text = String.Format("{0}<div class='noteDate'>{1}</div>", step.Step.Note, step.Step.TimeStamp);
						row.Cells.Add(cell);
					}

					tblWorkflow.Rows.Add(row);
				}
			}
		}
	}
}