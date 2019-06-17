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

		if (!Page.IsPostBack)
		{
			ARC.User user = ARC.User.Load(creds);

			txtUserId.Text = user.ID;
			txtAddress.Text = user.Address;
			txtCallsign.Text = user.Callsign;
			txtCity.Text = user.City;
			txtZip.Text = user.Zip;
			txtEmail.Text = user.Email;
			txtFullname.Text = user.FullName;
			txtPhoneCell.Text = user.PhoneCell;
			txtPhoneHome.Text = user.PhoneHome;
			txtPhoneWork.Text = user.PhoneWork;

			if (Request.QueryString["ip"] != null)
			{
				lblFeedback.Text = "Please complete your profile by providing your name, address, email, and at least one phone number.";
			}
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		if (IsValid)
		{
			string newPassword = "";

			if (txtPassword1.Text != string.Empty)
			{
				newPassword = txtPassword1.Text;
			}

			ARC.User user = new ARC.User(txtUserId.Text, txtCallsign.Text, txtFullname.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtEmail.Text, txtPhoneHome.Text, txtPhoneWork.Text, txtPhoneCell.Text, newPassword);
			user.Save(creds.Password);

			if (newPassword != "")
			{
				HttpCookie ckLogin = new HttpCookie("login", Utilities.Base64Encode(txtCallsign.Text + "|" + newPassword));
				Response.Cookies.Add(ckLogin);
			}

			lblFeedback.Text = "<p class='feedback'>Account changes saved.</p>";
			lblFeedback.Visible = true;
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/dashboard/");
	}
}