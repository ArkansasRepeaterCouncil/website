<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="update_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" rel="stylesheet" href="../css/update.css" />
    <script>
        function ddlStatus_change_client(source) {
            if (source.options[source.selectedIndex].value == "6") {
                alert("STOP AND READ!\n\nIf you change the status to decoordinated and save this record, you will not be able to change it back.  If that's not your intention, change it back before you save.");
            }
        }

        function btnChangeTrustee_click() {
            alert("STOP AND READ!\n\nIf you are the current trustee and you change it to someone else, you will not be able to access this repeater unless you are added as an authorized user (in the Users tab).");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <h1><asp:Label ID="lblRepeaterName" runat="server" Text="Label"></asp:Label></h1>
        <asp:Label ID="lblChangesSaved" runat="server" Text="Your changes have been saved." Visible="False" ForeColor="#66FF66"></asp:Label>
        <p>Every change is logged and can be seen on the <em>Notes</em> tab.</p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:HiddenField ID="hdnIsCoordinatorForRepeater" Value="" runat="server" />
        <asp:Panel ID="pnlOverride" runat="server" CssClass="pnlOverride" Visible="false">
            <p>This change is in violation of the standard procedures which require that this repeater be re-coordinated.&nbsp; However, as a coordinator if there are extenuating circumstances you may override this policy.&nbsp; By doing so you must accept that if a neighboring state receives interference, it will be all your fault and people will probably yell at you.</p>
            <asp:CheckBox ID="chkOverride" runat="server" Text="I understand and accept. Continue with override." />
        </asp:Panel>
        <asp:Panel ID="formPanel" runat="server" ClientIDMode="Static">
            <div id="tabs">
                <ul>
                    <li><a href="#tab-1">Details</a></li>
                    <li><a href="#tab-2">Links</a></li>
                    <li><a href="#tab-3">Digital modes</a></li>
                    <li><a href="#tab-4">Options</a></li>
                    <li><a href="#tab-5">Metadata</a></li>
                    <li><a href="#tab-6">Notes</a></li>
                    <li><a href="#tab-7">Users</a></li>
                </ul>
        
                <div id="tab-1" >
                        <asp:Label ID="lblType" CssClass="formLabel" runat="server" Text="Type"></asp:Label>
                        <asp:DropDownList ID="ddlType" CssClass="textInput" runat="server">
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
                        <asp:Label ID="lblTrusteeID" CssClass="formLabel" runat="server" Text="Trustee"></asp:Label><asp:HiddenField ID="hdnTrusteeId" runat="server" />
                        <asp:TextBox ID="txtTrusteeCallsign" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><asp:Button ID="btnChangeTrustee" runat="server" Text="Change" OnClientClick="btnChangeTrustee_click();" OnClick="btnChangeTrustee_Click" /><asp:DropDownList ID="ddlTrustee" Visible="False" CssClass="textInput" runat="server"></asp:DropDownList><br />
                        <asp:Label ID="lblStatus" CssClass="formLabel" runat="server" Text="Status"></asp:Label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="textInput" onchange="return ddlStatus_change_client(this);">
                            <asp:ListItem Value="1">Proposed</asp:ListItem>
                            <asp:ListItem Value="2">Under construction</asp:ListItem>
                            <asp:ListItem Value="3">Operational</asp:ListItem>
                            <asp:ListItem Value="4">Temporarily off-the-air</asp:ListItem>
                            <asp:ListItem Value="5">Suspected off-the-air</asp:ListItem>
                            <asp:ListItem Value="6">De-coordinated</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblCity" CssClass="formLabel" runat="server" Text="City"></asp:Label><asp:TextBox ID="txtCity" CssClass="textInput" runat="server" MaxLength="24"></asp:TextBox><br />
                        <asp:Label ID="lblSiteName" CssClass="formLabel" runat="server" Text="Site description"></asp:Label><asp:TextBox ID="txtSiteName" CssClass="textInput" runat="server" MaxLength="255"></asp:TextBox><br />
                        <asp:Label ID="lblOutputFrequency" CssClass="formLabel" runat="server" Text="Transmit frequency"></asp:Label><asp:TextBox ID="txtOutputFrequency" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                        <asp:Label ID="lblInputFrequency" CssClass="formLabel" runat="server" Text="Receive frequency"></asp:Label><asp:TextBox ID="txtInputFrequency" CssClass="textInput" runat="server" ReadOnly="True"></asp:TextBox><br />
                        <asp:Label ID="lblSponsor" CssClass="formLabel" runat="server" Text="Sponsor/Club"></asp:Label><asp:TextBox ID="txtSponsor" placeholder="Leave blank if none" CssClass="textInput" runat="server" MaxLength="100"></asp:TextBox><br />
                        <asp:Label ID="lblLatitude" CssClass="formLabel" runat="server" Text="Latitude"></asp:Label><asp:TextBox ID="txtLatitude" CssClass="textInput" runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtLatitude_FilteredTextBoxExtender" runat="server" BehaviorID="txtLatitude_FilteredTextBoxExtender" TargetControlID="txtLatitude" ValidChars="1234567890." />
                        <asp:CustomValidator ID="validLocation" runat="server" ErrorMessage="Location may not be more than one mile from the repeater's coordinated location." OnServerValidate="validLocation_ServerValidate">*</asp:CustomValidator>
                        <asp:CustomValidator ID="validLocation2" runat="server" ErrorMessage="The latitude / longitude provided is not valid. These must be in decimal format (i.e. 34.0000, -92.0000)" OnServerValidate="validLocation2_ServerValidate" ControlToValidate="txtLatitude">*</asp:CustomValidator>
                        <br />
                        <asp:Label ID="lblLongitude" CssClass="formLabel" runat="server" Text="Longitude"></asp:Label><asp:TextBox ID="txtLongitude" CssClass="textInput" runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtLongitude_FilteredTextBoxExtender" runat="server" BehaviorID="txtLongitude_FilteredTextBoxExtender" TargetControlID="txtLongitude" ValidChars="1234567890.-" />
                        <br />
                        <asp:Label ID="lblAMSL" CssClass="formLabel" runat="server" Text="Altitude"></asp:Label><asp:TextBox ID="txtAMSL" CssClass="textInput" runat="server" placeholder="meters"> meters</asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAMSL_FilteredTextBoxExtender" runat="server" BehaviorID="txtAMSL_FilteredTextBoxExtender" TargetControlID="txtAMSL" ValidChars="1234567890." />
                        meters<br />
                        <asp:Label ID="lblERP" runat="server" CssClass="formLabel" Text="Effective radiated power (ERP)"></asp:Label>
                        <asp:TextBox ID="txtERP" runat="server" CssClass="textInput"> watts</asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtERP_FilteredTextBoxExtender" runat="server" BehaviorID="txtERP_FilteredTextBoxExtender" TargetControlID="txtERP" ValidChars="1234567890." />
                        <a href="http://antennas.ca/calc_ERP.htm" target="_blank">Calculator</a><br />
                        <asp:Label ID="lblOutputPower" CssClass="formLabel" runat="server" Text="Output power"></asp:Label><asp:TextBox ID="txtOutputPower" CssClass="textInput" runat="server"> watts</asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtOutputPower_FilteredTextBoxExtender" runat="server" BehaviorID="txtOutputPower_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="txtOutputPower" ValidChars="0123456789" />
                        <asp:CustomValidator ID="validOutputPower" runat="server" ErrorMessage="Output power may not be more than 5 watts over the coordinated power." Text="*" OnServerValidate="validOutputPower_ServerValidate"></asp:CustomValidator><br />
                        <asp:Label ID="lblAntennaGain" CssClass="formLabel" runat="server" Text="Antenna gain"></asp:Label><asp:TextBox ID="txtAntennaGain" CssClass="textInput" runat="server"> DBi</asp:TextBox> DBi
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAntennaGain_FilteredTextBoxExtender" runat="server" BehaviorID="txtAntennaGain_FilteredTextBoxExtender" TargetControlID="txtAntennaGain" ValidChars="1234567890." />
                        <br />
                        <asp:Label ID="lblAntennaHeight" CssClass="formLabel" runat="server" Text="Antenna height"></asp:Label><asp:TextBox ID="txtAntennaHeight" CssClass="textInput" runat="server" placeholder="meters"></asp:TextBox> 
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAntennaHeight_FilteredTextBoxExtender" runat="server" BehaviorID="txtAntennaHeight_FilteredTextBoxExtender" TargetControlID="txtAntennaHeight" ValidChars="1234567890." />
                        meters<asp:CustomValidator ID="validAntennaHeight" runat="server" ErrorMessage="Antenna height is required, and may not be more than 15.24 meters (50 feet) over the coordinated antenna height." Text="*" OnServerValidate="validAntennaHeight_ServerValidate"></asp:CustomValidator><br />
                        <asp:Label ID="lblAnalog_InputAccess" CssClass="formLabel" runat="server" Text="Input PL tone"></asp:Label><asp:TextBox ID="txtAnalog_InputAccess" placeholder="Leave blank if none" CssClass="textInput" runat="server" MaxLength="7"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAnalog_InputAccess_FilteredTextBoxExtender" runat="server" BehaviorID="txtAnalog_InputAccess_FilteredTextBoxExtender" TargetControlID="txtAnalog_InputAccess" ValidChars="1234567890." />
                        <br />
                        <asp:Label ID="lblAnalog_OutputAccess" CssClass="formLabel" runat="server" Text="Output PL tone"></asp:Label><asp:TextBox ID="txtAnalog_OutputAccess" placeholder="Leave blank if none" CssClass="textInput" runat="server" MaxLength="7"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAnalog_OutputAccess_FilteredTextBoxExtender" runat="server" BehaviorID="txtAnalog_OutputAccess_FilteredTextBoxExtender" TargetControlID="txtAnalog_OutputAccess" ValidChars="1234567890." />
                        <br />
                        <asp:Label ID="lblAnalog_Width" CssClass="formLabel" runat="server" Text="Analog width"></asp:Label><asp:TextBox ID="txtAnalog_Width" CssClass="textInput" runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAnalog_Width_FilteredTextBoxExtender" runat="server" BehaviorID="txtAnalog_Width_FilteredTextBoxExtender" TargetControlID="txtAnalog_Width" ValidChars="1234567890." />
                        <br />
                        <asp:Label ID="lblAdditionalInformation" CssClass="formLabel" runat="server" Text="Additional info"></asp:Label><asp:TextBox ID="txtAdditionalInformation" CssClass="textInput" runat="server"></asp:TextBox>
                </div>
                <div id="tab-2">
                    <p>Repeaters listed here are shown to the public as being linked to this repeater.</p>

                    <asp:Panel ID="pnlAddLink" runat="server" Visible="false">
                        <asp:DropDownList ID="ddlLinks" runat="server"></asp:DropDownList><br />
                        <asp:Button ID="btnAddLink" runat="server" Text="Add this link" OnClick="btnAddLink_Click" />
                        <hr />
                    </asp:Panel>
                    <asp:Table CssClass="tblRepeaterUsers" ID="tblLinks" runat="server"></asp:Table>
                </div>
                <div id="tab-3">
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
                    <asp:Label ID="lblDMR_ID" CssClass="formLabel" runat="server" Text="DMR ID"></asp:Label><asp:TextBox ID="txtDMR_ID" CssClass="textInput" placeholder="Leave blank if none" MaxLength="20" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblDMR_Network" CssClass="formLabel" runat="server" Text="DMR network"></asp:Label>
                    <asp:DropDownList ID="ddlDMR_Network" runat="server" CssClass="textInput">
                        <asp:ListItem>Brandmeister</asp:ListItem>
                        <asp:ListItem>DMR-MARC</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                        <asp:ListItem Value="">Not applicable</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblP25_NAC" CssClass="formLabel" runat="server" Text="P25 NAC"></asp:Label><asp:TextBox ID="txtP25_NAC" placeholder="Leave blank if none" CssClass="textInput" MaxLength="4" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblNXDN_RAN" CssClass="formLabel" runat="server" Text="NXDN RAN"></asp:Label><asp:TextBox ID="txtNXDN_RAN" placeholder="Leave blank if none" CssClass="textInput" MaxLength="10" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblYSF_DSQ" CssClass="formLabel" runat="server" Text="YSF DSQ"></asp:Label><asp:TextBox ID="txtYSF_DSQ" placeholder="Leave blank if none" CssClass="textInput" MaxLength="10" runat="server"></asp:TextBox>
                </div>
                <div id="tab-4">
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
                <div id="tab-5">
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
                <div id="tab-6">
                    <asp:TextBox CssClass="txtNote" ID="txtNote" runat="server" TextMode="MultiLine" placeholder="Enter new note, make any other changes, then click save below."></asp:TextBox>
                    <asp:Label ID="lblNotes" runat="server" Text="No notes have been added for this repeater"></asp:Label>
                </div>
                <div id="tab-7">
                    <p>Users listed here will be able to edit the details of this repeater.  You can not remove the repeater trustee.</p>

                    <asp:Panel ID="pnlAddUser" runat="server" Width="600px" CssClass="pnlAddUser" Visible="false">
                        <asp:DropDownList ID="ddlAddUser" runat="server"></asp:DropDownList><br />
                        <br />
                        <asp:Button ID="btnAddUser" runat="server" Text="Add user" OnClick="btnAddUser_Click" />
                    </asp:Panel>
                    <asp:Table CssClass="tblRepeaterUsers" ID="tblRepeaterUsers" runat="server"></asp:Table>
                </div>
            </div>
        </asp:Panel>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /> &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>

