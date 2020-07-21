using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Device.Location;
using System.Web.UI;

public partial class update_Default : System.Web.UI.Page
{
	Credentials creds;
	Repeater repeater;
	string repeaterId;
	bool enforceBusinessRules = true;
	int indexOfLinksTab = 1;
	int indexOfUsersTab = 6;

	protected void Page_Load(object sender, EventArgs e)
	{
		creds = Utilities.GetExistingCredentials();

		repeaterId = "0";
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

		if (repeaterId != "0")
		{
			LoadRepeaterDetails(repeaterId);
			LoadRepeaterNotes(repeaterId);
			LoadRepeaterUsers(repeaterId);
		}
	}

	private void LoadRepeaterDetails(string repeaterId)
	{
		if (!IsPostBack)
		{
			// Load data into new controls
			if (repeater.Status == "6")
			{
				// formPanel.Controls
				foreach (Control child in formPanel.Controls)
				{
					if (child is TextBox)
					{
						((TextBox)child).Enabled = false;
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
				btnChangeTrustee.Enabled = false;
				btnSave.Enabled = false;
			}

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
			txtCoordinatedAntennaHeight.Text = repeater.CoordinatedAntennaHeight;
			txtCoordinatedLatitude.Text = repeater.CoordinatedLatitude;
			txtCoordinatedLongitude.Text = repeater.CoordinatedLongitude;
			txtCoordinatedOutputPower.Text = repeater.CoordinatedOutputPower;
			txtAdditionalInformation.Text = repeater.AdditionalInformation;
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
			
			string output = "";
			foreach (dynamic obj in data)
			{
				string note = obj["ChangeDescription"].ToString();
				note = note.Replace("• ", "&bull;");
				note = note.Replace("â€¢", "&bull;");
				note = note.Replace("\r\n", "<br>");

				output += String.Format("<div class='noteTop'>{0} - {1} ({2})</div><div class='noteBottom'>{3}</div>", obj["ChangeDateTime"], obj["FullName"], obj["callsign"], note);
			}
			lblNotes.Text = output;
		}
	}

	private void LoadRepeaterUsers(string repeaterId)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string rootUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"].ToString();
			string url = String.Format("{0}ListRepeaterUsers?callsign={1}&password={2}&repeaterid={3}", rootUrl, creds.Username, creds.Password, repeaterId);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			tblRepeaterUsers.Rows.Clear();
			using (TableHeaderRow thr = new TableHeaderRow())
			{
				using (TableHeaderCell thc = new TableHeaderCell())
				{
					Button btnAddRepeaterUser = new Button();
					btnAddRepeaterUser.ID = "btnAddRepeaterUser";
					btnAddRepeaterUser.Click += btnAddRepeaterUser_Click;
					btnAddRepeaterUser.Text = "Add new";
					thc.Controls.Add(btnAddRepeaterUser);
					thr.Cells.Add(thc);
				}
				using (TableHeaderCell thc = new TableHeaderCell())
				{
					thc.Text = "Callsign";
					thr.Cells.Add(thc);
				}
				using (TableHeaderCell thc = new TableHeaderCell())
				{
					thc.Text = "Name";
					thr.Cells.Add(thc);
				}
				using (TableHeaderCell thc = new TableHeaderCell())
				{
					thc.Text = "Email";
					thr.Cells.Add(thc);
				}
				tblRepeaterUsers.Rows.Add(thr);
			}

			// ID, Callsign, FullName, Email
			foreach (dynamic obj in data)
			{
				TableRow row = new TableRow();

				TableCell cell = new TableCell();

				if (repeater.Status != "6")
				{
					Button btn = new Button();
					btn.Text = "Remove";
					string userid = obj["ID"].ToString();
					btn.Click += (sender, e) => btnRemoveRepeaterUser(sender, e, userid);
					cell.Controls.Add(btn);
				}

				row.Cells.Add(cell);
				cell = new TableCell();
				cell.Text = obj["Callsign"].ToString();
				row.Cells.Add(cell);

				cell = new TableCell();
				cell.Text = obj["FullName"].ToString();
				row.Cells.Add(cell);

				cell = new TableCell();
				cell.Text = String.Format("<a href='mailto:{0}'>{0}</a>", obj["Email"].ToString());
				row.Cells.Add(cell);

				tblRepeaterUsers.Rows.Add(row);
			}
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/dashboard/");
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (this.IsValid && repeater.Status != "6")
		{
			string trusteeId = "";
			string trusteeCallsign = "";

			if (ddlTrustee.Visible)
			{
				trusteeId = ddlTrustee.SelectedValue;
				trusteeCallsign = ddlTrustee.SelectedItem.Text;
			}
			else
			{
				trusteeId = hdnTrusteeId.Value;
				trusteeCallsign = txtTrusteeCallsign.Text;
			}

			// Create repeater object from fields
			Repeater newRepeater = new Repeater(txtID.Text, ddlType.SelectedValue, txtRepeaterCallsign.Text, trusteeId, trusteeCallsign, ddlStatus.SelectedValue, txtCity.Text, txtSiteName.Text, txtOutputFrequency.Text, txtInputFrequency.Text, txtSponsor.Text, txtLatitude.Text, txtLongitude.Text, txtAMSL.Text, txtERP.Text, txtOutputPower.Text, txtAntennaGain.Text, txtAntennaHeight.Text, txtAnalog_InputAccess.Text, txtAnalog_OutputAccess.Text, txtAnalog_Width.Text, ddlDSTARmodule.SelectedValue, ddlDMR_ColorCode.SelectedValue, txtDMR_ID.Text, ddlDMR_Network.SelectedValue, txtP25_NAC.Text, txtNXDN_RAN.Text, txtYSF_DSQ.Text, ddlAutopatch.SelectedValue, chkEmergencyPower.Checked, chkLinked.Checked, chkRACES.Checked, chkARES.Checked, chkWideArea.Checked, chkWeather.Checked, chkExperimental.Checked, txtDateCoordinated.Text, txtDateUpdated.Text, txtDateDecoordinated.Text, txtDateCoordinationSource.Text, txtDateConstruction.Text, txtState.Text, repeater.CoordinatedLatitude, repeater.CoordinatedLongitude, repeater.CoordinatedOutputPower, repeater.CoordinatedAntennaHeight, txtNote.Text.Trim(), txtAdditionalInformation.Text.Trim());

			if (chkOverride.Checked) {
				if (newRepeater.Note.Trim() != string.Empty)
				{
					newRepeater.Note += "\r\n\r\n";
				}
				newRepeater.Note += "** Coordinator override **";
			}

			// Save repeater
			newRepeater.Save(creds, repeater);
			lblChangesSaved.Visible = true;

			// Reset override
			pnlOverride.Visible = false;
			chkOverride.Checked = false;
		}
	}

	protected void btnChangeTrustee_Click(object sender, EventArgs e)
	{
		ddlTrustee.Visible = true;
		txtTrusteeCallsign.Visible = false;
		btnChangeTrustee.Visible = false;
		ddlTrustee.Items.Clear();

		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ListPossibleTrustees?callsign={0}&password={1}&repeaterid={2}", creds.Username, creds.Password, txtID.Text);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
			
			foreach (dynamic obj in data)
			{
				ListItem li = new ListItem(obj["Callsign"].ToString(), obj["ID"].ToString());
				ddlTrustee.Items.Add(li);
			}

			ddlTrustee.SelectedValue = hdnTrusteeId.Value;
		}
	}

	protected void validLocation_ServerValidate(object source, ServerValidateEventArgs args)
	{
		if ((enforceBusinessRules) && (!chkOverride.Checked))
		{
			try
			{
				double aLat = Double.Parse(repeater.CoordinatedLatitude);
				double aLon = Double.Parse(repeater.CoordinatedLongitude);
				GeoCoordinate a = new GeoCoordinate(aLat, aLon);

				double bLat = Double.Parse(txtLatitude.Text);
				double bLon = Double.Parse(txtLongitude.Text);
				GeoCoordinate b = new GeoCoordinate(bLat, bLon);

				double metersAway = a.GetDistanceTo(b);

				if (metersAway <= 1609.34)
				{
					args.IsValid = true;
				}
				else
				{
					args.IsValid = false;
					ShowOverrideIfIsCoordinatorForRepeater();
				}
			}
			catch (Exception)
			{
				args.IsValid = false;
			}
		}
		else
		{
			args.IsValid = true;
		}

	}

	protected void validLocation2_ServerValidate(object source, ServerValidateEventArgs args)
	{
		try
		{
			double aLat = Double.Parse(repeater.CoordinatedLatitude);
			double aLon = Double.Parse(repeater.CoordinatedLongitude);

			if ((-91.0 < aLat) && (aLat < 91.0) && (-181.0 < aLon) && (aLon < 181.0))
			{
				args.IsValid = true;
			}
			else
			{
				args.IsValid = false;
			}
		}
		catch (Exception)
		{
			args.IsValid = false;
		}
	}

	protected void validAntennaHeight_ServerValidate(object source, ServerValidateEventArgs args)
	{
		if ((enforceBusinessRules) && (!chkOverride.Checked))
		{
            try
            {
                Double newHeight = Double.Parse(txtAntennaHeight.Text);
                Double allowedHeight = Double.Parse(repeater.CoordinatedAntennaHeight) + 15.24;

                if (newHeight <= allowedHeight)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    ShowOverrideIfIsCoordinatorForRepeater();
                }
            }
            catch (Exception)
            {
                args.IsValid = false;
            }

		}
		else
		{
			args.IsValid = true;
		}
	}

	protected void validOutputPower_ServerValidate(object source, ServerValidateEventArgs args)
	{
		if ((enforceBusinessRules) && (!chkOverride.Checked))
		{
			try
			{
				int newPower = int.Parse(txtOutputPower.Text);
				int allowedPower = int.Parse(repeater.CoordinatedOutputPower) + 5;

				if (newPower <= allowedPower)
				{
					args.IsValid = true;
				}
				else
				{
					args.IsValid = false;
					ShowOverrideIfIsCoordinatorForRepeater();
				}
			}
			catch
			{
				args.IsValid = false;
			}
		}
		else
		{
			args.IsValid = true;
		}
	}

	protected void btnAddRepeaterUser_Click(object sender, EventArgs e)
	{
		pnlAddUser.Visible = true;
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ListPossibleRepeaterUsers?callsign={0}&password={1}&repeaterid={2}", creds.Username, creds.Password, repeater.ID.ToString());
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			ddlAddUser.Items.Clear();
			foreach (dynamic obj in data)
			{
				ListItem li = new ListItem(string.Format("{0} - {1}", obj["Callsign"].ToString(), obj["FullName"].ToString()), obj["ID"].ToString());
				ddlAddUser.Items.Add(li);
			}
		}

		ScriptManager.RegisterStartupScript(this, typeof(Page),"alertScript", "$( '#tabs' ).tabs({ active: 6 });", true);
	}

	protected void btnRemoveRepeaterUser(object sender, EventArgs e, string userid)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "RemoveRepeaterUser?callsign={0}&password={1}&repeaterid={2}&userid={3}", creds.Username, creds.Password, repeater.ID.ToString(), userid);
			string json = webClient.DownloadString(url);
		}
		LoadRepeaterUsers(repeaterId);
	}

	protected void btnAddUser_Click(object sender, EventArgs e)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "AddRepeaterUser?callsign={0}&password={1}&repeaterid={2}&userid={3}", creds.Username, creds.Password, repeater.ID.ToString(), ddlAddUser.SelectedValue);
			string json = webClient.DownloadString(url);
		}

		LoadRepeaterUsers(repeaterId);
		pnlAddUser.Visible = false;
		ScriptManager.RegisterStartupScript(this, typeof(Page), "alertScript", "$( '#tabs' ).tabs({ active: " + indexOfUsersTab.ToString() + " });", true);
	}

	protected void ShowOverrideIfIsCoordinatorForRepeater()
	{
		if (hdnIsCoordinatorForRepeater.Value == "")
		{
			try
			{
				// Check if they are a coordinator
				using (var webClient = new System.Net.WebClient())
				{
					string rootUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"].ToString();
					string url = String.Format("{0}IsCoordinatorForRepeater?callsign={1}&password={2}&repeaterid={3}", rootUrl, creds.Username, creds.Password, repeaterId);
					string json = webClient.DownloadString(url);
					dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

					if (data.IsCoordinatorForRepeater == "true")
					{
						hdnIsCoordinatorForRepeater.Value = "true";
						pnlOverride.Visible = true;
					}
					else
					{
						hdnIsCoordinatorForRepeater.Value = "false";
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}

	protected void btnLoadLinks_Click(object sender, EventArgs e)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string rootUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"].ToString();
			string url = String.Format("{0}GetPossibleLinks_Json", rootUrl);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			ddlLinks.Items.Clear();

			foreach (dynamic obj in data)
			{
				ListItem li = new ListItem(obj["Link"]["Description"].ToString(), obj["Link"]["Value"].ToString());
				ddlLinks.Items.Add(li);
			}

			ddlLinks.Enabled = true;
			btnAddLink.Enabled = true;
			btnLoadLinks.Enabled = false;
		}

		ScriptManager.RegisterStartupScript(this, typeof(Page), "alertScript", "$( '#tabs' ).tabs({ active: " + indexOfLinksTab.ToString() + " });", true);
	}
}