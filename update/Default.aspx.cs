﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class update_Default : System.Web.UI.Page
{
	Credentials creds;
	Repeater repeater;

	protected void Page_Load(object sender, EventArgs e)
	{
		creds = Utilities.GetExistingCredentials();

		string repeaterId = "0";
		try
		{
			repeaterId = Request.QueryString["id"].ToString();

			// Call web service to get all data for the repeater with this ID
			repeater = Repeater.Load(creds, repeaterId);
			ViewState["repeater"] = repeater;
		}
		catch (Exception)
		{
			throw new HttpParseException("Unable to load and parse data for requested repeater. Please try again. If the problem persists please report it.");
		}

		LoadRepeaterDetails(repeaterId);
		LoadRepeaterNotes(repeaterId);
	}

	private void LoadRepeaterDetails(string repeaterId)
	{
		if (!IsPostBack)
		{
			// Load data into new controls
			lblRepeaterName.Text = repeater.RepeaterCallsign + " (" + repeater.OutputFrequency + ")";
			txtID.Text = repeater.ID.ToString();
			ddlType.SelectedValue = repeater.Type;
			txtRepeaterCallsign.Text = repeater.RepeaterCallsign;
			txtTrusteeCallsign.Text = repeater.TrusteeCallsign;
			hdnTrusteeId.Value = repeater.TrusteeID;
			ddlStatus.SelectedValue = repeater.Status;
			txtCity.Text = repeater.City;
			txtSiteName.Text = repeater.SiteName;
			txtOutputFrequency.Text = repeater.OutputFrequency;
			txtInputFrequency.Text = repeater.InputFrequency;
			txtSponsor.Text = repeater.Sponsor;
			txtLatitude.Text = repeater.Latitude;
			txtLongitude.Text = repeater.Longitude;
			txtAMSL.Text = repeater.AMSL;
			txtERP.Text = repeater.ERP;
			txtOutputPower.Text = repeater.OutputPower;
			txtAntennaGain.Text = repeater.AntennaGain;
			txtAntennaHeight.Text = repeater.AntennaHeight;
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
		}
		else
		{
			try
			{
				repeater = (Repeater)ViewState["repeater"];
			}
			catch (Exception)
			{
				throw new Exception("Unable to load repeater data from memory.");
			}
			
		}
	}

	private void LoadRepeaterNotes(string repeaterId)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string rootUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"].ToString();
			string url = String.Format("{0}GetRepeaterNotes?callsign={1}&password={2}&repeaterid={3}", rootUrl, creds.Username, creds.Password, repeaterId);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			string[] fields = { "ChangeID", "callsign", "FullName", "ChangeDateTime", "ChangeDescription" };
			
			string output = "";
			foreach (dynamic obj in data)
			{
				output += String.Format("<div class='noteTop'>{0} - {1} ({2})</div><div class='noteBottom'>{3}</div>", obj["ChangeDateTime"], obj["FullName"], obj["callsign"], obj["ChangeDescription"]);
			}
			lblNotes.Text = output;
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("/dashboard/");
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		// Create repeater object from fields
		Repeater newRepeater = new Repeater(txtID.Text, ddlType.SelectedValue, txtRepeaterCallsign.Text, hdnTrusteeId.Value, ddlStatus.SelectedValue, txtCity.Text, txtSiteName.Text, txtOutputFrequency.Text, txtInputFrequency.Text, txtSponsor.Text, txtLatitude.Text, txtLongitude.Text, txtAMSL.Text, txtERP.Text, txtOutputPower.Text, txtAntennaGain.Text, txtAntennaHeight.Text, txtAnalog_InputAccess.Text, txtAnalog_OutputAccess.Text, txtAnalog_Width.Text, ddlDSTARmodule.SelectedValue, ddlDMR_ColorCode.SelectedValue, txtDMR_ID.Text, ddlDMR_Network.SelectedValue, txtP25_NAC.Text, txtNXDN_RAN.Text, txtYSF_DSQ.Text, ddlAutopatch.SelectedValue, chkEmergencyPower.Checked, chkLinked.Checked, chkRACES.Checked, chkARES.Checked, chkWideArea.Checked, chkWeather.Checked, chkExperimental.Checked, txtDateCoordinated.Text, txtDateUpdated.Text, txtDateDecoordinated.Text, txtDateCoordinationSource.Text, txtDateConstruction.Text, txtState.Text);

		// Save repeater
		newRepeater.Save(creds, repeater);
	}

	protected void btnChangeTrustee_Click(object sender, EventArgs e)
	{
		ddlTrustee.Visible = true;
		txtTrusteeCallsign.Visible = false;
		btnChangeTrustee.Visible = false;
		ddlTrustee.Items.Clear();

		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetUsersRepeaters?callsign={0}&password={1}", creds.Username, creds.Password);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			foreach (dynamic obj in data)
			{
				ListItem li = new ListItem(obj["Callsign"], obj["ID"]);
				ddlTrustee.Items.Add(li);
			}
		}
	}
}