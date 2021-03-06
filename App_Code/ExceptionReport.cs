﻿using Newtonsoft.Json;
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
	[JsonProperty]
	private string additionalData;
	[JsonIgnore]
	public string IssueURL;
	[JsonIgnore]
	public string InnerExceptionMessage;
	[JsonIgnore]
	public Issue issue;

	public ExceptionReport(Exception ex)
	{
		url = HttpContext.Current.Request.Url.ToString();
		if (!url.StartsWith("http://localhost:"))
		{
			querystring = HttpContext.Current.Request.QueryString.ToString();
			message = ex.Message;
			source = ex.Source;
			stacktrace = ex.StackTrace;
			InnerExceptionMessage = ex.InnerException.Message;

			string serviceUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "LogError";
			string result = Utilities.PostJsonToUrl(serviceUrl, this);

			issue = new Issue(ex);
		}
	}

	public ExceptionReport(Exception ex, string context, params string[] addlData)
	{
		url = HttpContext.Current.Request.Url.ToString();
		if (url.StartsWith("http://localhost:"))
		{
			querystring = HttpContext.Current.Request.QueryString.ToString();
			message = ex.Message;
			source = ex.Source;
			stacktrace = ex.StackTrace;
			InnerExceptionMessage = ex.Message;

			for (int x = 0; x < addlData.Length; x++)
			{
				additionalData += addlData[x];
				if (x + 1 < addlData.Length)
				{
					additionalData += "\r\n";
				}
			}

			string serviceUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "LogError";
			string result = Utilities.PostJsonToUrl(serviceUrl, this);

			Issue issue = new Issue(ex);
			for (int x = 0; x < addlData.Length; x++)
			{
				issue.body += "\r\n\r\n" + addlData[x];
			}
			issue.title = context;
			issue = new Issue(ex);
		}
	}
}