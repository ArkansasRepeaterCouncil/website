using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Request.IsLocal && !Request.IsSecureConnection)
		{
			string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
			Response.Redirect(redirectUrl, false);
			HttpContext.Current.ApplicationInstance.CompleteRequest();
		}

        HttpCookie hc = Request.Cookies["login"];
		if ((hc != null) && (hc.Value != string.Empty))
		{
			lbLogin.Text = "Logout";
			pnlLoggedInNav.Visible = true;

            HttpCookie isExternalCoordinator = Request.Cookies["oatmeal"];
            if ((isExternalCoordinator != null) && (isExternalCoordinator.Value == "1"))
            {
                lblCoordination.Visible = false;
                lblNopc.Visible = true;
            }

            HttpCookie isReportViewer = Request.Cookies["peanutbutter"];
			if ((isReportViewer != null) && (isReportViewer.Value == "1"))
			{
				pnlAdminAndReportLinks.Visible = true;
			}

			HttpCookie isAdmin = Request.Cookies["chocolatechip"];
			if ((isAdmin != null) && (isAdmin.Value == "1"))
			{
				pnlAdminAndReportLinks.Visible = true;
			}
		}
		string stateAbbr = Utilities.StateToDisplay;
        string siteName = Utilities.GetStateNameByAbbr(stateAbbr) + " Repeater Council";
		Page.Title = siteName;
        lblHeaderTitle.Text = siteName;

		switch (stateAbbr.ToUpper())
		{
			case "AR":
                lblChatScript.Text = "<script src=\"https://embed.small.chat/TCD7HSEEAGJ6ET8ZLL.js\" async></script>";
				break;
			case "AL":
                lblAboutLink.Visible = false;
				lblChatScript.Text = "<script src=\"https://embed.small.chat/T04LVU5GT8BC04LT4SKDGD.js\" async></script>";
                break;
            default:
				break;
		}

    }

	protected void lbLogin_Click(object sender, EventArgs e)
	{
		HttpCookie hc = Request.Cookies["login"];

		if ((hc == null) || (hc.Value == string.Empty))
		{
			Response.Redirect("~/Login.aspx");
		}
		else
		{
			// They want to logout
			String[] snackbag = { "login", "peanutbutter", "chocolatechip", "oatmeal" };

			foreach (string cheese in snackbag) // See what I did there? And yes... I am drinking.
			{
				HttpCookie cookie = HttpContext.Current.Request.Cookies[cheese];
				if (cookie != null)
				{
					cookie.Expires = DateTime.Now.AddDays(-1);
					cookie.Value = null;
					HttpContext.Current.Response.SetCookie(cookie);
				}
			}

			// Side note from me six years later: What the hell was I thinking? I have no idea why I named the array "snackbag". I guess I was hungry. 
			// Or maybe I just thought it was funny. Either way, it has stuck around for years now, and I'm not about to change it.	

			Response.Redirect("~/");
		}
	}
}
