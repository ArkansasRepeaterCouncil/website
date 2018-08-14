using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RepeaterProperty
/// </summary>
public class RepeaterProperty
{
	public string FriendlyName;
	public string Name;
	public dynamic Value;
	public string Type;
	public bool ReadOnly;

	public RepeaterProperty(dynamic property)
	{
		Name = property.Name;
		FriendlyName = Name;
		Type = property.Value.Type.ToString();
		ReadOnly = false;
		Value = property.Value;

		switch (Name)
		{
			case "ID":
				ReadOnly = true;
				break;
			case "Type":
				break;
			case "Callsign":
				break;
			case "TrusteeID":
				break;
			case "Status":
				break;
			case "City":
				break;
			case "SiteName":
				FriendlyName = "Site name";
				break;
			case "OutputFrequency":
				FriendlyName = "Output frequency";
				ReadOnly = true;
				break;
			case "InputFrequency":
				FriendlyName = "Input frequency";
				ReadOnly = true;
				break;
			case "Sponsor":
				break;
			case "Latitude":
				ReadOnly = true;
				break;
			case "Longitude":
				ReadOnly = true;
				break;
			case "AMSL":
				FriendlyName = "Sea level elevation (meters)";
				break;
			case "ERP":
				FriendlyName = "Effective radiated power (ERP)";
				break;
			case "OutputPower":
				FriendlyName = "Output power";
				break;
			case "AntennaGain":
				FriendlyName = "Antenna gain";
				break;
			case "Analog_InputAccess":
				FriendlyName = "Input tone";
				break;
			case "Analog_OutputAccess":
				FriendlyName = "Output tone";
				break;
			case "Analog_Width":
				FriendlyName = "Bandwidth";
				break;
			case "DSTAR_Module":
				FriendlyName = "D-STAR module";
				break;
			case "DMR_ColorCode":
				FriendlyName = "DMR color code";
				break;
			case "DMR_ID":
				FriendlyName = "DMR ID";
				break;
			case "DMR_Network":
				FriendlyName = "DMR network";
				break;
			case "P25_NAC":
				break;
			case "NXDN_RAN":
				break;
			case "YSF_DSQ":
				break;
			case "Autopatch":
				break;
			case "EmergencyPower":
				FriendlyName = "Emergency power";
				break;
			case "Linked":
				break;
			case "RACES":
				break;
			case "ARES":
				break;
			case "WideArea":
				FriendlyName = "Wide area coverage";
				break;
			case "Weather":
				break;
			case "Experimental":
				break;
			case "DateCoordinated":
				FriendlyName = "Date coordinated";
				ReadOnly = true;
				break;
			case "DateUpdated":
				FriendlyName = "Date updated";
				ReadOnly = true;
				break;
			case "DateDecoordinated":
				FriendlyName = "Date decoodinated";
				ReadOnly = true;
				break;
			case "DateCoordinationSource":
				ReadOnly = true;
				break;
			case "DateConstruction":
				FriendlyName = "Date constructed";
				ReadOnly = true;
				break;
			case "CoordinatorComments":
				FriendlyName = "Coordinator comments";
				ReadOnly = true;
				break;
			case "Notes":
				break;
			case "State":
				ReadOnly = true;
				break;
			default:
				break;
		}
	}
}