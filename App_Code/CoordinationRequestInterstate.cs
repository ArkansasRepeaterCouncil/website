using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CoordinationRequest
/// </summary>
public class CoordinationRequestInterstate
{
	public string Latitude;
	public string Longitude;
	public string TransmitFrequency;
    public string ReceiveFrequency;
    public string callsign;
	public string password;


	public CoordinationRequestInterstate(string latitude, string longitude, string transmitFrequency, string receiveFrequency, Credentials creds)
	{
		Latitude = latitude;
		Longitude = longitude;
        TransmitFrequency = transmitFrequency;
        ReceiveFrequency = receiveFrequency;
		callsign = creds.Username;
		password = creds.Password;
	}

    public CoordinationRequestInterstateAnswer Save()
    {
        string url = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ProposedCoordination";
        string result = Utilities.PostJsonToUrl(url, this);
        CoordinationRequestInterstateAnswer answer = Newtonsoft.Json.JsonConvert.DeserializeObject<CoordinationRequestInterstateAnswer>(result);
        return answer;
    }
}