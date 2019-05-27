using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

/// <summary>
/// Summary description for Repeater
/// </summary>
[Serializable]
public class Repeater
{
	public enum RepeaterType:int
	{
		Repeater = 1,
		Link = 2,
		Control = 3,
		Packet = 4,
		Beacon = 5,
		AmateurTV = 6,
		RemoteBase = 7,
		ClosedRepeater = 8,
		None = 9
	}

	public enum RepeaterStatus:int
	{
		Proposed = 1,
		UnderConstruction = 2,
		Operational = 3,
		TemporarilyDown = 4,
		SuspectedOffTheAir = 5,
		Decoordinated = 6
	}

	public int ID = 0;
	public string Type = "";
	public string RepeaterCallsign = "";
	public string TrusteeID = "";
	public string TrusteeCallsign = "";
	public string Status = "";
	public string City = "";
	public string SiteName = "";
	public string OutputFrequency = "";
	public string InputFrequency = "";
	public string Sponsor = "";
	public string Latitude = "";
	public string Longitude = "";
	public string AMSL = "";
	public string ERP = "";
	public string OutputPower = "";
	public string AntennaGain = "";
	public string AntennaHeight = "";
	public string Analog_InputAccess = "";
	public string Analog_OutputAccess = "";
	public string Analog_Width = "";
	public string DSTAR_Module = "";
	public string DMR_ColorCode = "";
	public string DMR_ID = "";
	public string DMR_Network = "";
	public string P25_NAC = "";
	public string NXDN_RAN = "";
	public string YSF_DSQ = "";
	public string Autopatch = "";
	public bool EmergencyPower = false;
	public bool Linked = false;
	public bool RACES = false;
	public bool ARES = false;
	public bool WideArea = false;
	public bool Weather = false;
	public bool Experimental = false;
	public string DateCoordinated = "";
	public string DateUpdated = "";
	public string DateDecoordinated = "";
	public string DateCoordinationSource = "";
	public string DateConstruction = "";
	public string State = "";
	public string CoordinatedLatitude = "";
	public string CoordinatedLongitude = "";
	public string CoordinatedOutputPower = "";
	public string CoordinatedAntennaHeight = "";
	public string Note = "";
	[JsonProperty]
	private string ChangeLog = "";
	[JsonProperty]
	private string callsign = "";
	[JsonProperty]
	private string password = "";
	

	public static Repeater Load(Credentials credentials, string repeaterId)
	{
		Repeater repeater = new Repeater();

		int intMaxAttempts = 5;
		for (int i = 1; i < intMaxAttempts; i++)
		{
			try
			{
				using (var webClient = new System.Net.WebClient())
				{
					// Call web service to get all data for the repeater with this ID
					string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetRepeaterDetails?callsign={0}&password={1}&repeaterid={2}", credentials.Username, credentials.Password, repeaterId);
					string json = webClient.DownloadString(url);
					repeater = JsonConvert.DeserializeObject<Repeater>(json);
					break;
				}
			}
			catch (Exception ex)
			{
				// Try again
			}

			if (i == intMaxAttempts)
			{
				Exception ex = new Exception();
				new ExceptionReport(ex, "Exception while calling web service for repeater data (ID: " + repeaterId + ")");
			}
		}
		
		return repeater;
	}

	public static Repeater LoadPublic(string repeaterId)
	{
		Repeater repeater = new Repeater();

		try
		{
			using (var webClient = new System.Net.WebClient())
			{
				// Call web service to get all data for the repeater with this ID
				string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetRepeaterDetailsPublic?id={0}", repeaterId);
				string json = webClient.DownloadString(url);
				repeater = JsonConvert.DeserializeObject<Repeater>(json);
			}
		}
		catch (Exception ex)
		{
			new ExceptionReport(ex, "Exception while calling web service for repeater data", "Repeater ID: " + repeaterId);
		}

		return repeater;
	}

	public Repeater()
	{
		
	}

	public Repeater(string id, string type, string callsign, string trusteeid, string trusteecallsign, string status, 
		string city, string sitename, string outputfrequency, string inputfrequency, string sponsor, string latitude, 
		string longitude, string amsl, string erp, string outputpower, string antennagain, string antennaheight, 
		string analog_inputaccess, string analog_outputaccess, string analog_width, string dstar_module, 
		string dmr_colorcode, string dmr_id, string dmr_network, string p25_nac, string nxdn_ran, string ysf_dsq, 
		string autopatch, bool emergencypower, bool linked, bool races, bool ares, bool widearea, bool weather, 
		bool experimental, string datecoordinated, string dateupdated, string datedecoordinated, 
		string datecoordinationsource, string dateconstruction, string state, string coordinatedLatitude, 
		string coordinatedLongitude, string coordinatedOutputPower, string coordinatedAntennaHeight, string note)
	{
		ID = int.Parse(id);
		Type = type;
		RepeaterCallsign = callsign;
		TrusteeID = trusteeid;
		TrusteeCallsign = trusteecallsign;
		Status = status;
		City = city;
		SiteName = sitename;
		OutputFrequency = outputfrequency;
		InputFrequency = inputfrequency;
		Sponsor = sponsor;
		Latitude = latitude;
		Longitude = longitude;
		AMSL = amsl;
		ERP = erp;
		OutputPower = outputpower;
		AntennaGain = antennagain;
		AntennaHeight = antennaheight;
		Analog_InputAccess = analog_inputaccess;
		Analog_OutputAccess = analog_outputaccess;
		Analog_Width = analog_width;
		DSTAR_Module = dstar_module;
		DMR_ColorCode = dmr_colorcode;
		DMR_ID = dmr_id;
		DMR_Network = dmr_network;
		P25_NAC = p25_nac;
		NXDN_RAN = nxdn_ran;
		YSF_DSQ = ysf_dsq;
		Autopatch = autopatch;
		EmergencyPower = emergencypower;
		Linked = linked;
		RACES = races;
		ARES = ares;
		WideArea = widearea;
		Weather = weather;
		Experimental = experimental;
		DateCoordinated = datecoordinated;
		DateUpdated = dateupdated;
		DateDecoordinated = datedecoordinated;
		DateCoordinationSource = datecoordinationsource;
		DateConstruction = dateconstruction;
		State = state;
		CoordinatedLatitude = coordinatedLatitude;
		CoordinatedLongitude = coordinatedLongitude;
		CoordinatedOutputPower = coordinatedOutputPower;
		CoordinatedAntennaHeight = coordinatedAntennaHeight;
		Note = note;
}

	public void Save(Credentials credentials, Repeater originalRepeater)
	{
		try
		{
			ChangeLog = CreateChangeLog(credentials, originalRepeater);

			callsign = credentials.Username;
			password = credentials.Password;
			DateUpdated = DateTime.UtcNow.ToString();

			string url = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "UpdateRepeater";
			string result = Utilities.PostJsonToUrl(url, this);
		}
		catch (Exception ex)
		{
			password = "**********";
			new ExceptionReport(ex, "Exception thrown while trying to update repeater details", JsonConvert.SerializeObject(this));
		}

	}

	private string CreateChangeLog(Credentials credentials, Repeater oldRepeater)
	{
		string strReturn = "";

		// only use public properties
		foreach (FieldInfo fieldInfo in typeof(Repeater).GetFields())
		{
			if (fieldInfo.IsPublic)
			{
				object oldValue = fieldInfo.GetValue(oldRepeater);
				object newValue = fieldInfo.GetValue(this);

				if (oldValue == null)
				{
					oldValue = "";
				}

				string fieldInfoName = fieldInfo.Name;
				string oldValueToString = oldValue.ToString();
				string newValueToString = newValue.ToString();

				if (fieldInfo.Name == "Status")
				{
					oldValueToString = GetRepeaterStatusDescription(oldValue.ToString());
					newValueToString = GetRepeaterStatusDescription(newValue.ToString());
				}

				if (fieldInfoName == "Autopatch")
				{
					oldValueToString = GetRepeaterAutopatchDescription(oldValue.ToString());
					newValueToString = GetRepeaterAutopatchDescription(newValue.ToString());
				}

				string[] strArrDontNotate = { "DateUpdated", "Note", "TrusteeID" };

				if (!object.Equals(oldValue, newValue)) {
					if (!strArrDontNotate.Any(fieldInfo.Name.Contains))
					{
						strReturn += String.Format(" • {0} was changed from `{1}` to `{2}`\r\n", fieldInfoName, oldValueToString, newValueToString);
					}
				}
			}
		}

		string spacing = "";
		if ((strReturn != string.Empty) && (Note.Trim() != string.Empty))
		{
			spacing = "\r\n\r\n";
		}
		strReturn = Note + spacing + strReturn;

		return strReturn;
	}

	public void Sterilize()
	{
		callsign = "";
		password = "";
		Latitude = Latitude.Substring(0, Latitude.IndexOf('.')) + "xxxx";
		Longitude = Longitude.Substring(0, Longitude.IndexOf('.')) + "xxxx";
	}

	public string GetRepeaterStatusDescription(string statusID)
	{
		string strStatus = string.Empty;
		switch (statusID)
		{
			case "1":
				strStatus = "Proposed";
				break;
			case "2":
				strStatus = "Under construction";
				break;
			case "3":
				strStatus = "Operational";
				break;
			case "4":
				strStatus = "Temporarily off-the-air";
				break;
			case "5":
				strStatus = "Suspected off-the-air";
				break;
			case "6":
				strStatus = "De-coordinated";
				break;
			default:
				break;
		}
		return strStatus;
	}

	public string GetRepeaterAutopatchDescription(string autopatch)
	{
		string strDesc = string.Empty;
		switch (autopatch)
		{
			case "0":
				strDesc = "None";
				break;
			case "1":
				strDesc = "Open";
				break;
			case "3":
				strDesc = "Closed";
				break;
			default:
				break;
		}
		return strDesc;
	}
}