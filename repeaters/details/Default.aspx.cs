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
		repeaterId = "0";
		try
		{
			repeaterId = Request.QueryString["id"].ToString();

			// Call web service to get all data for the repeater with this ID
			repeater = Repeater.LoadPublic(repeaterId);
		}
		catch (Exception)
		{
			throw new HttpParseException("Unable to load and parse data for requested repeater. Please try again. If the problem persists please report it using the link at the bottom of the page.");
		}

		LoadRepeaterDetails(repeaterId);
	}

	private void LoadRepeaterDetails(string repeaterId)
	{
		// formPanel.Controls
		foreach (Control tab in TabContainer1.Controls)
		{
			foreach (Control content in tab.Controls)
			{
				foreach (Control child in content.Controls)
				{
					if (child is TextBox)
					{
						((TextBox)child).ReadOnly = true;
					}
					else if (child is DropDownList)
					{
						((DropDownList)child).Enabled = false;
					}
					else if (child is CheckBox)
					{
						((CheckBox)child).Enabled = false;
					}
				}
			}
		}

		lblRepeaterName.Text = repeater.RepeaterCallsign + " (" + repeater.OutputFrequency + ")";
		txtID.Text = repeater.ID.ToString();
		ddlType.SelectedValue = repeater.Type;
		txtRepeaterCallsign.Text = repeater.RepeaterCallsign;
		txtTrusteeCallsign.Text = repeater.TrusteeCallsign;
		ddlStatus.SelectedValue = repeater.Status;
		txtCity.Text = repeater.City;
		txtSiteName.Text = repeater.SiteName;
		txtOutputFrequency.Text = repeater.OutputFrequency;
		txtInputFrequency.Text = repeater.InputFrequency;
		txtSponsor.Text = repeater.Sponsor;
		txtLatitude.Text = "*********"; //repeater.Latitude;
		txtLongitude.Text = "*********"; //repeater.Longitude;
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
		txtCoordinatedAntennaHeight.Text = repeater.CoordinatedAntennaHeight;
		txtCoordinatedLatitude.Text = repeater.CoordinatedLatitude;
		txtCoordinatedLongitude.Text = repeater.CoordinatedLongitude;
		txtCoordinatedOutputPower.Text = repeater.CoordinatedOutputPower;
	}
}