using Newtonsoft.Json;
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

		LoadRepeaterDetails();
	}

	private void LoadRepeaterDetails()
	{
		if (!IsPostBack)
		{
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

			// Load data into new controls
			lblRepeaterName.Text = repeater.RepeaterCallsign + " (" + repeater.OutputFrequency + ")";
			txtID.Text = repeater.ID.ToString();
			ddlType.SelectedValue = repeater.Type;
			txtRepeaterCallsign.Text = repeater.RepeaterCallsign;
			txtTrusteeID.Text = repeater.TrusteeID;
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
			txtCoordinatorComments.Text = repeater.CoordinatorComments;
			txtNotes.Text = repeater.Notes;
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("/dashboard/");
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		// Create repeater object from fields
		Repeater newRepeater = new Repeater(txtID.Text, ddlType.SelectedValue, txtRepeaterCallsign.Text, txtTrusteeID.Text, ddlStatus.SelectedValue, txtCity.Text, txtSiteName.Text, txtOutputFrequency.Text, txtInputFrequency.Text, txtSponsor.Text, txtLatitude.Text, txtLongitude.Text, txtAMSL.Text, txtERP.Text, txtOutputPower.Text, txtAntennaGain.Text, txtAntennaHeight.Text, txtAnalog_InputAccess.Text, txtAnalog_OutputAccess.Text, txtAnalog_Width.Text, ddlDSTARmodule.SelectedValue, ddlDMR_ColorCode.SelectedValue, txtDMR_ID.Text, ddlDMR_Network.SelectedValue, txtP25_NAC.Text, txtNXDN_RAN.Text, txtYSF_DSQ.Text, ddlAutopatch.SelectedValue, chkEmergencyPower.Checked, chkLinked.Checked, chkRACES.Checked, chkARES.Checked, chkWideArea.Checked, chkWeather.Checked, chkExperimental.Checked, txtDateCoordinated.Text, txtDateUpdated.Text, txtDateDecoordinated.Text, txtDateCoordinationSource.Text, txtDateConstruction.Text, txtCoordinatorComments.Text, txtNotes.Text, txtState.Text);

		// Save repeater
		newRepeater.Save(creds, repeater);
	}
}