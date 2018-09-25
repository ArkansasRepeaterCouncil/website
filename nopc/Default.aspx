<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="nopc_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section>
		<h1>Notice of Proposed Coordination</h1>
		<p>
			Please see the information below for details on this request, then use the dropdown list to either approve or decline it below.  If you decline a request, we do ask that you please provide a reason in the space provided.
		</p>
        <asp:Label ID="lblError" runat="server" Text="<p style='color: #FF5555;'>If you decline a request, we do ask that you please provide a reason in the space provided.</p>" Visible="False"></asp:Label>
        <p>
            <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label16" runat="server" Text="Status"></asp:Label><asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label1" runat="server" Text="Requestor"></asp:Label><asp:Label ID="lblRequestor" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text="Latitude"></asp:Label><asp:Label ID="lblLatitude" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Text="Longitude"></asp:Label><asp:Label ID="lblLongitude" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label6" runat="server" Text="Output frequency"></asp:Label><asp:Label ID="lblOutputFrequency" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label8" runat="server" Text="Power"></asp:Label><asp:Label ID="lblPower" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label10" runat="server" Text="Altitude"></asp:Label><asp:Label ID="lblAltitude" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label12" runat="server" Text="Antenna height"></asp:Label><asp:Label ID="lblAntennaHeight" runat="server" Text="Label"></asp:Label><br />
		</p>
    </section>
    <section>
        <h1>Notes</h1>
        <asp:Table ID="tblNotes" runat="server"></asp:Table>
    </section>
    <section>
        <h1>Approvals</h1>
        <asp:Table ID="tblWorkflow" runat="server" Width="850px">
            <asp:TableRow runat="server" TableSection="TableHeader">
                <asp:TableCell runat="server" Width="200px">State</asp:TableCell>
                <asp:TableCell runat="server" Width="200px">Status</asp:TableCell>
                <asp:TableCell runat="server">Note</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit changes" OnClick="btnSubmit_Click" />
    </section>
</asp:Content>

