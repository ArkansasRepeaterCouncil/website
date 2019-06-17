using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void login1_Authenticate(object sender, AuthenticateEventArgs e)
	{
		using (var webClient = new System.Net.WebClient())
		{
			string username = login1.UserName.Trim();
			string password = login1.Password.Trim();

			string parameters = string.Format("callsign={0}&password={1}", username, password);
			string strUrl = string.Format("{0}{1}{2}", System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"], "DoLogin?", parameters);
			string json = webClient.DownloadString(strUrl);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			if ((int)data[0].Return == 1)
			{
				e.Authenticated = true;

				HttpCookie ckLogin = new HttpCookie("login", Utilities.Base64Encode(username + "|" + password));
				if (login1.RememberMeSet)
				{
					ckLogin.Expires = DateTime.Now.AddDays(364);
				}
				Response.Cookies.Add(ckLogin);

				if ((int)data[0].isReportViewer == 1)
				{
					HttpCookie peanutbutter = new HttpCookie("peanutbutter", "1");
					Response.Cookies.Add(peanutbutter);
				}

				if ((int)data[0].isAdmin == 1)
				{
					HttpCookie chocolatechip = new HttpCookie("chocolatechip", "1");
					Response.Cookies.Add(chocolatechip);
				}


			}
			else
			{
				e.Authenticated = false;
			}

			if (e.Authenticated)
			{
				HttpCookie hc = HttpContext.Current.Request.Cookies["redirectAfterLogin"];
				if ((hc != null) && (hc.Value != string.Empty))
				{
					string url = hc.Value;

					HttpCookie cookie = HttpContext.Current.Request.Cookies["redirectAfterLogin"];
					cookie.Expires = DateTime.Now.AddDays(-1);
					cookie.Value = null;
					HttpContext.Current.Response.SetCookie(cookie);

					Response.Redirect(url);
				}
				else
				{
					if ((int)data[0].profileIncomplete == 1)
					{
						Response.Redirect("/profile/?ip=1");
					}
					else
					{
						Response.Redirect("/Dashboard/");
					}
				}
			}
		}
	}
}