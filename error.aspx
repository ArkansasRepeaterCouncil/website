<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section>
		<h1>Hang on a sec...</h1>
		<p>
			Ok, stay calm and keep reading.  There's been an error - but before you freak out just know that the website has automatically told us about it.  As soon as we see the notification we'll start working to fix this.
		</p>
        <p>In the meantime, here are some things you can try:
        </p>
        <ul>
            <li>Open the page you were on and try again. This hardly ever solves anything, but it's a simple thing to try.</li>
            <li>Make sure you aren't doing something <span style="text-decoration:line-through;">stupid</span> unexpected like entering a letter in a number field.</li>
            <li>Wait a few days for us to address the problem then try again.  If you've already waited and you're still getting an error, you might try to contact one of us to make sure we're on it.</li>
        </ul>
        <h3>Details</h3>
        <asp:label ID="lblDetails" runat="server" text="None"></asp:label>
    </section>
</asp:Content>

