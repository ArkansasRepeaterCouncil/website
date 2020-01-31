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
	string orderBy = "OutputFrequency";

	protected void Page_Load(object sender, EventArgs e)
	{
		query = Request.QueryString["q"];
		if (query == null) { query = ""; }

        if (txtSearch.Text != "")
        {
            query = txtSearch.Text;
        }
        else
        {
            txtSearch.Text = query;
        }

		string pageTest = Request.QueryString["p"];
		int intPage;
		if (int.TryParse(pageTest, out intPage))
		{
			if (intPage > 1)
			{
				page = intPage;
			}
		}

		orderBy = Request.QueryString["o"];
		if (orderBy == null) { orderBy = "OutputFrequency"; }

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
            orderBy = "Distance";
            uri += string.Format("&latitude={0}&longitude={1}&miles={2}&orderBy={3}", groups[1], groups[2], "40", orderBy);
		}
		else
		{
			uri += string.Format("&search={0}&pageNumber={1}&pageSize={2}&orderBy={3}", query, page.ToString(), "9", orderBy);
		}

		using (var webClient = new System.Net.WebClient())
		{
			System.Diagnostics.Debug.WriteLine(uri);
			string json = webClient.DownloadString(uri);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			foreach (dynamic obj in data)
			{
				TableRow row = new TableRow();
				row.CssClass = "repeaterListTableRow";

				using (TableCell cell = new TableCell())
				{
					cell.Text = "<a href='details/?id=" + obj.ID + "'>Details</a>";
					row.Cells.Add(cell);
				}

				using (TableCell cell = new TableCell())
				{
					cell.Text = obj.OutputFrequency;
					row.Cells.Add(cell);
				}

				using (TableCell cell = new TableCell())
				{
					cell.Text = obj.Offset;
					row.Cells.Add(cell);
				}

				using (TableCell cell = new TableCell())
				{
					cell.Text = obj.Callsign;
					row.Cells.Add(cell);
				}

				using (TableCell cell = new TableCell())
				{
					cell.Text = obj.Trustee;
					row.Cells.Add(cell);
				}

				using (TableCell cell = new TableCell())
				{
					cell.Text = obj.Status;
					row.Cells.Add(cell);
				}

				using (TableCell cell = new TableCell())
				{
					cell.Text = obj.City;
					row.Cells.Add(cell);
				}

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

				string strAttributes = "";
				for (int index = 0; index < attributes.Count; index++)
				{
					string attribute = attributes[index];
					if (
						(attribute.Trim() != "") && 
						(attribute != "DMR ID: ") && 
						(attribute != "D-Star module: ") &&
						(attribute != "output tone: ") &&
						(attribute != "input tone: None") &&
						(attribute != "input tone: ")
						)
					{
						if (strAttributes != "") { strAttributes += ", "; }
						strAttributes += attribute;
					}
				}

				using (TableCell cell = new TableCell())
				{
					cell.Text = strAttributes;
					row.Cells.Add(cell);
				}

				tableRepeaters.Rows.Add(row);
			}
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

	protected void linkButton_Click(object sender, EventArgs e)
	{
		LinkButton lb = (LinkButton)sender;
		Response.Redirect(string.Format("~/repeaters/?q={0}&p={1}&o={2}", query, page, lb.CommandArgument));
	}
}