using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class error : System.Web.UI.Page
{
	ExceptionReport ex;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			ExceptionReport ex = (ExceptionReport)Session["exception"];
			txtException.Text = new JavaScriptSerializer().Serialize(ex);
		}
		catch (Exception)
		{

			// throw;  // Let's not.  Could cause a cycle of hell.
		}
	}
}