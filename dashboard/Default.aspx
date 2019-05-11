<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="dashboard_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .repeaterList {
            margin-left: auto;
            margin-right: auto;
            width: 800px;
            margin-bottom: 20px;
        }
        .updatesList {
            width: 800px;
            margin-left: auto;
            margin-right: auto;
        }
        .updatesList ul {
            margin-top: 0;
            padding-top: 0;
            font-size: 0.7em;
        }
        .expiredRepeaterNote {
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">: Dashboard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlAdminTools" runat="server" Visible="false">
    <section>
	    <h2>Admin</h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="tabs">
            <ul>
                <li><a href="#tab-1">Tools</a></li>
                <li><a href="#tab-2">Expired repeaters</a></li>
                <li><a href="#tab-3">Open requests</a></li>
            </ul>
        
            <div id="tab-1" >
                <p>These don't work yet, don't bother.</p>
                <asp:Button ID="Button1" runat="server" Text="Reset a user's password" Enabled="false" />
                <asp:Button ID="Button2" runat="server" Text="Look up a user" Enabled="false" />
                <asp:Button ID="Button3" runat="server" Text="Edit a repeater" Enabled="false" />
            </div>
            <div id="tab-2">
                <asp:Panel ID="pnlExpiredRepeaters" runat="server"></asp:Panel>
            </div>
            <div id="tab-3">
                <asp:Panel ID="pnlOpenRequests" runat="server"></asp:Panel>
            </div>
        </div>
    </section>
    </asp:Panel>
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
    <asp:Panel ID="pnlRequests" runat="server" Visible="False">
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

</asp:Content>

