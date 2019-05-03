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
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="noadminTab">
            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Tools" ForeColor="#fff" BackColor="#000" >
                <ContentTemplate>
                    <p>These don't work yet, don't bother.</p>
                    <asp:Button ID="Button1" runat="server" Text="Reset a user's password" Enabled="false" />
                    <asp:Button ID="Button2" runat="server" Text="Look up a user" Enabled="false" />
                    <asp:Button ID="Button3" runat="server" Text="Edit a repeater" Enabled="false" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Expired repeaters" CssClass="adminTab" ForeColor="#fff" BackColor="#000">
                <ContentTemplate>
                    <asp:Panel ID="pnlExpiredRepeaters" runat="server"></asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Open requests" CssClass="adminTab" ForeColor="#fff" BackColor="#000">
                <ContentTemplate>
                    <asp:Panel ID="pnlOpenRequests" runat="server"></asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
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

