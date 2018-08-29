<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="update_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .textInput {
            margin-left: 5px;
            margin-right: 15px;
            width: 200px;
        }
        .formLabel {
            text-align: right;
            display: inline-block;
            width: 400px;
        }
        input[readonly="readonly"] {
            background-color: #808080;
            color: #000000;
        }
        input[readonly="readonly"]:after {
           content: " *";
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <h1><asp:Label ID="lblRepeaterName" runat="server" Text="Label"></asp:Label></h1>
        <p>Note: Some fields are disabled because changing them would require re-coordination.</p>
        <asp:Panel ID="formPanel" runat="server" ClientIDMode="Static">

            <asp:HiddenField ID="hdnOriginalRepeater" runat="server" />
            <asp:Label ID="lblID" CssClass="formLabel" runat="server" Text="ID"></asp:Label><asp:TextBox ID="txtID" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblType" CssClass="formLabel" runat="server" Text="Type"></asp:Label><asp:TextBox ID="txtType" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblRepeaterCallsign" CssClass="formLabel" runat="server" Text="RepeaterCallsign"></asp:Label><asp:TextBox ID="txtRepeaterCallsign" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblTrusteeID" CssClass="formLabel" runat="server" Text="TrusteeID"></asp:Label><asp:TextBox ID="txtTrusteeID" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblStatus" CssClass="formLabel" runat="server" Text="Status"></asp:Label><asp:TextBox ID="txtStatus" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCity" CssClass="formLabel" runat="server" Text="City"></asp:Label><asp:TextBox ID="txtCity" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblSiteName" CssClass="formLabel" runat="server" Text="SiteName"></asp:Label><asp:TextBox ID="txtSiteName" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblOutputFrequency" CssClass="formLabel" runat="server" Text="OutputFrequency"></asp:Label><asp:TextBox ID="txtOutputFrequency" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblInputFrequency" CssClass="formLabel" runat="server" Text="InputFrequency"></asp:Label><asp:TextBox ID="txtInputFrequency" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblSponsor" CssClass="formLabel" runat="server" Text="Sponsor"></asp:Label><asp:TextBox ID="txtSponsor" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblLatitude" CssClass="formLabel" runat="server" Text="Latitude"></asp:Label><asp:TextBox ID="txtLatitude" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblLongitude" CssClass="formLabel" runat="server" Text="Longitude"></asp:Label><asp:TextBox ID="txtLongitude" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAMSL" CssClass="formLabel" runat="server" Text="AMSL"></asp:Label><asp:TextBox ID="txtAMSL" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblERP" CssClass="formLabel" runat="server" Text="ERP"></asp:Label><asp:TextBox ID="txtERP" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblOutputPower" CssClass="formLabel" runat="server" Text="OutputPower"></asp:Label><asp:TextBox ID="txtOutputPower" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAntennaGain" CssClass="formLabel" runat="server" Text="AntennaGain"></asp:Label><asp:TextBox ID="txtAntennaGain" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAntennaHeight" CssClass="formLabel" runat="server" Text="AntennaHeight"></asp:Label><asp:TextBox ID="txtAntennaHeight" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAnalog_InputAccess" CssClass="formLabel" runat="server" Text="Analog_InputAccess"></asp:Label><asp:TextBox ID="txtAnalog_InputAccess" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAnalog_OutputAccess" CssClass="formLabel" runat="server" Text="Analog_OutputAccess"></asp:Label><asp:TextBox ID="txtAnalog_OutputAccess" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAnalog_Width" CssClass="formLabel" runat="server" Text="Analog_Width"></asp:Label><asp:TextBox ID="txtAnalog_Width" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDSTAR_Module" CssClass="formLabel" runat="server" Text="DSTAR_Module"></asp:Label><asp:TextBox ID="txtDSTAR_Module" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDMR_ColorCode" CssClass="formLabel" runat="server" Text="DMR_ColorCode"></asp:Label><asp:TextBox ID="txtDMR_ColorCode" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDMR_ID" CssClass="formLabel" runat="server" Text="DMR_ID"></asp:Label><asp:TextBox ID="txtDMR_ID" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDMR_Network" CssClass="formLabel" runat="server" Text="DMR_Network"></asp:Label><asp:TextBox ID="txtDMR_Network" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblP25_NAC" CssClass="formLabel" runat="server" Text="P25_NAC"></asp:Label><asp:TextBox ID="txtP25_NAC" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblNXDN_RAN" CssClass="formLabel" runat="server" Text="NXDN_RAN"></asp:Label><asp:TextBox ID="txtNXDN_RAN" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblYSF_DSQ" CssClass="formLabel" runat="server" Text="YSF_DSQ"></asp:Label><asp:TextBox ID="txtYSF_DSQ" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAutopatch" CssClass="formLabel" runat="server" Text="Autopatch"></asp:Label><asp:TextBox ID="txtAutopatch" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblEmergencyPower" CssClass="formLabel" runat="server" Text="EmergencyPower"></asp:Label><asp:TextBox ID="txtEmergencyPower" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblLinked" CssClass="formLabel" runat="server" Text="Linked"></asp:Label><asp:TextBox ID="txtLinked" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblRACES" CssClass="formLabel" runat="server" Text="RACES"></asp:Label><asp:TextBox ID="txtRACES" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblARES" CssClass="formLabel" runat="server" Text="ARES"></asp:Label><asp:TextBox ID="txtARES" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblWideArea" CssClass="formLabel" runat="server" Text="WideArea"></asp:Label><asp:TextBox ID="txtWideArea" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblWeather" CssClass="formLabel" runat="server" Text="Weather"></asp:Label><asp:TextBox ID="txtWeather" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblExperimental" CssClass="formLabel" runat="server" Text="Experimental"></asp:Label><asp:TextBox ID="txtExperimental" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDateCoordinated" CssClass="formLabel" runat="server" Text="DateCoordinated"></asp:Label><asp:TextBox ID="txtDateCoordinated" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDateUpdated" CssClass="formLabel" runat="server" Text="DateUpdated"></asp:Label><asp:TextBox ID="txtDateUpdated" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDateDecoordinated" CssClass="formLabel" runat="server" Text="DateDecoordinated"></asp:Label><asp:TextBox ID="txtDateDecoordinated" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDateCoordinationSource" CssClass="formLabel" runat="server" Text="DateCoordinationSource"></asp:Label><asp:TextBox ID="txtDateCoordinationSource" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDateConstruction" CssClass="formLabel" runat="server" Text="DateConstruction"></asp:Label><asp:TextBox ID="txtDateConstruction" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCoordinatorComments" CssClass="formLabel" runat="server" Text="CoordinatorComments"></asp:Label><asp:TextBox ID="txtCoordinatorComments" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblNotes" CssClass="formLabel" runat="server" Text="Notes"></asp:Label><asp:TextBox ID="txtNotes" CssClass="textInput" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblState" CssClass="formLabel" runat="server" Text="State"></asp:Label><asp:TextBox ID="txtState" CssClass="textInput" runat="server"></asp:TextBox><br />

        </asp:Panel>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /> &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </section>

</asp:Content>

