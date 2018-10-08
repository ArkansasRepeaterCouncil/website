<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="nopc_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <link type="text/css" rel="stylesheet" href="../css/requests.css" />
    <style>
        #divResponseForm {
            width: 850px;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section>
		<h1>Notice of Proposed Coordination</h1>
        <asp:Label ID="lblSaved" runat="server" Text="<p style='color: #55FF55;'>Thanks! Your update has been saved.</p>" Visible="False"></asp:Label>
		<p>
			Please see the information below for details on this request, then use the dropdown list to either approve or decline it below.  If you decline a request, we do ask that you please provide a reason in the space provided.
		</p>
        <p>
            <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label16" runat="server" Text="Status:"></asp:Label><asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label1" runat="server" Text="Requestor:"></asp:Label><asp:Label ID="lblRequestor" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text="Latitude:"></asp:Label><asp:Label ID="lblLatitude" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Text="Longitude:"></asp:Label><asp:Label ID="lblLongitude" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label6" runat="server" Text="Output frequency:"></asp:Label><asp:Label ID="lblOutputFrequency" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label8" runat="server" Text="Power:"></asp:Label><asp:Label ID="lblPower" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label10" runat="server" Text="Altitude:"></asp:Label><asp:Label ID="lblAltitude" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label12" runat="server" Text="Antenna height:"></asp:Label><asp:Label ID="lblAntennaHeight" runat="server" Text="Label"></asp:Label><br />
		</p>
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
        <h2>My response</h2>
        <div id="divResponseForm">
            Status: <asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem Value="1">Requested</asp:ListItem>
                <asp:ListItem Value="2">Approved</asp:ListItem>
                <asp:ListItem Value="3">Declined</asp:ListItem>
            </asp:DropDownList><br />
            Note/Reason: <asp:TextBox ID="txtNote" Width="400px" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please write a note or give a reason for declining this request." OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit changes" OnClick="btnSubmit_Click" />
        </div>
    </section>
</asp:Content>

