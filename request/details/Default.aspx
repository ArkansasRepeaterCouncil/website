<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="request_details_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" rel="stylesheet" href="../../css/requests.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		<h1><asp:Label ID="lblID" runat="server" Text="Label"></asp:Label></h1>
        <asp:Label CssClass="label" ID="Label16" runat="server" Text="Status:"></asp:Label><asp:Label CssClass="label" ID="lblStatus" runat="server" Text="Label"></asp:Label><br />
        <asp:Label CssClass="label" ID="Label1" runat="server" Text="Requestor:"></asp:Label><asp:Label CssClass="label" ID="lblRequestor" runat="server" Text="Label"></asp:Label><br />
        <asp:Label CssClass="label" ID="Label2" runat="server" Text="Latitude:"></asp:Label><asp:Label CssClass="label" ID="lblLatitude" runat="server" Text="Label"></asp:Label><br />
        <asp:Label CssClass="label" ID="Label4" runat="server" Text="Longitude:"></asp:Label><asp:Label CssClass="label" ID="lblLongitude" runat="server" Text="Label"></asp:Label><br />
        <asp:Label CssClass="label" ID="Label6" runat="server" Text="Output frequency:"></asp:Label><asp:Label CssClass="label" ID="lblOutputFrequency" runat="server" Text="Label"></asp:Label><br />
        <asp:Label CssClass="label" ID="Label8" runat="server" Text="Power:"></asp:Label><asp:Label CssClass="label" ID="lblPower" runat="server" Text="Label"></asp:Label><br />
        <asp:Label CssClass="label" ID="Label10" runat="server" Text="Altitude:"></asp:Label><asp:Label CssClass="label" ID="lblAltitude" runat="server" Text="Label"></asp:Label><br />
        <asp:Label CssClass="label" ID="Label12" runat="server" Text="Antenna height:"></asp:Label><asp:Label CssClass="label" ID="lblAntennaHeight" runat="server" Text="Label"></asp:Label><br />
    </section>
    <section>
        <h1>Notes</h1>
        <asp:Table CssClass="notesTable" ID="tblNotes" runat="server"></asp:Table>
    </section>
    <section>
        <h1>Responses</h1>
        <asp:Table CssClass="responsesTable" ID="tblWorkflow" runat="server" Width="850px">
            <asp:TableRow runat="server" TableSection="TableHeader">
                <asp:TableCell runat="server" Width="200px">State</asp:TableCell>
                <asp:TableCell runat="server" Width="200px">Status</asp:TableCell>
                <asp:TableCell runat="server">Note</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </section>
</asp:Content>

