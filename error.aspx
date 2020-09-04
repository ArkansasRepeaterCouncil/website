<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section>
		<h1>Hang on a sec...</h1>
		<p>Ok, stay calm and keep reading.  There's been an error.</p>
        <p>Here are some things you can try:</p>
        <ul>
            <li>Open the page you were on and try again. This hardly ever solves anything, but it's a simple thing to try.</li>
            <li>Make sure you aren't doing something <span style="text-decoration:line-through;">stupid</span> unexpected like entering a letter in a number field.</li>
        </ul>
            
        If you would like to open a support request, please do so at <a href="https://github.com/ArkansasRepeaterCouncil/website/issues" target="_blank">https://github.com/ArkansasRepeaterCouncil/website/issues</a>.

            <br />
            <br />

        <asp:TextBox ID="txtException" runat="server" TextMode="MultiLine" Width="1198px"></asp:TextBox>
    </section>
</asp:Content>

