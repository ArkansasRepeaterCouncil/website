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

	public static void GetValueIfNotNull(object val, string prefixString, List<string> arr)
	{
		if ((val is int) && ((int)val == 1))
		{
			arr.Add(prefixString + val);
		}
		else if ((val is decimal) && ((decimal)val != 0))
		{
			arr.Add(prefixString + val);
		}
		else if ((val is string) && ((string)val != ""))
		{
			arr.Add(prefixString + val);
		}
		else if (val != null)
		{
			arr.Add(prefixString + val);
		}
	}

	public static void GetNameIfNotNull(object val, string name, List<string> arr)
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

		try
		{
			var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";

			using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string json = JsonConvert.SerializeObject(objToSend);

				streamWriter.Write(json);
				System.Diagnostics.Debug.WriteLine(json);
			}

			try
			{
				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					result = streamReader.ReadToEnd();
				}
			}
			catch (Exception ex)
			{
				new ExceptionReport(ex, "Exception thrown while trying to post JSON to url", "URL: " + url);
			}

		}
		catch (Exception ex)
		{
			new ExceptionReport(ex, "Exception thrown while trying to post JSON to url", "URL: " + url);
		}

		return result;
	}

	public static string GetResponseFromUrl(string url)
	{
		string result = "";

		try
		{
			var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "GET";

			var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			{
				result = streamReader.ReadToEnd();
			}
		}
		catch (Exception ex)
		{
			new ExceptionReport(ex, "Exception thrown while trying to get content from URL");
			// throw ex;
		}

		return result;
	}

	public static string GetMaskedString(string stringToMask)
	{
		var firstPart = stringToMask.Substring(0, 2);
		var lastPart = stringToMask.Substring(stringToMask.IndexOf("@"), stringToMask.Length - stringToMask.IndexOf("@"));
		var mask = new String('*', stringToMask.Length - firstPart.Length - lastPart.Length);
		var maskedString = string.Concat(firstPart, mask, lastPart);
		return maskedString;
	}
}