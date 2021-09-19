using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Device.Location;
using System.Web.UI;

public partial class update_Default : System.Web.UI.Page
{
	Repeater repeater;
	string repeaterId;
	bool enforceBusinessRules = false;

	protected void Page_Load(object sender, EventArgs e)
	{
		disableForm();
		repeaterId = "0";

		if (Request.QueryString["id"] != null)
		{
			repeaterId = Request.QueryString["id"].ToString();
			int intRepeaterId = 0;

			if (int.TryParse(repeaterId, out intRepeaterId))
			{
				// Call web service to get all data for the repeater with this ID
				try
				{
					repeater = Repeater.LoadPublic(repeaterId);
					LoadRepeaterDetails(repeaterId);
					LoadRepeaterLinks(repeaterId);
				}
				catch (Exception ex)
				{
					lblRepeaterName.Text= "Unable to load and parse data for requested repeater. If the problem persists please report it using the link at the bottom of the page.";
				}
			}
		}

		HttpCookie hc = Request.Cookies["login"];
		if ((hc != null) && (hc.Value != string.Empty))
		{
			btnReport.Visible = true;
            btnReport_notLoggedIn.Visible = false;

            HttpCookie chocolatechip = Request.Cookies["chocolatechip"];
			if ((chocolatechip != null) && (chocolatechip.Value == "1"))
			{
				btnUpdate.Visible = true;
				btnUpdate.PostBackUrl = string.Format("~/update/?id={0}", repeaterId);
			}
		}
	}

	private void disableForm()
	{
		// formPanel.Controls
		foreach (Control control in formPanel.Controls)
		{
			if (control is TextBox)
			{
				((TextBox)control).ReadOnly = true;
			}
			else if (control is DropDownList)
			{
				((DropDownList)control).Enabled = false;
			}
			else if (control is CheckBox)
			{
				((CheckBox)control).Enabled = false;
			}
		}

	}

	private void LoadRepeaterDetails(string repeaterId)
	{
		lblRepeaterName.Text = repeater.RepeaterCallsign + " (" + repeater.OutputFrequency + ")";
		txtID.Text = repeater.ID.ToString();
		ddlType.SelectedValue = repeater.Type;
		txtRepeaterCallsign.Text = string.Format("<a href='https://qrz.com/db/{0}' target='_blank'>{0}</a>", repeater.RepeaterCallsign);
		txtTrusteeCallsign.Text = string.Format("<a href='https://qrz.com/db/{0}' target='_blank'>{0}</a>", repeater.TrusteeCallsign);
		ddlStatus.SelectedValue = repeater.Status;
		txtCity.Text = repeater.City;
		txtSiteName.Text = repeater.SiteName;
		txtOutputFrequency.Text = repeater.OutputFrequency;
		txtInputFrequency.Text = repeater.InputFrequency;
		txtSponsor.Text = repeater.Sponsor;
		txtLatitude.Text = repeater.Latitude;
		txtLongitude.Text = repeater.Longitude;
		linkMap.NavigateUrl = repeater.MapUrl;
		txtAMSL.Text = repeater.AMSL;
		txtERP.Text = repeater.ERP;
		txtOutputPower.Text = repeater.OutputPower;
		txtAntennaGain.Text = repeater.AntennaGain;
		txtAntennaHeight.Text = repeater.AntennaHeight + " meters";
		txtAnalog_InputAccess.Text = repeater.Analog_InputAccess;
		txtAnalog_OutputAccess.Text = repeater.Analog_OutputAccess;
		txtAnalog_Width.Text = repeater.Analog_Width;
		ddlDSTARmodule.SelectedValue = repeater.DSTAR_Module;
		ddlDMR_ColorCode.SelectedValue = repeater.DMR_ColorCode;
		txtDMR_ID.Text = repeater.DMR_ID;
		ddlDMR_Network.SelectedValue = repeater.DMR_Network;
		txtP25_NAC.Text = repeater.P25_NAC;
		txtNXDN_RAN.Text = repeater.NXDN_RAN;
		txtYSF_DSQ.Text = repeater.YSF_DSQ;
		ddlAutopatch.SelectedValue = repeater.Autopatch;
		chkEmergencyPower.Checked = repeater.EmergencyPower;
		chkLinked.Checked = repeater.Linked;
		chkRACES.Checked = repeater.RACES;
		chkARES.Checked = repeater.ARES;
		chkWideArea.Checked = repeater.WideArea;
		chkWeather.Checked = repeater.Weather;
		chkExperimental.Checked = repeater.Experimental;
		txtDateCoordinated.Text = repeater.DateCoordinated;
		txtDateUpdated.Text = repeater.DateUpdated;
		txtDateDecoordinated.Text = repeater.DateDecoordinated;
		txtDateCoordinationSource.Text = repeater.DateCoordinationSource;
		txtDateConstruction.Text = repeater.DateConstruction;
		txtState.Text = repeater.State;
		txtCoordinatedAntennaHeight.Text = repeater.CoordinatedAntennaHeight;
		txtCoordinatedLatitude.Text = repeater.CoordinatedLatitude;
		txtCoordinatedLongitude.Text = repeater.CoordinatedLongitude;
		txtCoordinatedOutputPower.Text = repeater.CoordinatedOutputPower;
		txtAdditionalInformation.Text = repeater.AdditionalInformation;
	}

	private void LoadRepeaterLinks(string repeaterId)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string rootUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"].ToString();
			string url = String.Format("{0}ListRepeaterLinks?repeaterid={1}", rootUrl, repeaterId);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			tblLinks.Rows.Clear();
			using (TableHeaderRow thr = new TableHeaderRow())
			{
				using (TableHeaderCell thc = new TableHeaderCell())
				{
					thc.Text = "Direct link?";
					thr.Cells.Add(thc);
				}
				using (TableHeaderCell thc = new TableHeaderCell())
				{
					thc.Text = "Frequency";
					thr.Cells.Add(thc);
				}
				using (TableHeaderCell thc = new TableHeaderCell())
				{
					thc.Text = "Callsign";
					thr.Cells.Add(thc);
				}
				using (TableHeaderCell thc = new TableHeaderCell())
				{
					thc.Text = "City";
					thr.Cells.Add(thc);
				}
				tblLinks.Rows.Add(thr);
			}

			foreach (dynamic obj in data)
			{
				TableRow row = new TableRow();
				TableCell cell = new TableCell();

				if (obj["DirectlyLinked"] == true)
				{
					cell = new TableCell();
					cell.Text = "Yes";
					row.Cells.Add(cell);
				}
				else
				{
					cell = new TableCell();
					cell.Text = "No";
					row.Cells.Add(cell);
				}

				cell = new TableCell();
				cell.Text = string.Format("<a href=\"/repeaters/details/?id={0}\">{1}</a>", obj["ID"], stringify(obj["OutputFrequency"]));
				row.Cells.Add(cell);

				cell = new TableCell();
				cell.Text = string.Format("<a href=\"/repeaters/details/?id={0}\">{1}</a>", obj["ID"], stringify(obj["Callsign"]));
				row.Cells.Add(cell);

				cell = new TableCell();
				cell.Text = string.Format("<a href=\"/repeaters/details/?id={0}\">{1}</a>", obj["ID"], stringify(obj["City"]));
				row.Cells.Add(cell);

				tblLinks.Rows.Add(row);
			}
		}
	}

	protected void btnReport_Click(object sender, EventArgs e)
	{
		Credentials credentials = Utilities.GetExistingCredentials();
		new RepeaterOfflineReport(credentials, int.Parse(repeaterId));
		lblOffTheAir.Visible = true;
	}

	private string stringify(dynamic val)
	{
		string ret = string.Empty;

		if (val == null)
		{
			return "";
		}
		else
		{
			try
			{
				return val.ToString();
			}
			catch (Exception)
			{
				return "?? ERROR: Object can't be displayed as a string.";
			}
		}
	}
}