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
			}
			catch
			{
				
			}
		}

		if (Session["issue"] != null)
		{
			try
			{ 
				Issue issue = (Issue)HttpContext.Current.Session["issue"];
				txtDetails.Text = issue.body;
				hdnTitle.Value = issue.title;
				pnlDetails.Visible = true;
			}
			catch
			{
				pnlDetails.Visible = false;
			}
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		Issue issue = new Issue(hdnTitle.Value, txtExplanation.Text + Environment.NewLine + Environment.NewLine + txtDetails.Text);
		try
		{
			string url = issue.Submit();
			lblIssueURL.Text += url;
			lblIssueURL.Visible = true;
		}
		catch (Exception)
		{
			lblIssueURL.Visible = false;
		}

		pnlDetails.Visible = false;
		pnlThanks.Visible = true;
	}
}