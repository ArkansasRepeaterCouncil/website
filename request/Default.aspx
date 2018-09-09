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
        <asp:Label ID="Label1" runat="server" Text="Band" CssClass="formLabel"></asp:Label><ajaxToolkit:ComboBox ID="ComboBox1" runat="server" CssClass="textInput">
            <asp:ListItem>10 Meters (28-29.7 MHz)</asp:ListItem>
            <asp:ListItem>6 Meters (50-54 MHz)</asp:ListItem>
            <asp:ListItem>2 Meters (144-148 MHz)</asp:ListItem>
            <asp:ListItem>1.25 Meters (222-225 MHz)</asp:ListItem>
            <asp:ListItem>70 Centimeters (420-450 MHz)</asp:ListItem>
            <asp:ListItem>33 Centimeters (902-928 MHz)</asp:ListItem>
            <asp:ListItem>Any</asp:ListItem>
        </ajaxToolkit:ComboBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Preferred frequency" CssClass="formLabel"></asp:Label><asp:TextBox ID="TextBox1" runat="server" CssClass="textInput"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="Nearby frequency is acceptable" CssClass="formLabel"></asp:Label><asp:CheckBox ID="CheckBox1" runat="server" TextAlign="Left" />
        <asp:Label ID="Label4" runat="server" Text="Latitude (decimal)" CssClass="formLabel"></asp:Label><br />
        <asp:Label ID="Label5" runat="server" Text="Longitude (decimal)" CssClass="formLabel"></asp:Label><br />
        <asp:Label ID="Label6" runat="server" Text="Output power" CssClass="formLabel"></asp:Label><br />
        <asp:Label ID="Label7" runat="server" Text="Altitude in meters from sea level" CssClass="formLabel"></asp:Label><br />
        <asp:Label ID="Label8" runat="server" Text="Antenna height" CssClass="formLabel"></asp:Label>
        <br />
    </section>
</asp:Content>

