<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="profile_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        label {
            width: 200px;
            text-align: right;
            margin-right: 2px;
            display: inline-block;
        }
        input[type=text] {
            width: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		<h1>Profile</h1>
        <asp:Label ID="lblFeedback" runat="server" Text="" Visible="false"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <label>User ID:</label> <asp:TextBox ID="txtUserId" runat="server" ReadOnly="true"></asp:TextBox><br />
        <label>Callsign:</label> <asp:TextBox ID="txtCallsign" runat="server"></asp:TextBox>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCallsign" ErrorMessage="The callsign given is not a valid US callsign." ValidationExpression="[AKNWaknw][a-zA-Z]{0,2}[0123456789][a-zA-Z]{1,3}">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Callsign is required." ControlToValidate="txtCallsign">*</asp:RequiredFieldValidator>
        <br />
        <label>Full name:</label> <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullname" ErrorMessage="Full name is required">*</asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Full name is required." ControlToValidate="txtFullname">*</asp:RequiredFieldValidator>
        <br />
        <label>Mailing address:</label> <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mailing address is required." ControlToValidate="txtAddress">*</asp:RequiredFieldValidator>
        <br />
        <label>City:</label> <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="City is required." ControlToValidate="txtCity">*</asp:RequiredFieldValidator>
        <br />
        <label>State:</label> <asp:TextBox ID="txtState" runat="server">AR</asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="State is required." ControlToValidate="txtState">*</asp:RequiredFieldValidator>
        <br />
        <label>ZIP code:</label> <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="txtZip_FilteredTextBoxExtender" runat="server" BehaviorID="txtZip_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="txtZip">
        </ajaxToolkit:FilteredTextBoxExtender>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="ZIP code is required." ControlToValidate="txtZip">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="ZIP code is not valid." ValidationExpression="\d{5}(-\d{4})?" ControlToValidate="txtZip">*</asp:RegularExpressionValidator>
        <br />
        <label>Email:</label> <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required.">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email address provided is not valid." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <br />
        <label>Home phone:</label> <asp:TextBox ID="txtPhoneHome" runat="server"></asp:TextBox>
        <ajaxToolkit:MaskedEditExtender ID="txtPhoneHome_MaskedEditExtender" runat="server" BehaviorID="txtPhoneHome_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" TargetControlID="txtPhoneHome" MaskType="Number" Mask="(999) 999-9999" ClearMaskOnLostFocus="True" ClearTextOnInvalid="True" />
        <br />
        <label>Cell phone:</label> <asp:TextBox ID="txtPhoneCell" runat="server"></asp:TextBox>
        <ajaxToolkit:MaskedEditExtender ID="txtPhoneCell_MaskedEditExtender" runat="server" BehaviorID="txtPhoneCell_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" TargetControlID="txtPhoneCell" MaskType="Number" Mask="(999) 999-9999" ClearTextOnInvalid="True" ClearMaskOnLostFocus="True" />
        <br />
        <label>Work phone:</label> <asp:TextBox ID="txtPhoneWork" runat="server"></asp:TextBox>
        <ajaxToolkit:MaskedEditExtender ID="txtPhoneWork_MaskedEditExtender" runat="server" BehaviorID="txtPhoneWork_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" TargetControlID="txtPhoneWork" MaskType="Number" Mask="(999) 999-9999" ClearMaskOnLostFocus="True" ClearTextOnInvalid="True" />
        <br />
        <br />
        <label>New password:</label><asp:TextBox ID="txtPassword1" runat="server" TextMode="Password"></asp:TextBox><br />
        <label>Confirm:</label><asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword1" ControlToValidate="txtPassword2" ErrorMessage="The new password and confirmation fields do not match.">*</asp:CompareValidator>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /> <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </section>
</asp:Content>

