using Newtonsoft.Json;
using System;
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

	public int ID;
	public string Type;
	public string RepeaterCallsign;
	public string TrusteeID;
	public string Status;
	public string City;
	public string SiteName;
	public string OutputFrequency;
	public string InputFrequency;
	public string Sponsor;
	public string Latitude;
	public string Longitude;
	public string AMSL;
	public string ERP;
	public string OutputPower;
	public string AntennaGain;
	public string AntennaHeight;
	public string Analog_InputAccess;
	public string Analog_OutputAccess;
	public string Analog_Width;
	public string DSTAR_Module;
	public string DMR_ColorCode;
	public string DMR_ID;
	public string DMR_Network;
	public string P25_NAC;
	public string NXDN_RAN;
	public string YSF_DSQ;
	public string Autopatch;
	public bool EmergencyPower;
	public bool Linked;
	public bool RACES;
	public bool ARES;
	public bool WideArea;
	public bool Weather;
	public bool Experimental;
	public string DateCoordinated;
	public string DateUpdated;
	public string DateDecoordinated;
	public string DateCoordinationSource;
	public string DateConstruction;
	public string CoordinatorComments;
	public string Notes;
	public string State;
	[JsonProperty]
	private string ChangeLog;
	[JsonProperty]
	private string callsign;
	[JsonProperty]
	private string password;

	public static Repeater Load(Credentials credentials, string repeaterId)
	{
		// Call web service to get all data for the repeater with this ID
		Repeater repeater;
		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetRepeaterDetails?callsign={0}&password={1}&repeaterid={2}", credentials.Username, credentials.Password, repeaterId);
			string json = webClient.DownloadString(url);
			repeater = JsonConvert.DeserializeObject<Repeater>(json);
		}
		return repeater;
	}

	public Repeater()
	{
		
	}

	public Repeater(string id, string type, string callsign, string trusteeid, string status, string city, string sitename, string outputfrequency, string inputfrequency, string sponsor, string latitude, string longitude, string amsl, string erp, string outputpower, string antennagain, string antennaheight, string analog_inputaccess, string analog_outputaccess, string analog_width, string dstar_module, string dmr_colorcode, string dmr_id, string dmr_network, string p25_nac, string nxdn_ran, string ysf_dsq, string autopatch, bool emergencypower, bool linked, bool races, bool ares, bool widearea, bool weather, bool experimental, string datecoordinated, string dateupdated, string datedecoordinated, string datecoordinationsource, string dateconstruction, string coordinatorcomments, string notes, string state)
	{
		ID = int.Parse(id);
		Type = type;
		RepeaterCallsign = callsign;
		TrusteeID = trusteeid;
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
		CoordinatorComments = coordinatorcomments;
		Notes = notes;
		State = state;
	}

	public void Save(Credentials credentials, Repeater originalRepeater)
	{
		ChangeLog = CreateChangeLog(credentials, originalRepeater);
		callsign = credentials.Username;
		password = credentials.Password;
		DateUpdated = DateTime.UtcNow.ToString();

		string url = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "UpdateRepeater";
		string result = Utilities.PostJsonToUrl(url, this);
	}

	private string CreateChangeLog(Credentials credentials, Repeater oldRepeater)
	{
		//Type thisType = this.GetType();
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

				if (!object.Equals(oldValue, newValue))
				{
					strReturn += String.Format("• {0} was changed from `{1}` to `{2}`\r\n", fieldInfo.Name, oldValue.ToString(), newValue.ToString());
				}
			}
		}

		if (strReturn != string.Empty)
		{
			strReturn = String.Format("{0} made the following change(s):\r\n{1}", credentials.Username.ToUpper(), strReturn);
		}

		return strReturn;
	}
}