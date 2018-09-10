using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class request_Default : System.Web.UI.Page
{
	Credentials creds;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			creds = Utilities.GetExistingCredentials();
			ARC.User user = ARC.User.Load(creds);

			txtPersonCallsign.Text = user.Callsign;
			txtEmail.Text = user.Email;
			txtPersonName.Text = user.FullName;
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/Dashboard/");
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{

	}
}