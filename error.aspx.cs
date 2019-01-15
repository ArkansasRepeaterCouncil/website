using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class error : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["exception"] != null)
		{
			try
			{
				Exception ex = (Exception)Session["exception"];
				lblDetails.Text = ex.InnerException.Message;
			}
			catch
			{
				
			}
		}
	}
}