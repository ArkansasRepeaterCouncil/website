using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARC
{
	public class User
	{
		public string ID = "";
		public string Callsign = "";
		public string FullName = "";
		public string Address = "";
		public string City = "";
		public string State = "";
		public string Zip = "";
		public string Email = "";
		public string PhoneHome = "";
		public string PhoneWork = "";
		public string PhoneCell = "";
		public string NewPassword = "";
		[JsonProperty]
		private string Password = "";

		public User() { }

		public static User Load(Credentials credentials)
		{
			// Call web service to get all data for the repeater with this ID
			User user;
			using (var webClient = new System.Net.WebClient())
			{
				string url = String.Format(System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "GetUserDetails?callsign={0}&password={1}", credentials.Username, credentials.Password);
				string json = webClient.DownloadString(url);
				user = JsonConvert.DeserializeObject<User>(json);
			}
			return user;
		}

		public User (string id, string callsign, string fullname, string address, string city, string state, string zip, string email, string phonehome, string phonework, string phonecell, string newpassword)
		{
			ID = id;
			Callsign = callsign;
			FullName = fullname;
			Address = address;
			City = city;
			State = state;
			Zip = zip;
			Email = email;
			PhoneHome = phonehome;
			PhoneWork = phonework;
			PhoneCell = phonecell;
			NewPassword = newpassword;
		}

		public void Save(string password)
		{
			Password = password;
			string url = System.Configuration.ConfigurationManager.AppSettings["webServiceRootUrl"] + "UpdateUser";
			string result = Utilities.PostJsonToUrl(url, this);
		}
	}
}