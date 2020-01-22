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

            HttpCookie oatmeal = Request.Cookies["oatmeal"];
            if ((oatmeal != null) && (oatmeal.Value == "1"))
            {
                lbCoordination.Visible = false;
                lbNopc.Visible = true;
            }

            HttpCookie peanutbutter = Request.Cookies["peanutbutter"];
			if ((peanutbutter != null) && (peanutbutter.Value == "1"))
			{
				pnlAdminAndReportLinks.Visible = true;
			}

			HttpCookie chocolatechip = Request.Cookies["chocolatechip"];
			if ((chocolatechip != null) && (chocolatechip.Value == "1"))
			{
				pnlAdminAndReportLinks.Visible = true;
				pnlAdminLinks.Visible = true;
			}
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
			String[] snackbag = { "login", "peanutbutter", "chocolatechip" };

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


			Response.Redirect("~/");
		}
	}
}
