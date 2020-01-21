using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CoordinationRequest
/// </summary>
public class CoordinationRequest
{
	public string Latitude;
	public string Longitude;
	public string OutputPower;
	public string Altitude;
	public string AntennaHeight;
	public string OutputFrequency;
	public string callsign;
	public string password;


	public CoordinationRequest(string latitude, string longitude, string outputPower, string altitude, string antennaHeight, string outputFrequency, Credentials creds)
	{
		Latitude = latitude;
		Longitude = longitude;
		OutputPower = outputPower;
		Altitude = altitude;
		AntennaHeight = antennaHeight;
		OutputFrequency = outputFrequency;
		callsign = creds.Username;
		password = creds.Password;
	}

    public void Save()
	{
		string url = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "CreateRequest";
		string result = Utilities.PostJsonToUrl(url, this);
	}
}