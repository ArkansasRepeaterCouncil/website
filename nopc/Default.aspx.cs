using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nopc_Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string urlKey = Request.QueryString["nopc"];
		if ((urlKey != null) && (urlKey != ""))
		{
			LoadRequestDetails(urlKey);
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
						if (json.Request.Authorized[0].State == step.Step.State)
						{
							DropDownList ddl = new DropDownList();
							ddl.Items.Add(new ListItem("Requested", "1"));
							ddl.Items.Add(new ListItem("Approved", "2"));
							ddl.Items.Add(new ListItem("Declined", "3"));
							ddl.ID = "ddlStatus";
							ddl.SelectedValue = step.Step.Status.ID.ToString();
							cell.Controls.Add(ddl);
						}
						else
						{
							cell.Text = step.Step.Status.Description;
						}
						row.Cells.Add(cell);
					}

					using (TableCell cell = new TableCell())
					{
						if (json.Request.Authorized[0].State == step.Step.State)
						{
							TextBox txt = new TextBox();
							txt.ID = "txtNote";
							txt.Width = new Unit("400px");
							cell.Controls.Add(txt);
						}
						else
						{
							cell.Text = String.Format("{0}<div class='noteDate'>{1}</div>", step.Step.Note, step.Step.TimeStamp);
						}
						row.Cells.Add(cell);
					}

					tblWorkflow.Rows.Add(row);
				}
			}
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		DropDownList ddl = (DropDownList)this.FindControl("ddlStatus");
		TextBox txt = (TextBox)this.FindControl("txtNote");
		
		if ((ddl.SelectedValue == "3") && (txt.Text.Trim() == ""))
		{
			// They need to enter a reason why they declined it.
			lblError.Visible = true;
		}
		else
		{
			// Submit changes.
			lblError.Visible = false;

		}
	}
}