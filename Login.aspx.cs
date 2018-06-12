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
			string parameters = "callsign=" + login1.UserName + "&password=" + login1.Password;
			string json = webClient.DownloadString(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "DoLogin?" + parameters);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			if (data[0].Return = 1)
			{
				e.Authenticated = true;
				if (login1.RememberMeSet)
				{
					HttpCookie ckUser = new HttpCookie("callsign", login1.UserName);
					HttpCookie ckPass = new HttpCookie("password", login1.Password);
					ckUser.Expires = DateTime.Now.AddDays(30);
					ckPass.Expires = DateTime.Now.AddDays(30);
				}
			}
			else
			{
				e.Authenticated = false;
			}

			if (e.Authenticated)
			{
				Response.Redirect("/Dashboard/");
			}
		}
	}
}