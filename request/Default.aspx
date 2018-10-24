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

        <asp:Label ID="Label9" runat="server" Text="Name" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtPersonName" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox><br />
        <asp:Label ID="Label10" runat="server" Text="Callsign" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtPersonCallsign" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox><br />
        <asp:Label ID="Label11" runat="server" Text="Email address" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtEmail" runat="server" CssClass="textInput" ReadOnly="True"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Latitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLatitude" runat="server" CssClass="textInput" placeholder="00.0000"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="txtLatitude_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox2_FilteredTextBoxExtender" TargetControlID="txtLatitude" ValidChars="-.0123456789" />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Longitude" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtLongitude" runat="server" CssClass="textInput" placeholder="-00.0000"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="Longitude_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox3_FilteredTextBoxExtender" TargetControlID="txtLongitude" ValidChars="-.0123456789" />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Output power" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtOutputPower" runat="server" CssClass="textInput" placeholder="watts"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="TextBox4_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox4_FilteredTextBoxExtender" TargetControlID="txtOutputPower" ValidChars="0123456789" />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Antenna height in meters" CssClass="formLabel"></asp:Label><asp:TextBox ID="txtAntennaHeight" runat="server" CssClass="textInput" placeholder="meters"></asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="TextBox6_FilteredTextBoxExtender" runat="server" BehaviorID="TextBox6_FilteredTextBoxExtender" TargetControlID="txtAntennaHeight" ValidChars="0123456789" />
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
        Please keep in mind that the frequencies listed are those that our database show to be available - there may be someone using a frequency who is not coordinated. Please monitor the desired frquency before submitting your request.<br />
        <br />
        <div class="center"><asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" /><asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="false" OnClick="btnSubmit_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></div>
        <br />
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>

