using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profile_Default : System.Web.UI.Page
{
	Credentials creds;

	protected void Page_Load(object sender, EventArgs e)
	{
		creds = Utilities.GetExistingCredentials();
		ARC.User user = ARC.User.Load(creds);

		txtUserId.Text = user.ID;
		txtAddress.Text = user.Address;
		txtCallsign.Text = user.Callsign;
		txtCity.Text = user.City;
		txtEmail.Text = user.Email;
		txtFullname.Text = user.FullName;
		txtPhoneCell.Text = user.PhoneCell;
		txtPhoneHome.Text = user.PhoneHome;
		txtPhoneWork.Text = user.PhoneWork;
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		ARC.User user = new ARC.User(txtUserId.Text, txtCallsign.Text, txtFullname.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtEmail.Text, txtPhoneHome.Text, txtPhoneWork.Text, txtPhoneCell.Text, txtPassword1.Text);
		user.Save(creds.Password);
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/dashboard/");
	}
}