using Newtonsoft.Json;
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
		string stateAbbr = Utilities.StateToDisplay;
        string stateName = Utilities.GetStateNameByAbbr(stateAbbr);
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

        string rootUrl = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"].ToString();
        string url = String.Format("{0}ListBusinessRulesFrequencies?stateAbbreviation={1}", rootUrl, stateAbbr);
        string json = Utilities.GetResponseFromUrl(url);
        dynamic stats = JsonConvert.DeserializeObject<dynamic>(json);

        foreach (dynamic obj in stats)
		{
			BusinessRuleFrequency rule = new BusinessRuleFrequency(obj);
			TableRow row = new TableRow();
			row.AddCell(string.Format("{0} - {1}", rule.FrequencyStart, rule.FrequencyEnd));
			row.AddCell(string.Format("{0} MHz", rule.SpacingMhz));
			row.AddCell(string.Format("{0} miles", rule.SeparationMiles));
			tblBusinessRulesFrequencies.Rows.Add(row);
        }
    }
}

public class BusinessRuleFrequency 
{
	public string FrequencyStart;
	public string FrequencyEnd;
	public string SpacingMhz;
	public string SeparationMiles;

	public BusinessRuleFrequency(dynamic rule)
	{
		FrequencyStart= rule.FrequencyStart;
		FrequencyEnd= rule.FrequencyEnd;
		if (rule.SpacingMhz == 0)
		{
			SpacingMhz = "same frequency";
		}
		else
		{
            SpacingMhz = rule.SpacingMhz;
        }
		
		SeparationMiles= rule.SeparationMiles;
	}
}