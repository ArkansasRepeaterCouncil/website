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
	bool includeDecoordinated = false;
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

		if (Page.IsPostBack)
		{
			includeDecoordinated = chkIncludeDecoordinated.Checked;
		}
		else
		{
			includeDecoordinated = (Request.QueryString["dc"] == "True");
			chkIncludeDecoordinated.Checked = includeDecoordinated;
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
        int includeDecoordinated = 0;
        if (!chkIncludeDecoordinated.Checked) {
            includeDecoordinated = 6;  // 6 is the internal ID for repeater_status decoordinated.
        }

        string uri = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "ListPublicRepeaters?state=" + Utilities.StateToDisplay;

		Regex rxLatLon = new Regex(@"([-+]?(?:[0-9]|[1-9][0-9])\.\d+),\s*([-+]?(?:[0-9]|[1-9][0-9]|[1-9][0-9][0-9])\.\d+)");

		if (rxLatLon.IsMatch(txtSearch.Text))
		{
			MatchCollection matches = rxLatLon.Matches(txtSearch.Text);
			Match match = matches[0];
			GroupCollection groups = match.Groups;
            orderBy = "Distance";
            uri += string.Format("&latitude={0}&longitude={1}&miles={2}&orderBy={3}&includeDecoordinated={4}", groups[1], groups[2], "40", orderBy, includeDecoordinated);
		}
		else
		{
			uri += string.Format("&search={0}&pageNumber={1}&pageSize={2}&orderBy={3}&includeDecoordinated={4}", query, page.ToString(), "9", orderBy, includeDecoordinated);
		}

		using (var webClient = new System.Net.WebClient())
		{
			System.Diagnostics.Debug.WriteLine(uri);
			string json = webClient.DownloadString(uri);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			foreach (dynamic obj in data)
			{
				TableRow row = new TableRow();
				row.CssClass = "repeaterListTableRow " + obj.Status;

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
					cell.Text = string.Format("<a href='https://qrz.com/db/{0}' target='_blank'>{0}</a>", obj.Callsign);
					row.Cells.Add(cell);
				}

				using (TableCell cell = new TableCell())
				{
					cell.Text = string.Format("<a href='https://qrz.com/db/{0}' target='_blank'>{0}</a>", obj.Trustee);
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
		Response.Redirect(string.Format("~/repeaters/?q={0}&dc={1}&o={2}", query, includeDecoordinated, orderBy));
	}

	protected void btnFirst_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("~/repeaters/?q={0}&p=1&dc={1}&o={2}", query, includeDecoordinated, orderBy));
	}

	protected void btnPrevious_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("~/repeaters/?q={0}&p={1}&dc={2}&o={3}", query, page - 1, includeDecoordinated, orderBy));
	}

	protected void btnNext_Click(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("~/repeaters/?q={0}&p={1}&dc={2}&o={3}", query, page + 1, includeDecoordinated, orderBy));
	}

	protected void linkButton_Click(object sender, EventArgs e)
	{
		LinkButton lb = (LinkButton)sender;
		Response.Redirect(string.Format("~/repeaters/?q={0}&p={1}&o={2}&dc={3}", query, page, lb.CommandArgument, includeDecoordinated));
	}
}