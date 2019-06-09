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
					Response.Redirect(hc.Value);
					Response.Cookies.Remove("redirectAfterLogin");
				}
				else
				{
					Response.Redirect("/Dashboard/");
				}
			}
		}
	}
}