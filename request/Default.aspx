<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="request_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

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
            width: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    Coordination request
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <p>Complete the form below to submit a coordination request.</p>
		<p>NOTE: If you are a coordinator from outside of our state, this is not the correct form. Please log out and log back in.  If you continue to have problems please contact us using the blue button in the bottom right corner of any page.</p>

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
        <asp:Label ID="Label4" runat="server" Text="Latitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLatitude" runat="server" CssClass="textInput" placeholder="00.0000"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="txtLatitude_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox2_FilteredTextBoxExtender" TargetControlID="txtLatitude" ValidChars="-.0123456789" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Latitude is required." ControlToValidate="txtLatitude">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="validatorLatitude" runat="server" ControlToValidate="txtLatitude" ErrorMessage="Latitude is not in the U.S." OnServerValidate="validatorLatitude_ServerValidate">*</asp:CustomValidator>
        <asp:CustomValidator ID="validatorLatitude2" runat="server" ControlToValidate="txtLatitude" ErrorMessage="Latitude is not precise enough. Provide at least four decimal digits." OnServerValidate="validatorLatitude_ServerValidate2">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Longitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLongitude" runat="server" CssClass="textInput" placeholder="-00.0000"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="Longitude_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox3_FilteredTextBoxExtender" TargetControlID="txtLongitude" ValidChars="-.0123456789" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Longitude is required." ControlToValidate="txtLongitude">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="validatorLongitude" runat="server" ErrorMessage="Longitude is not in the U.S." OnServerValidate="validatorLongitude_ServerValidate">*</asp:CustomValidator>
        <asp:CustomValidator ID="validatorLongitude2" runat="server" ErrorMessage="Longitude is not precise enough. Provide at least four decimal digits." OnServerValidate="validatorLongitude_ServerValidate2">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Output power" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtOutputPower" runat="server" CssClass="textInput" placeholder="watts"></asp:TextBox> watts
        <ajaxToolkit:FilteredTextBoxExtender ID="TextBox4_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox4_FilteredTextBoxExtender" TargetControlID="txtOutputPower" ValidChars="0123456789" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Output power is required." ControlToValidate="txtOutputPower">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Antenna height" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtAntennaHeight" runat="server" CssClass="textInput" placeholder="meters"></asp:TextBox> meters
        <ajaxToolkit:FilteredTextBoxExtender ID="TextBox6_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox6_FilteredTextBoxExtender" TargetControlID="txtAntennaHeight" ValidChars="0123456789." />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Antenna height is required." ControlToValidate="txtAntennaHeight">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Band" CssClass="formLabel"></asp:Label>
        <asp:DropDownList ID="ddlBand" runat="server" CssClass="textInput">
            <asp:ListItem>23cm</asp:ListItem>
            <asp:ListItem>33cm</asp:ListItem>
            <asp:ListItem Value="70cm" Selected="True">70cm</asp:ListItem>
            <asp:ListItem>1.25m</asp:ListItem>
            <asp:ListItem>10m</asp:ListItem>
            <asp:ListItem>2m</asp:ListItem>
            <asp:ListItem>6m</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="lblFrequency" runat="server" Text="Frequency pair" CssClass="formLabel" Visible="False"></asp:Label>
        <asp:DropDownList ID="ddlFrequency" runat="server" CssClass="textInput" Visible="False">
        </asp:DropDownList>
        <br />
        <br />
        Please keep in mind that the frequencies listed are those that our database show to be available - there may be someone using a frequency that is not coordinated. Please monitor the desired frequency before submitting your request.<br />
        <br />
        <div class="center">
            <asp:Button ID="bttnNext" runat="server" OnClick="bttnNext_Click" Text="Next" />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Visible="false" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></div>
        <br />
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>

