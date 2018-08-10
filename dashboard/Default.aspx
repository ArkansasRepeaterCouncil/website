<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="dashboard_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">Dashboard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section>
		<h1>To-Do</h1>
		<table class="todoTable">
            <tr><td>Feature</td><td>Stored procedure</td><td>Web service</td><td>User interface</td></tr>
            <tr><td>Update repeaters</td><td>x</td><td>x</td><td>&nbsp;</td></tr>
            <tr><td>Domestic coordination request</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td>Foreign coordination request</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td>Dashboard</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
		</table>
	</section>
    <section>
        <h1>My repeaters</h1>
	
        <asp:Table ID="RepeatersTable" runat="server">
            <asp:TableRow runat="server" TableSection="TableHeader">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Call sign</asp:TableCell>
                <asp:TableCell runat="server">Frequency</asp:TableCell>
                <asp:TableCell runat="server">City</asp:TableCell>
                <asp:TableCell runat="server">Status</asp:TableCell>
                <asp:TableCell runat="server">Last updated</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </section>
</asp:Content>

