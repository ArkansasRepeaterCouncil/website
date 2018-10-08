using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequestUpdate
/// </summary>
[Serializable]
public class RequestUpdate
{
	public string UrlKey;
	public string statusId;
	public string note;

	public RequestUpdate(string urlkey, string statusid, string Note)
	{
		UrlKey = urlkey;
		statusId = statusid;
		note = Note;
	}

	public void Save()
	{
		string url = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "UpdateCoordinationRequestWorkflowStep";
		string result = Utilities.PostJsonToUrl(url, this);
	}
}