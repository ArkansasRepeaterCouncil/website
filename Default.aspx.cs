using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string urlKey = Request.QueryString["nopc"];
		if ((urlKey != null) && (urlKey != ""))
		{
			Response.Redirect("~/nopc/?nopc=" + urlKey);
		}
	}
}