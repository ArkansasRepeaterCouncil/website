using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class repeaters_Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		getPublicRepeaterList();
	}


	protected void btnSearch_Click(object sender, EventArgs e)
	{
		getPublicRepeaterList();
	}

	protected void getPublicRepeaterList()
	{
		using (var webClient = new System.Net.WebClient())
		{
			string json = webClient.DownloadString(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + string.Format("ListPublicRepeaters?state={0}&frequency={1}", "ar", txtFrequency.Text));
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			string rtn = "";
			rtn += @"
					<table class='repeaterListTable'>
					<thead><tr>
						<th>Frequency</th>
						<th>Offset</th>
						<th>Callsign</th>
						<th>Trustee</th>
						<th>Status</th>
						<th>City</th>
						<th>Attributes</th>
					</tr></thead>";
			rtn += "<tbody>";

			foreach (dynamic obj in data)
			{
				rtn += "<tr>";

				rtn += "<td>" + obj.OutputFrequency + "</td>";
				rtn += "<td>" + obj.Offset + "</td>";
				rtn += "<td>" + obj.Callsign + "</td>";
				rtn += "<td>" + obj.Trustee + "</td>";
				rtn += "<td>" + obj.Status + "</td>";
				rtn += "<td>" + obj.City + "</td>";


				rtn += "<td>";

				List<string> attributes = new List<string>();

				Utilities.GetValueIfNotNull(obj.Analog_InputAccess, "input tone: ", attributes);
				Utilities.GetValueIfNotNull(obj.Analog_OutputAccess, "output tone: ", attributes);
				Utilities.GetValueIfNotNull(obj.DSTAR_Module, "D-Star module: ", attributes);
				Utilities.GetValueIfNotNull(obj.DMR_ID, "DMR ID: ", attributes);
				Utilities.GetNameIfNotNull(obj.AutoPatch, "autopatch", attributes);
				Utilities.GetNameIfNotNull(obj.EmergencyPower, "emergency power", attributes);
				Utilities.GetNameIfNotNull(obj.Linked, "linked", attributes);
				Utilities.GetNameIfNotNull(obj.RACES, "RACES", attributes);
				Utilities.GetNameIfNotNull(obj.ARES, "ARES", attributes);
				Utilities.GetNameIfNotNull(obj.Weather, "weather net", attributes);

				for (int index = 0; index < attributes.Count; index++)
				{
					string attribute = attributes[index];
					rtn += index < attributes.Count - 1 ? attribute + ", " : attribute;
				}

				rtn += "</td></tr>";
			}

			rtn += "</tbody></table>";

			repeaterList.Text = rtn;
		}
	}
}