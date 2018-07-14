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

				Utilities.getValueIfNotNull(obj.Analog_InputAccess, "input tone: ", attributes);
				Utilities.getValueIfNotNull(obj.Analog_OutputAccess, "output tone: ", attributes);
				Utilities.getValueIfNotNull(obj.DSTAR_Module, "D-Star module: ", attributes);
				Utilities.getValueIfNotNull(obj.DMR_ID, "DMR ID: ", attributes);
				Utilities.getNameIfNotNull(obj.AutoPatch, "autopatch", attributes);
				Utilities.getNameIfNotNull(obj.EmergencyPower, "emergency power", attributes);
				Utilities.getNameIfNotNull(obj.Linked, "linked", attributes);
				Utilities.getNameIfNotNull(obj.RACES, "RACES", attributes);
				Utilities.getNameIfNotNull(obj.ARES, "ARES", attributes);
				Utilities.getNameIfNotNull(obj.Weather, "weather net", attributes);

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