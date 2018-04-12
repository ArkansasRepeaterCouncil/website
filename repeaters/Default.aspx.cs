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
		using (var webClient = new System.Net.WebClient())
		{
			string json = webClient.DownloadString(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ListPublicRepeaters?state=ar");
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			string rtn = "";
			rtn += "<table class='repeaterListTable'><thead><tr><th>Callsign</th><th>Trustee</th><th>Status</th><th>City</th><th>Frequency</th><th>Offset</th><th>Attributes</th></tr></thead>";
			rtn += "<tbody>";

			foreach (dynamic obj in data)
			{
				rtn += "<tr>";

				rtn += "<td>" + obj.Callsign + "</td>";
				rtn += "<td>" + obj.Trustee + "</td>";
				rtn += "<td>" + obj.Status + "</td>";
				rtn += "<td>" + obj.City + "</td>";
				rtn += "<td>" + obj.OutputFrequency + "</td>";
				rtn += "<td>" + obj.Offset + "</td>";

				rtn += "<td>";

				List<string> attributes = new List<string>();

				getValueIfNotNull(obj.Analog_InputAccess, "input tone: ", attributes);
				getValueIfNotNull(obj.Analog_OutputAccess, "output tone: ", attributes);
				getValueIfNotNull(obj.DSTAR_Module, "D-Star module: ", attributes);
				getValueIfNotNull(obj.DMR_ID, "DMR ID: ", attributes);
				getNameIfNotNull(obj.AutoPatch, "autopatch", attributes);
				getNameIfNotNull(obj.EmergencyPower, "emergency power", attributes);
				getNameIfNotNull(obj.Linked, "linked", attributes);
				getNameIfNotNull(obj.RACES, "RACES", attributes);
				getNameIfNotNull(obj.ARES, "ARES", attributes);
				getNameIfNotNull(obj.Weather, "weather net", attributes);

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

	private void getValueIfNotNull(object val, string prefixString, List<string> arr)
	{
		if ((val is int) && ((int)val == 1))
		{
			arr.Add(prefixString + val);
		}
	}

	private void getNameIfNotNull(object val, string name, List<string> arr)
	{
		bool boolVal = false;
		if ((Boolean.TryParse(val.ToString(), out boolVal)) && (boolVal))
		{
			arr.Add(name);
		}
	}
}