using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Creates an issue to be submitted to Github
/// </summary>
public class Issue
{
	private string repository = System.Configuration.ConfigurationManager.AppSettings["githubRepository"];
	public string title = "";
	public string body = "";
	public string milestone = "";
	public string[] labels;
	public string[] assignees;
	private string Url
	{
		get
		{
			return "https://api.github.com/repos/" + repository + "/issues/";
		}
	}

	private void append(string text)
	{
		if (text == null) { text = string.Empty; }
		this.body += "\r\n" + text + "\r\n";
	}

	private void appendCode(string code)
	{
		if (code == null) { code = string.Empty; }
		this.body += "\r\n```\r\n" + code + "\r\n```\r\n";
	}

	private void appendCode(string codeTitle, string code)
	{
		if (code == null) { code = string.Empty; }
		this.body += "\r\n### " + codeTitle + "\r\n```\r\n" + code + "\r\n```\r\n";
	}

	public void appendQuote(string text)
	{
		this.body += "\r\n> " + text.Replace("\r\n", "\r\n> ") + "\r\n";
	}

	private void appendQuote(string quoteTitle, string text)
	{
		if (text == null) { text = string.Empty; }
		this.body += "\r\n### " + quoteTitle + "\r\n> " + text.Replace("\r\n", "\r\n> ") + "\r\n";
	}

	private void appendException(Exception exception)
	{
		appendQuote("Message", exception.Message);
		appendQuote("Help link", exception.HelpLink);
		appendQuote("Source", exception.Source);
		appendQuote("Stack trace", exception.StackTrace);
	}

	public Issue() { }

	public Issue(string strTitle)
	{
		this.title = strTitle;
	}

	public Issue(Exception ex)
	{
		appendException(ex);
	}

	public Issue(string strTitle, string strBody)
	{
		this.title = strTitle;
		this.body = strBody;
	}

	public string Submit()
	{
		string strReturn = "";
		var client = new GitHubClient(new ProductHeaderValue("ArkansasRepeaterCouncil-site"));
		string githubUsername = System.Configuration.ConfigurationManager.AppSettings["githubUsername"];
		string githubPassword = System.Configuration.ConfigurationManager.AppSettings["githubPassword"];
		var basicAuth = new Octokit.Credentials(githubUsername, githubPassword);
		client.Credentials = basicAuth;
		var newIssue = new NewIssue(this.title);
		newIssue.Body = this.body;
		Task<Octokit.Issue> issue = client.Issue.Create("ArkansasRepeaterCouncil", "website", newIssue);
		issue.Wait(15000);

		try
		{
			strReturn = issue.Result.HtmlUrl;
		}
		catch (Exception)
		{
			strReturn = "";
		}
		

		return strReturn;
	}

}