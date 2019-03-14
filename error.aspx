<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section>
		<h1>Hang on a sec...</h1>
		<p>
			Ok, stay calm and keep reading. There&#39;s been an error.
		</p>
        <asp:label ID="lblDetails" runat="server" text=""></asp:label>
        <p>Here are some things you can try:</p>
        <ul>
            <li>Open the page you were on and try again. This hardly ever solves anything, but it's a simple thing to try.</li>
            <li>Make sure you aren't doing something <span style="text-decoration:line-through;">stupid</span> unexpected like entering a letter in a number field.</li>
            <li>Wait a few days for us to address the problem then try again.  If you've already waited and you're still getting an error, you might try to contact one of us to make sure we're on it.</li>
        </ul>
        <asp:Panel ID="pnlDetails" runat="server">
            If you would like to open a ticket about this error, please explain what you were trying to do in the field below.&nbsp;<br /><strong><em>This information will be public. Do not submit any private information.</em></strong><br />
            <asp:TextBox ID="txtExplanation" runat="server" Height="83px" TextMode="MultiLine" Width="544px"></asp:TextBox>
            <br />
            <br />
            Other details automatically collected:<br /><asp:TextBox ID="txtDetails" runat="server" ReadOnly="true" Height="46px" TextMode="MultiLine" Width="539px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Report this issue" OnClick="btnSubmit_Click" /><asp:HiddenField ID="hdnTitle" runat="server" />
        </asp:Panel>
        
            <asp:Panel ID="pnlThanks" runat="server" Visible="False">
                Thanks for submitting this issue.&nbsp;
                <asp:Label ID="lblIssueURL" runat="server" Text="  If you would like to follow the issue or check back for updates, the issue's URL is: "></asp:Label>
            </asp:Panel>
        
    </section>
</asp:Content>

