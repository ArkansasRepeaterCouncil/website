using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl.Text = string.Empty;
        lbl.Text += "Utilities.StateToDisplay : " + Utilities.StateToDisplay + "<br>";

        HttpCookie hcState = HttpContext.Current.Request.Cookies["state"];

        lbl.Text += "HttpContext.Current.Request.Cookies[\"state\"] : " + hcState.Value + "<br>";

        string domainName = HttpContext.Current.Request.Url.DnsSafeHost.ToLower();

        lbl.Text += "HttpContext.Current.Request.Url.DnsSafeHost.ToLower() : " + domainName + "<br>";

        string stateToDisplay = "";
        switch (domainName)
        {
            case "al.repeatercouncil.org":
            case "alabama.repeatercouncil.org":
            case "localhost":
                stateToDisplay = "AL";
                break;
            default:
                stateToDisplay = "AR";
                break;
        }

        lbl.Text += "stateToDisplay : " + stateToDisplay + "<br>";
    }
}