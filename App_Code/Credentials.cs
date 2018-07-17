using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Credentials
/// </summary>
public class Credentials
{
	public string Username;
	public string Password;
	public bool Valid;

	public Credentials()
	{
		Username = "";
		Password = "";
		Valid = false;
	}
	public Credentials(string username, string password)
	{
		Username = username;
		Password = password;
		Valid = true;
	}
	public Credentials(string base64EncodedString)
	{
		string decodedString = Utilities.Base64Decode(base64EncodedString);
		string[] delimiter = { "|" };
		string[] strArr = decodedString.Split(delimiter, 2, StringSplitOptions.None);
		Username = strArr[0];
		Password = strArr[1];
		Valid = true;
	}
}