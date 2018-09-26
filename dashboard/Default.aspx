<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="dashboard_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .repeaterList {
            margin-left: auto;
            margin-right: auto;
            width: 800px;
            margin-bottom: 20px;
        }
        .updatesList {
            margin-top: 0;
            padding-top: 0;
            font-size: 0.7em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">Dashboard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
	    <h2>Repeaters</h2>
        <asp:Table ID="RepeatersTable" runat="server" CssClass="repeaterList">
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
    <asp:Panel ID="pnlRequests" runat="server">
    <section>
	    <h2>Coordination requests</h2>
        <asp:Table ID="tblRequests" runat="server" CssClass="repeaterList">
            <asp:TableRow runat="server" TableSection="TableHeader">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Request #</asp:TableCell>
                <asp:TableCell runat="server">Frequency</asp:TableCell>
                <asp:TableCell runat="server">Status</asp:TableCell>
                <asp:TableCell runat="server">Last updated</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </section>
    </asp:Panel>
    <section>
	    <h2>Recent updates</h2>
            <asp:Repeater ID="rptRSS" runat="server" DataSourceID="xmlRSS"> 
                <ItemTemplate> 
                    <strong><%# XPath("title") %></strong> (<%# XPath("pubDate") %>)
                    <ul class="updatesList">
                    <%# XPath("description").ToString().Replace("• ", "<li>") %>
                    </ul>
                </ItemTemplate>        
            </asp:Repeater>
        <asp:XmlDataSource ID="xmlRSS" runat="server" DataFile="http://repeatercoordinationservice.azurewebsites.net/api/RSScreator?code=lYVEWOyzmLP0WYS1fg7NutMgKHOqrKkFMxcyj/41ubix126V9n7nNg==" XPath="rss/channel/item[position() <= 5]"></asp:XmlDataSource>
    </section>
</asp:Content>

