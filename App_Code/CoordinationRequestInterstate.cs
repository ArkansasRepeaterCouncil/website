using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CoordinationRequest
/// </summary>
public class CoordinationRequestInterstate
{
	public decimal Latitude;
	public decimal Longitude;
	public decimal TransmitFrequency;
    public decimal ReceiveFrequency;
    public string callsign;
	public string password;


	public CoordinationRequestInterstate(string latitude, string longitude, string transmitFrequency, string receiveFrequency, Credentials creds)
	{
		Latitude = decimal.Parse(latitude);
		Longitude = decimal.Parse(longitude);
        TransmitFrequency = decimal.Parse(transmitFrequency);
        ReceiveFrequency = decimal.Parse(receiveFrequency);
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