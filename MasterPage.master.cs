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
			Response.Cookies.Remove("login");
			Response.Redirect("~/");
		}
	}
}
