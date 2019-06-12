<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="update_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" rel="stylesheet" href="/css/update.css" />
    <style type="text/css">
        input[readonly="readonly"], select[readonly="readonly"], input[disabled="disabled"], select[disabled="disabled"]  {
            color: #ffffff;
            outline: none;
            background-color: transparent;
            border: 0px solid;
            border-bottom: 1px solid #424242;
            margin-left: 15px;
        }
        select[disabled="disabled"]::-ms-expand {	display: none; }
        select[disabled="disabled"] {
            -webkit-appearance: none;
            appearance: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <h1><asp:Label ID="lblRepeaterName" runat="server" Text="Label"></asp:Label></h1>
        <div id="repeaterActionButtons">
            <asp:Label ID="lblOffTheAir" runat="server" ForeColor="#3399FF" Text="Repeater reported to be off-the-air." Visible="False"></asp:Label>
            &nbsp;<asp:LinkButton ID="btnUpdate" runat="server" Visible="False">Edit</asp:LinkButton>
            <asp:Button ID="btnReport" runat="server" Text="Report as off-the-air" Enabled="false" ToolTip="Must be logged in" OnClick="btnReport_Click" OnClientClick="return confirm('This will inform the coordinators that you are reporting this repeater to be off-the-air.\r\n\r\nAre you sure?');" />
        </div>
        <asp:Panel ID="formPanel" runat="server" ClientIDMode="Static">
            <div id="tabs">
                <ul>
                    <li><a href="#tab-1">Details</a></li>
                    <li><a href="#tab-2">Digital modes</a></li>
                    <li><a href="#tab-3">Options</a></li>
                    <li><a href="#tab-4">Metadata</a></li>
                </ul>
            
                <div id="tab-1">
                    <asp:Label ID="lblType" CssClass="formLabel" runat="server" Text="Type"></asp:Label><asp:DropDownList ID="ddlType" CssClass="textInput" runat="server">
                        <asp:ListItem Value="1">Repeater</asp:ListItem>
                        <asp:ListItem Value="2">Link</asp:ListItem>
                        <asp:ListItem Value="3">Control</asp:ListItem>
                        <asp:ListItem Value="4">Packet</asp:ListItem>
                        <asp:ListItem Value="5">Beacon</asp:ListItem>
                        <asp:ListItem Value="6">Amateur TV</asp:ListItem>
                        <asp:ListItem Value="7">Remote base</asp:ListItem>
                        <asp:ListItem Value="8">Closed repeater</asp:ListItem>
                        <asp:ListItem Value="9">None</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblRepeaterCallsign" CssClass="formLabel" runat="server" Text="Repeater callsign"></asp:Label><asp:TextBox ID="txtRepeaterCallsign" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblTrusteeID" CssClass="formLabel" runat="server" Text="Trustee"></asp:Label><asp:TextBox ID="txtTrusteeCallsign" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblStatus" CssClass="formLabel" runat="server" Text="Status"></asp:Label><asp:DropDownList ID="ddlStatus" runat="server" CssClass="textInput">
                        <asp:ListItem Value="1">Proposed</asp:ListItem>
                        <asp:ListItem Value="2">Under construction</asp:ListItem>
                        <asp:ListItem Value="3">Operational</asp:ListItem>
                        <asp:ListItem Value="4">Temporarily off-the-air</asp:ListItem>
                        <asp:ListItem Value="5">Suspected off-the-air</asp:ListItem>
                        <asp:ListItem Value="6">De-coordinated</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblCity" CssClass="formLabel" runat="server" Text="City"></asp:Label><asp:TextBox ID="txtCity" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblSiteName" CssClass="formLabel" runat="server" Text="Site description"></asp:Label><asp:TextBox ID="txtSiteName" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblOutputFrequency" CssClass="formLabel" runat="server" Text="Transmit frequency"></asp:Label><asp:TextBox ID="txtOutputFrequency" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblInputFrequency" CssClass="formLabel" runat="server" Text="Receive frequency"></asp:Label><asp:TextBox ID="txtInputFrequency" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblSponsor" CssClass="formLabel" runat="server" Text="Sponsor/Club"></asp:Label><asp:TextBox ID="txtSponsor" placeholder="Leave blank if none" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblLatitude" CssClass="formLabel" runat="server" Text="Latitude"></asp:Label><asp:TextBox ID="txtLatitude" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblLongitude" CssClass="formLabel" runat="server" Text="Longitude"></asp:Label><asp:TextBox ID="txtLongitude" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblAMSL" CssClass="formLabel" runat="server" Text="Altitude"></asp:Label><asp:TextBox ID="txtAMSL" CssClass="textInput" runat="server" placeholder="meters"> meters</asp:TextBox>
                    <br />
                    <asp:Label ID="lblERP" CssClass="formLabel" runat="server" Text="Effective radiated power (ERP)"></asp:Label><asp:TextBox ID="txtERP" CssClass="textInput" runat="server"> watts</asp:TextBox><br />
                    <asp:Label ID="lblOutputPower" CssClass="formLabel" runat="server" Text="Output power"></asp:Label><asp:TextBox ID="txtOutputPower" CssClass="textInput" runat="server"> watts</asp:TextBox><br />
                    <asp:Label ID="lblAntennaGain" CssClass="formLabel" runat="server" Text="Antenna gain"></asp:Label><asp:TextBox ID="txtAntennaGain" CssClass="textInput" runat="server"> DBi</asp:TextBox><br />
                    <asp:Label ID="lblAntennaHeight" CssClass="formLabel" runat="server" Text="Antenna height"></asp:Label><asp:TextBox ID="txtAntennaHeight" CssClass="textInput" runat="server" placeholder="meters"></asp:TextBox><br />
                    <asp:Label ID="lblAnalog_InputAccess" CssClass="formLabel" runat="server" Text="Input PL tone"></asp:Label><asp:TextBox ID="txtAnalog_InputAccess" placeholder="Leave blank if none" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblAnalog_OutputAccess" CssClass="formLabel" runat="server" Text="Output PL tone"></asp:Label><asp:TextBox ID="txtAnalog_OutputAccess" placeholder="Leave blank if none" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblAnalog_Width" CssClass="formLabel" runat="server" Text="Analog width"></asp:Label><asp:TextBox ID="txtAnalog_Width" CssClass="textInput" runat="server"></asp:TextBox>
                </div>
                <div id="tab-2">
                    <asp:Label ID="lblDSTAR_Module" CssClass="formLabel" runat="server" Text="D-STAR module"></asp:Label>
                    <asp:DropDownList ID="ddlDSTARmodule" runat="server" CssClass="textInput">
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                        <asp:ListItem Value="">Not applicable</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblDMR_ColorCode" CssClass="formLabel" runat="server" Text="DMR color code"></asp:Label>
                    <asp:DropDownList ID="ddlDMR_ColorCode" runat="server" CssClass="textInput">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem Value="">Not applicable</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblDMR_ID" CssClass="formLabel" runat="server" Text="DMR ID"></asp:Label><asp:TextBox ID="txtDMR_ID" CssClass="textInput" placeholder="Leave blank if none" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblDMR_Network" CssClass="formLabel" runat="server" Text="DMR network"></asp:Label>
                    <asp:DropDownList ID="ddlDMR_Network" runat="server" CssClass="textInput">
                        <asp:ListItem>Brandmeister</asp:ListItem>
                        <asp:ListItem>DMR-MARC</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                        <asp:ListItem Value="">Not applicable</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblP25_NAC" CssClass="formLabel" runat="server" Text="P25 NAC"></asp:Label><asp:TextBox ID="txtP25_NAC" placeholder="Leave blank if none" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblNXDN_RAN" CssClass="formLabel" runat="server" Text="NXDN RAN"></asp:Label><asp:TextBox ID="txtNXDN_RAN" placeholder="Leave blank if none" CssClass="textInput" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblYSF_DSQ" CssClass="formLabel" runat="server" Text="YSF DSQ"></asp:Label><asp:TextBox ID="txtYSF_DSQ" placeholder="Leave blank if none" CssClass="textInput" runat="server"></asp:TextBox>
                </div>
                <div id="tab-3">
                        <asp:Label ID="lblYSF_DSQ0" runat="server" CssClass="formLabel" Text="Autopatch"></asp:Label>
                        <asp:DropDownList ID="ddlAutopatch" runat="server" CssClass="textInput">
                            <asp:ListItem Value="0">None</asp:ListItem>
                            <asp:ListItem Value="1">Open</asp:ListItem>
                            <asp:ListItem Value="3">Closed</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:CheckBox ID="chkEmergencyPower" runat="server" Text="Emergency power" TextAlign="Left" CssClass="chkInput" /><br />
                        <asp:CheckBox ID="chkLinked" runat="server" Text="Linked" TextAlign="Left" CssClass="chkInput" /><br />
                        <asp:CheckBox ID="chkRACES" runat="server" Text="RACES" TextAlign="Left" CssClass="chkInput" /><br />
                        <asp:CheckBox ID="chkARES" runat="server" Text="ARES" TextAlign="Left" CssClass="chkInput" /><br />
                        <asp:CheckBox ID="chkWideArea" runat="server" Text="Wide area" TextAlign="Left" CssClass="chkInput" /><br />
                        <asp:CheckBox ID="chkWeather" runat="server" Text="Weather net" TextAlign="Left" CssClass="chkInput" /><br />
                        <asp:CheckBox ID="chkExperimental" runat="server" Text="Experimental" TextAlign="Left" CssClass="chkInput" />
                </div>
                <div id="tab-4">
                    <asp:Label ID="lblID" CssClass="formLabel" runat="server" Text="Internal ID"></asp:Label><asp:TextBox ID="txtID" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblDateCoordinated" CssClass="formLabel" runat="server" Text="Date coordinated"></asp:Label><asp:TextBox ID="txtDateCoordinated" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblDateUpdated" CssClass="formLabel" runat="server" Text="Date updated"></asp:Label><asp:TextBox ID="txtDateUpdated" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblDateDecoordinated" CssClass="formLabel" runat="server" Text="Date decoordinated"></asp:Label><asp:TextBox ID="txtDateDecoordinated" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblDateCoordinationSource" CssClass="formLabel" runat="server" Text="Date coordination source"></asp:Label><asp:TextBox ID="txtDateCoordinationSource" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblDateConstruction" CssClass="formLabel" runat="server" Text="Date construction"></asp:Label><asp:TextBox ID="txtDateConstruction" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblState" CssClass="formLabel" runat="server" Text="State"></asp:Label><asp:TextBox ID="txtState" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblCoordinatedOutputPower" CssClass="formLabel" runat="server" Text="Coordinated output power"></asp:Label><asp:TextBox ID="txtCoordinatedOutputPower" runat="server" CssClass="textInput" ReadOnly="true"></asp:TextBox><br />
                    <asp:Label ID="Label1" CssClass="formLabel" runat="server" Text="Coordinated antenna height"></asp:Label><asp:TextBox ID="txtCoordinatedAntennaHeight" runat="server" CssClass="textInput" ReadOnly="true"></asp:TextBox><br />
                    <asp:Label ID="Label2" CssClass="formLabel" runat="server" Text="Coordinated latitude"></asp:Label><asp:TextBox ID="txtCoordinatedLatitude" runat="server" CssClass="textInput" ReadOnly="true"></asp:TextBox><br />
                    <asp:Label ID="Label3" CssClass="formLabel" runat="server" Text="Coordinated longitude"></asp:Label><asp:TextBox ID="txtCoordinatedLongitude" runat="server" CssClass="textInput" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </asp:Panel>
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>

