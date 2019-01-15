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
				ExceptionReport ex = (ExceptionReport)Session["exception"];
				lblDetails.Text = ex.InnerExceptionMessage;
				if (ex.IssueURL != string.Empty)
				{
					lblDetails.Text = string.Format("An issue has been automatically opened. You can view the details at <a target='_blank' href='{0}'>{0}</a>.", ex.IssueURL);
				}
			}
			catch
			{
				
			}
		}
	}
}