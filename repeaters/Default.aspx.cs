using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class repeaters_Default : System.Web.UI.Page
{
	string query = "";
	int page = 1;

	protected void Page_Load(object sender, EventArgs e)
	{
		query = Request.QueryString["q"];
		if (query == null) { query = ""; }
		if (txtSearch.Text != "") { query = txtSearch.Text; }

		string pageTest = Request.QueryString["p"];
		int intPage;
		if (int.TryParse(pageTest, out intPage))
		{
			if (intPage > 1)
			{
				page = intPage;
			}
		}

		getPublicRepeaterList();
	}

	protected void getPublicRepeaterList()
	{
		string uri = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ListPublicRepeaters?state=ar";

		Regex rxLatLon = new Regex(@"([-+]?(?:[0-9]|[1-9][0-9])\.\d+),\s*([-+]?(?:[0-9]|[1-9][0-9]|[1-9][0-9][0-9])\.\d+)");

		if (rxLatLon.IsMatch(txtSearch.Text))
		{
			MatchCollection matches = rxLatLon.Matches(txtSearch.Text);
			Match match = matches[0];
			GroupCollection groups = match.Groups;
			uri += string.Format("&latitude={0}&longitude={1}&miles={2}", groups[1], groups[2], "40");
		}
		else
		{
			uri += string.Format("&search={0}&pageNumber={1}&pageSize={2}", query, page.ToString(), "9");
		}

		using (var webClient = new System.Net.WebClient())
		{
			System.Diagnostics.Debug.WriteLine(uri);
			string json = webClient.DownloadString(uri);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			string rtn = "";
			rtn += @"
					<table class='repeaterListTable'>
					<thead><tr class='repeaterListTableRow'>
						<th>&nbsp;</th>
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
				rtn += "<tr class='repeaterListTableRow'>";

				rtn += "<td><a href='details/?id=" + obj.ID + "'>Details</a></td>";
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

				string strAttribs = "";
				for (int index = 0; index < attributes.Count; index++)
				{
					string attribute = attributes[index];
					if (
						(attribute.Trim() != "") && 
						(attribute != "DMR ID: ") && 
						(attribute != "D-Star module: ") &&
						(attribute != "output tone: ") &&
						(attribute != "input tone: None")
						)
					{
						if (strAttribs != "") { strAttribs += ", "; }
						strAttribs += attribute;
					}
				}
				rtn += strAttribs;

				rtn += "</td></tr>";
			}

			rtn += "</tbody></table>";

			repeaterList.Text = rtn;
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("~/repeaters/?q={0}", query));
	}

	protected void btnFirst_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("~/repeaters/?q={0}&p=1", query));
	}

	protected void btnPrevious_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("~/repeaters/?q={0}&p={1}", query, page - 1));
	}

	protected void btnNext_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("~/repeaters/?q={0}&p={1}", query, page + 1));
	}
}