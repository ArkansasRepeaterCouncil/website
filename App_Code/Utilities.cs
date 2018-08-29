using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for Utilities
/// </summary>
public static class Utilities
{
	public static string Base64Encode(string plainText)
	{
		var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
		return System.Convert.ToBase64String(plainTextBytes);
	}

	public static string Base64Decode(string base64EncodedData)
	{
		var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
		return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
	}

	public static Credentials GetExistingCredentials()
	{
		Credentials outputCreds = new Credentials();

		HttpCookie hc = HttpContext.Current.Request.Cookies["login"];
		if ((hc != null) && (hc.Value != string.Empty))
		{
			outputCreds = new Credentials(hc.Value);
		}
		else
		{
			HttpContext.Current.Response.Redirect("~/Login.aspx");
		}

		return outputCreds;
	}

	public static void getValueIfNotNull(object val, string prefixString, List<string> arr)
	{
		if ((val is int) && ((int)val == 1))
		{
			arr.Add(prefixString + val);
		}
		else if ((val is decimal) && ((decimal)val != 0))
		{
			arr.Add(prefixString + val);
		}
		else if (val != null)
		{
			arr.Add(prefixString + val);
		}
	}

	public static void getNameIfNotNull(object val, string name, List<string> arr)
	{
		bool boolVal = false;
		if ((Boolean.TryParse(val.ToString(), out boolVal)) && (boolVal))
		{
			arr.Add(name);
		}
	}

	public static string PostJsonToUrl(string url, object objToSend)
	{
		string result = "";

		var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
		httpWebRequest.ContentType = "application/json";
		httpWebRequest.Method = "POST";

		using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			string json = JsonConvert.SerializeObject(objToSend);

			streamWriter.Write(json);
			System.Diagnostics.Debug.Write(json);
		}

		var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
		{
			result = streamReader.ReadToEnd();
		}

		return result;
	}
}