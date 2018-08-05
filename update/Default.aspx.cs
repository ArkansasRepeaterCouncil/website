using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class update_Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Credentials creds = Utilities.GetExistingCredentials();

		using (var webClient = new System.Net.WebClient())
		{
			string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetUsersRepeaters?callsign={0}&password={1}", creds.Username, creds.Password);
			string json = webClient.DownloadString(url);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

			string[] fields = {"Callsign", "OutputFrequency", "City", "Status" };

			foreach (dynamic obj in data)
			{
				
				TableRow row = new TableRow();
				TableCell cell = new TableCell();
				cell.Text = "<button onclick='alert(" + obj.ID + ");'>Edit</button>";
				row.Cells.Add(cell);

				for (int i = 0; i < fields.Length; i++)
				{
					cell = new TableCell();
					cell.Text = obj[fields[i]];
					row.Cells.Add(cell);
				}

				RepeatersTable.Rows.Add(row);
			}

		}
	}
}