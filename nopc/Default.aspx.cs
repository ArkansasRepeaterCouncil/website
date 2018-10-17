using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nopc_Default : System.Web.UI.Page
{
	string urlKey;

	protected void Page_Load(object sender, EventArgs e)
	{
		urlKey = Request.QueryString["nopc"];

		if ((urlKey != null) && (urlKey != ""))
		{
			ClearWorkflowTable();
			LoadRequestDetails(urlKey);
		}
	}

	private void ClearWorkflowTable()
	{
		for (int i = 1; i < tblWorkflow.Rows.Count; i++)
		{
			tblWorkflow.Rows.RemoveAt(i);
		}
		
	}

	private void LoadRequestDetails(string urlKey)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string rootUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"].ToString();
			string url = String.Format("{0}GetCoordinationRequestWorkflowStep?urlKey={1}", rootUrl, urlKey);
			string strJson = webClient.DownloadString(url);
			dynamic json = JsonConvert.DeserializeObject<dynamic>(strJson);

			lblAltitude.Text = json.Request.Altitude;
			lblAntennaHeight.Text = json.Request.AntennaHeight;
			lblID.Text = String.Format("NOPC #{0}{1}", json.Request.State, json.Request.ID);
			lblLatitude.Text = json.Request.Latitude;
			lblLongitude.Text = json.Request.Longitude;
			lblOutputFrequency.Text = json.Request.OutputFrequency;
			lblPower.Text = json.Request.OutputPower;
			lblRequestor.Text = String.Format("{0}, {1}", json.Request.Requestor.Name, json.Request.Requestor.Callsign);
			lblStatus.Text = json.Request.Status.Description;
			lblRespondingEntity.Text = json.Request.Authorized[0].State;

			foreach (dynamic note in json.Request.Notes)
			{
				using (TableRow row = new TableRow())
				{
					TableCell cellName = new TableCell();
					cellName.Text = String.Format("{0}", note.Note.Timestamp);
					cellName.HorizontalAlign = HorizontalAlign.Left;
					row.Cells.Add(cellName);
					tblNotes.Rows.Add(row);

					TableCell cellDateTime = new TableCell();
					cellDateTime.Text = String.Format("{0}, {1}", note.Note.User.Name, note.Note.User.Callsign);
					cellDateTime.HorizontalAlign = HorizontalAlign.Right;
					row.Cells.Add(cellDateTime);
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

	protected void btnSubmit_Click(object sender, EventArgs e)
	{	
		if (this.IsValid)
		{
			// Submit changes.
			new RequestUpdate(urlKey, ddlStatus.SelectedValue, txtNote.Text.Trim()).Save();
			txtNote.Enabled = false;
			ddlStatus.Enabled = false;
			btnSubmit.Enabled = false;
			lblSaved.Visible = true;
			LoadRequestDetails(urlKey);
		}
	}

	protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
	{
		if ((ddlStatus.SelectedValue == "3") && (txtNote.Text.Trim() == string.Empty))
		{
			args.IsValid = false;
		}
		else
		{
			args.IsValid = true;
		}
	}
}