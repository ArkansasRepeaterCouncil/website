using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RepeaterOfflineReport
/// </summary>
public class RepeaterOfflineReport
{
	private Credentials credentials;
	private int RepeaterID;

	public RepeaterOfflineReport(Credentials creds, int repeaterId)
	{
		credentials = creds;
		RepeaterID = repeaterId;

		try
		{
			using (var webClient = new System.Net.WebClient())
			{
				string note = "*Repeater reported to be off-the-air*";
				string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "AddRepeaterNote?callsign={0}&password={1}&repeaterid={2}&note={3}", creds.Username, creds.Password, repeaterId, note);
				string json = webClient.DownloadString(url);
			}
		}
		catch (Exception ex)
		{
			new ExceptionReport(ex, "Exception thrown while trying to report repeater offline");
		}
	}
}