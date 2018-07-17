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

			if ((int)data[0].Return == 1)
			{
				e.Authenticated = true;

				HttpCookie ckLogin = new HttpCookie("login", Utilities.Base64Encode(login1.UserName + "|" + login1.Password));
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
				Response.Redirect("/Dashboard/");
			}
		}
	}
}