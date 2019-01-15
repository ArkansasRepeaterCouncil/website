using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[Serializable]
public class ExceptionReport
{
	[JsonProperty]
	private string url;
	[JsonProperty]
	private string querystring;
	[JsonProperty]
	private string message;
	[JsonProperty]
	private string source;
	[JsonProperty]
	private string stacktrace;

	public ExceptionReport(Exception ex)
	{
		url = HttpContext.Current.Request.Url.ToString();
		querystring = HttpContext.Current.Request.QueryString.ToString();
		message = ex.Message;
		source = ex.Source;
		stacktrace = ex.StackTrace;

		string serviceUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "LogError";
		string result = Utilities.PostJsonToUrl(serviceUrl, this);
	}
}