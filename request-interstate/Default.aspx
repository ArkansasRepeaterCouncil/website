<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="request_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .textInput {
            margin-left: 5px;
            margin-right: 15px;
            width: 200px;
        }
        .textInputShort {
            margin-left: 5px;
            margin-right: 15px;
            width: 50px;
        }
        .formLabel {
            text-align: right;
            display: inline-block;
            width: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    Coordination request
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <asp:Panel ID="Panel1" runat="server">
        <p>Complete the form below to submit a coordination request.</p>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        <asp:Label ID="Label9" runat="server" Text="Name" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtPersonName" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Name is required, but you must enter that on the Profile page." ControlToValidate="txtPersonName">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Callsign" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtPersonCallsign" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Callsign is required, but you must enter that on the Profile page." ControlToValidate="txtPersonCallsign">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Email address" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtEmail" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Email address is required, but you must enter that on the Profile page." ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email address is not valid." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Coordinate measurement" CssClass="formLabel"></asp:Label><asp:RadioButtonList ID="rbCoordinates" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbCoordinates_SelectedIndexChanged" RepeatLayout="Flow">
                <asp:ListItem Selected="True">Decimal</asp:ListItem>
                <asp:ListItem>Degrees, minutes, seconds</asp:ListItem>
            </asp:RadioButtonList>
        <br />
        <asp:Panel ID="pnlCoordDms" Visible="false" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Latitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLatitudeDeg" runat="server" CssClass="textInputShort" placeholder="0"></asp:TextBox><asp:TextBox ID="txtLatitudeMin" runat="server" CssClass="textInputShort" placeholder="0"></asp:TextBox><asp:TextBox ID="txtLatitudeSec" runat="server" CssClass="textInputShort" placeholder="0.0"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" BehaviorID="TextBox2_FilteredTextBoxExtender" TargetControlID="txtLatitudeDeg" ValidChars="-.0123456789" />
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" BehaviorID="TextBox2_FilteredTextBoxExtender" TargetControlID="txtLatitudeMin" ValidChars="-.0123456789" />
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" BehaviorID="TextBox2_FilteredTextBoxExtender" TargetControlID="txtLatitudeSec" ValidChars="-.0123456789" />
            <asp:CustomValidator ID="validatorLatitudeDms" Enabled="false" runat="server" ControlToValidate="txtLatitudeDeg" ErrorMessage="Latitude is not in the U.S." OnServerValidate="validatorLatitude_ServerValidate">*</asp:CustomValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Longitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLongitudeDeg" runat="server" CssClass="textInputShort" placeholder="0"></asp:TextBox><asp:TextBox ID="txtLongitudeMin" runat="server" CssClass="textInputShort" placeholder="0"></asp:TextBox><asp:TextBox ID="txtLongitudeSec" runat="server" CssClass="textInputShort" placeholder="0.0"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" BehaviorID="TextBox3_FilteredTextBoxExtender" TargetControlID="txtLongitudeDeg" ValidChars="-.0123456789" />
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" BehaviorID="TextBox3_FilteredTextBoxExtender" TargetControlID="txtLongitudeMin" ValidChars="-.0123456789" />
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" BehaviorID="TextBox3_FilteredTextBoxExtender" TargetControlID="txtLongitudeSec" ValidChars="-.0123456789" />
            <asp:CustomValidator ID="validatorLongitudeDms" Enabled="false" runat="server" ControlToValidate="txtLatitudeDeg" ErrorMessage="Longitude is not in the U.S." OnServerValidate="validatorLongitude_ServerValidate">*</asp:CustomValidator>
        </asp:Panel>
        <asp:Panel ID="pnlCoordDec" runat="server">
            <asp:Label ID="Label4" runat="server" Text="Latitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLatitude" runat="server" CssClass="textInput" placeholder="00.0000"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="txtLatitude_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox2_FilteredTextBoxExtender" TargetControlID="txtLatitude" ValidChars="-.0123456789" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Latitude is required." ControlToValidate="txtLatitude">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="validatorLatitude" runat="server" ControlToValidate="txtLatitude" ErrorMessage="Latitude is not in the U.S." OnServerValidate="validatorLatitude_ServerValidate">*</asp:CustomValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Longitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLongitude" runat="server" CssClass="textInput" placeholder="-00.0000"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="Longitude_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox3_FilteredTextBoxExtender" TargetControlID="txtLongitude" ValidChars="-.0123456789" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Longitude is required." ControlToValidate="txtLongitude">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="validatorLongitude" runat="server" ErrorMessage="Longitude is not in the U.S." OnServerValidate="validatorLongitude_ServerValidate">*</asp:CustomValidator>
        </asp:Panel>
        <br />

        <asp:Label ID="lblTransmitFrequency" runat="server" Text="Transmit Frequency" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtTransmitFrequency" runat="server" CssClass="textInput" placeholder="000.0000"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" BehaviorID="txtTransmitFrequency_FilteredTextBoxExtender" TargetControlID="txtTransmitFrequency" ValidChars=".0123456789" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Transmit frequency is required." ControlToValidate="txtTransmitFrequency">*</asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="lblReceiveFrequency" runat="server" Text="Receive Frequency" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtReceiveFrequency" runat="server" CssClass="textInput" placeholder="000.0000"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" BehaviorID="txtReceiveFrequency_FilteredTextBoxExtender" TargetControlID="txtReceiveFrequency" ValidChars=".0123456789" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Receive frequency is required." ControlToValidate="txtReceiveFrequency">*</asp:RequiredFieldValidator>
        <br />

        <div class="center">
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></div>
        <br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="lblAnswer" runat="server" Text=""></asp:Label>
        </asp:Panel>
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>

