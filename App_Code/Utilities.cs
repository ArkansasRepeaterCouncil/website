using Newtonsoft.Json;
using Octokit;
using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Utilities
/// </summary>
public static class Utilities
{
    #region Specific to repeater council

    private static string stateToDisplay;

    public static string StateToDisplay
    {
        get
        {
            if (stateToDisplay == null || stateToDisplay == string.Empty)
            {
                HttpCookie hcState = HttpContext.Current.Request.Cookies["state"];

                if (hcState == null || hcState.Value == null || hcState.Value == string.Empty)
                {
                    string domainName = HttpContext.Current.Request.Url.DnsSafeHost.ToLower();
                    switch (domainName)
                    {
                        case "al.repeatercouncil.org":
                        case "localhost":
                            stateToDisplay = "AL";
                            break;
                        default:
                            stateToDisplay = "AR";
                            break;
                    }

                    HttpCookie newState = new HttpCookie("state", stateToDisplay);
                    newState.Expires = DateTime.Now.AddDays(364);
                    HttpContext.Current.Response.Cookies.Add(newState);
                }
                else
                {
                    stateToDisplay = hcState.Value;

                }
            }

            return stateToDisplay;

        }
    }
    #endregion

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
            HttpCookie redirectCookie = new HttpCookie("redirectAfterLogin", HttpContext.Current.Request.Url.ToString());
            redirectCookie.Expires = DateTime.Now.AddDays(364);
            HttpContext.Current.Response.Cookies.Add(redirectCookie);
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

        //try
        //{
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = JsonConvert.SerializeObject(objToSend);

            streamWriter.Write(json);
            System.Diagnostics.Debug.WriteLine(json);
        }

        //try
        //{
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
        //	}
        //	catch (Exception ex)
        //	{
        //		new ExceptionReport(ex, "Exception thrown while trying to post JSON to url", "URL: " + url);
        //	}

        //}
        //catch (Exception ex)
        //{
        //	new ExceptionReport(ex, "Exception thrown while trying to post JSON to url", "URL: " + url);
        //}

        return result;
    }

    public static string GetResponseFromUrl(string url)
    {
        string result = "";

        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.Method = "GET";
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

        try
        {
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
        }
        catch (WebException ex)
        {
            string safeUrl = url;
            if (safeUrl.Contains("?"))
            {
                safeUrl = safeUrl.Substring(0, safeUrl.IndexOf('?'));
            }
            new ExceptionReport(ex, "Exception thrown while trying to get content from URL", "URL: " + safeUrl);
            throw ex;
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

    public static void AddCell(string cellContents)
    {
        System.Web.UI.WebControls.TableCell cell = new System.Web.UI.WebControls.TableCell();
        cell.Text = cellContents;
    }

    public static void AddCell(this System.Web.UI.WebControls.TableRow row, string cellContents)
    {
        System.Web.UI.WebControls.TableCell cell = new System.Web.UI.WebControls.TableCell();
        cell.Text = cellContents;
        row.Cells.Add(cell);
    }

    public static void AddCell(this System.Web.UI.WebControls.TableRow row, string cellContents, int colSpan)
    {
        System.Web.UI.WebControls.TableCell cell = new System.Web.UI.WebControls.TableCell();
        cell.Text = cellContents;
        cell.ColumnSpan = colSpan;
        row.Cells.Add(cell);
    }

    public static void AddCell(this System.Web.UI.WebControls.TableRow row, string cellContents, string cssClass)
    {
        System.Web.UI.WebControls.TableCell cell = new System.Web.UI.WebControls.TableCell();
        cell.Text = cellContents;
        cell.CssClass = cssClass;
        row.Cells.Add(cell);
    }

    public static void AddCell(this System.Web.UI.WebControls.TableRow row, string cellContents, string cssClass, int colSpan)
    {
        System.Web.UI.WebControls.TableCell cell = new System.Web.UI.WebControls.TableCell();
        cell.Text = cellContents;
        cell.CssClass = cssClass;
        cell.ColumnSpan = colSpan;
        row.Cells.Add(cell);
    }

    public static string CreateMapUrl(params string[] pointsToShow)
    {
        string centerPoint = "34.6884554,-93.5156763";
        string zoomLevel = "7.44";

        string ret = "https://www.google.com/maps/dir/";
        for (int i = 0; i < pointsToShow.Length; i++)
        {
            ret += pointsToShow[i] + "/";
        }
        ret += string.Format("/@{0},{1}z", centerPoint, zoomLevel);

        return ret;
    }

    public static string GetState(State state)
    {
        switch (state)
        {
            case State.AL:
                return "ALABAMA";

            case State.AK:
                return "ALASKA";

            case State.AS:
                return "AMERICAN SAMOA";

            case State.AZ:
                return "ARIZONA";

            case State.AR:
                return "ARKANSAS";

            case State.CA:
                return "CALIFORNIA";

            case State.CO:
                return "COLORADO";

            case State.CT:
                return "CONNECTICUT";

            case State.DE:
                return "DELAWARE";

            case State.DC:
                return "DISTRICT OF COLUMBIA";

            case State.FM:
                return "FEDERATED STATES OF MICRONESIA";

            case State.FL:
                return "FLORIDA";

            case State.GA:
                return "GEORGIA";

            case State.GU:
                return "GUAM";

            case State.HI:
                return "HAWAII";

            case State.ID:
                return "IDAHO";

            case State.IL:
                return "ILLINOIS";

            case State.IN:
                return "INDIANA";

            case State.IA:
                return "IOWA";

            case State.KS:
                return "KANSAS";

            case State.KY:
                return "KENTUCKY";

            case State.LA:
                return "LOUISIANA";

            case State.ME:
                return "MAINE";

            case State.MH:
                return "MARSHALL ISLANDS";

            case State.MD:
                return "MARYLAND";

            case State.MA:
                return "MASSACHUSETTS";

            case State.MI:
                return "MICHIGAN";

            case State.MN:
                return "MINNESOTA";

            case State.MS:
                return "MISSISSIPPI";

            case State.MO:
                return "MISSOURI";

            case State.MT:
                return "MONTANA";

            case State.NE:
                return "NEBRASKA";

            case State.NV:
                return "NEVADA";

            case State.NH:
                return "NEW HAMPSHIRE";

            case State.NJ:
                return "NEW JERSEY";

            case State.NM:
                return "NEW MEXICO";

            case State.NY:
                return "NEW YORK";

            case State.NC:
                return "NORTH CAROLINA";

            case State.ND:
                return "NORTH DAKOTA";

            case State.MP:
                return "NORTHERN MARIANA ISLANDS";

            case State.OH:
                return "OHIO";

            case State.OK:
                return "OKLAHOMA";

            case State.OR:
                return "OREGON";

            case State.PW:
                return "PALAU";

            case State.PA:
                return "PENNSYLVANIA";

            case State.PR:
                return "PUERTO RICO";

            case State.RI:
                return "RHODE ISLAND";

            case State.SC:
                return "SOUTH CAROLINA";

            case State.SD:
                return "SOUTH DAKOTA";

            case State.TN:
                return "TENNESSEE";

            case State.TX:
                return "TEXAS";

            case State.UT:
                return "UTAH";

            case State.VT:
                return "VERMONT";

            case State.VI:
                return "VIRGIN ISLANDS";

            case State.VA:
                return "VIRGINIA";

            case State.WA:
                return "WASHINGTON";

            case State.WV:
                return "WEST VIRGINIA";

            case State.WI:
                return "WISCONSIN";

            case State.WY:
                return "WYOMING";
        }

        throw new Exception("Not Available");
    }

    public static State GetStateByName(string name)
    {
        switch (name.ToUpper())
        {
            case "ALABAMA":
                return State.AL;

            case "ALASKA":
                return State.AK;

            case "AMERICAN SAMOA":
                return State.AS;

            case "ARIZONA":
                return State.AZ;

            case "ARKANSAS":
                return State.AR;

            case "CALIFORNIA":
                return State.CA;

            case "COLORADO":
                return State.CO;

            case "CONNECTICUT":
                return State.CT;

            case "DELAWARE":
                return State.DE;

            case "DISTRICT OF COLUMBIA":
                return State.DC;

            case "FEDERATED STATES OF MICRONESIA":
                return State.FM;

            case "FLORIDA":
                return State.FL;

            case "GEORGIA":
                return State.GA;

            case "GUAM":
                return State.GU;

            case "HAWAII":
                return State.HI;

            case "IDAHO":
                return State.ID;

            case "ILLINOIS":
                return State.IL;

            case "INDIANA":
                return State.IN;

            case "IOWA":
                return State.IA;

            case "KANSAS":
                return State.KS;

            case "KENTUCKY":
                return State.KY;

            case "LOUISIANA":
                return State.LA;

            case "MAINE":
                return State.ME;

            case "MARSHALL ISLANDS":
                return State.MH;

            case "MARYLAND":
                return State.MD;

            case "MASSACHUSETTS":
                return State.MA;

            case "MICHIGAN":
                return State.MI;

            case "MINNESOTA":
                return State.MN;

            case "MISSISSIPPI":
                return State.MS;

            case "MISSOURI":
                return State.MO;

            case "MONTANA":
                return State.MT;

            case "NEBRASKA":
                return State.NE;

            case "NEVADA":
                return State.NV;

            case "NEW HAMPSHIRE":
                return State.NH;

            case "NEW JERSEY":
                return State.NJ;

            case "NEW MEXICO":
                return State.NM;

            case "NEW YORK":
                return State.NY;

            case "NORTH CAROLINA":
                return State.NC;

            case "NORTH DAKOTA":
                return State.ND;

            case "NORTHERN MARIANA ISLANDS":
                return State.MP;

            case "OHIO":
                return State.OH;

            case "OKLAHOMA":
                return State.OK;

            case "OREGON":
                return State.OR;

            case "PALAU":
                return State.PW;

            case "PENNSYLVANIA":
                return State.PA;

            case "PUERTO RICO":
                return State.PR;

            case "RHODE ISLAND":
                return State.RI;

            case "SOUTH CAROLINA":
                return State.SC;

            case "SOUTH DAKOTA":
                return State.SD;

            case "TENNESSEE":
                return State.TN;

            case "TEXAS":
                return State.TX;

            case "UTAH":
                return State.UT;

            case "VERMONT":
                return State.VT;

            case "VIRGIN ISLANDS":
                return State.VI;

            case "VIRGINIA":
                return State.VA;

            case "WASHINGTON":
                return State.WA;

            case "WEST VIRGINIA":
                return State.WV;

            case "WISCONSIN":
                return State.WI;

            case "WYOMING":
                return State.WY;
        }

        throw new Exception("Not Available");
    }

    public static string GetStateNameByAbbr(string abbreviation)
    {
        switch (abbreviation.ToUpper())
        {
            case "AL":
                return "Alabama";

            case "AK":
                return "Alaska";

            case "AS":
                return "American Samoa";

            case "AZ":
                return "Arizona";

            case "AR":
                return "Arkansas";

            case "CA":
                return "California";

            case "CO":
                return "Colorado";

            case "CT":
                return "Connecticut";

            case "DE":
                return "Delaware";

            case "DC":
                return "District of Columbia";

            case "FM":
                return "Federated States of Micronesia";

            case "FL":
                return "Florida";

            case "GA":
                return "Georgia";

            case "GU":
                return "Guam";

            case "HI":
                return "Hawaii";

            case "ID":
                return "Idaho";

            case "IL":
                return "Illinois";

            case "IN":
                return "Indiana";

            case "IA":
                return "Iowa";

            case "KS":
                return "Kansas";

            case "KY":
                return "Kentucky";

            case "LA":
                return "Louisiana";

            case "ME":
                return "Maine";

            case "MH":
                return "Marshall Islands";

            case "MD":
                return "Maryland";

            case "MA":
                return "Massachusetts";

            case "MI":
                return "Michigan";

            case "MN":
                return "Minnesota";

            case "MS":
                return "Mississippi";

            case "MO":
                return "Missouri";

            case "MT":
                return "Montana";

            case "NE":
                return "Nebraska";

            case "NV":
                return "Nevada";

            case "NH":
                return "New Hampshire";

            case "NJ":
                return "New Jersey";

            case "NM":
                return "New Mexico";

            case "NY":
                return "New York";

            case "NC":
                return "North Carolina";

            case "ND":
                return "North Dakota";

            case "MP":
                return "Northern Mariana Islands";

            case "OH":
                return "Ohio";

            case "OK":
                return "Oklahoma";

            case "OR":
                return "Oregon";

            case "PW":
                return "Palau";

            case "PA":
                return "Pennsylvania";

            case "PR":
                return "Puerto Rico";

            case "RI":
                return "Rhode Island";

            case "SC":
                return "South Carolina";

            case "SD":
                return "South Dakota";

            case "TN":
                return "Tennessee";

            case "TX":
                return "Texas";

            case "UT":
                return "Utah";

            case "VT":
                return "Vermont";

            case "VI":
                return "Virgin Islands";

            case "VA":
                return "Virginia";

            case "WA":
                return "Washington";

            case "WV":
                return "West Virginia";

            case "WI":
                return "Wisconsin";

            case "WY":
                return "Wyoming";

            default:
                return "";
        }
    }

    public enum State
    {
        AL,
        AK,
        AS,
        AZ,
        AR,
        CA,
        CO,
        CT,
        DE,
        DC,
        FM,
        FL,
        GA,
        GU,
        HI,
        ID,
        IL,
        IN,
        IA,
        KS,
        KY,
        LA,
        ME,
        MH,
        MD,
        MA,
        MI,
        MN,
        MS,
        MO,
        MT,
        NE,
        NV,
        NH,
        NJ,
        NM,
        NY,
        NC,
        ND,
        MP,
        OH,
        OK,
        OR,
        PW,
        PA,
        PR,
        RI,
        SC,
        SD,
        TN,
        TX,
        UT,
        VT,
        VI,
        VA,
        WA,
        WV,
        WI,
        WY
    }
}
