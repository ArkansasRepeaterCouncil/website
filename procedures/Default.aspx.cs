using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class procedures_Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string stateName = Utilities.GetStateNameByAbbr(Utilities.StateToDisplay);
		string siteAddress = HttpContext.Current.Request.Url.DnsSafeHost.ToLower();

		Label[] lblSiteAddresses = { lblSiteAddress1, lblSiteAddress2, lblSiteAddress3, lblSiteAddress4, lblSiteAddress5 };
		foreach (Label lblSiteAddress in lblSiteAddresses)
		{
			lblSiteAddress.Text = siteAddress;
        }

		Label[] lblStates = {lblState1,lblState2,lblState3,lblState4,lblState5,lblState6,lblState7,lblState8};
		foreach (Label lblState in lblStates)
		{
			lblState.Text = stateName;
		}
    }
}