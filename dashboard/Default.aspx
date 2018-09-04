<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="dashboard_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .repeaterList {
            margin-left: auto;
            margin-right: auto;
            width: 800px;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">Dashboard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <h1>My repeaters</h1>
	
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
</asp:Content>

