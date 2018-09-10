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
        <p style="font-size: 0.7em;"><strong>Want a faster response?</strong> The easiest way to ensure a speedy, positive response is to submit a request <em>without</em> a frequency preference. This will give the coordinators the leeway to find any open frequency on your behalf.</p>

        <asp:Label ID="Label9" runat="server" Text="Name" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtPersonName" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox><br />
        <asp:Label ID="Label10" runat="server" Text="Callsign" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtPersonCallsign" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox><br />
        <asp:Label ID="Label11" runat="server" Text="Email address" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtEmail" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Band" CssClass="formLabel"></asp:Label><ajaxToolkit:ComboBox ID="cmbBand" runat="server" CssClass="textInput">
            <asp:ListItem>10 Meters (28-29.7 MHz)</asp:ListItem>
            <asp:ListItem>6 Meters (50-54 MHz)</asp:ListItem>
            <asp:ListItem>2 Meters (144-148 MHz)</asp:ListItem>
            <asp:ListItem>1.25 Meters (222-225 MHz)</asp:ListItem>
            <asp:ListItem>70 Centimeters (420-450 MHz)</asp:ListItem>
            <asp:ListItem>33 Centimeters (902-928 MHz)</asp:ListItem>
            <asp:ListItem Selected="True">Any</asp:ListItem>
        </ajaxToolkit:ComboBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Latitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLatitude" runat="server" CssClass="textInput" placeholder="00.0000"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="txtLatitude_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox2_FilteredTextBoxExtender" TargetControlID="txtLatitude" ValidChars="-.0123456789" />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Longitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="Longitude" runat="server" CssClass="textInput" placeholder="-00.0000"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="Longitude_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox3_FilteredTextBoxExtender" TargetControlID="Longitude" ValidChars="-.0123456789" />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Output power" CssClass="formLabel"></asp:Label><asp:TextBox ID="TextBox4" runat="server" CssClass="textInput" placeholder="watts"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="TextBox4_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox4_FilteredTextBoxExtender" TargetControlID="TextBox4" ValidChars="0123456789" />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Altitude in meters from sea level" CssClass="formLabel"></asp:Label><asp:TextBox ID="TextBox5" runat="server" placeholder="meters" CssClass="textInput"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="TextBox5_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox5_FilteredTextBoxExtender" TargetControlID="TextBox5" ValidChars="0123456789" />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Antenna height in meters" CssClass="formLabel"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" CssClass="textInput" placeholder="meters"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="TextBox6_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox6_FilteredTextBoxExtender" TargetControlID="TextBox6" ValidChars="0123456789" />
        <br />
        <br />
        <h3>Optional</h3>
        <asp:Label ID="Label2" runat="server" Text="Preferred frequency" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtFrequency" runat="server" CssClass="textInput" placeholder="Leave blank if no preference"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="Nearby frequency is acceptable" CssClass="formLabel"></asp:Label><asp:CheckBox ID="chkNearbyFreqOk" runat="server" TextAlign="Left" Checked="True" />
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        <br />
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>

