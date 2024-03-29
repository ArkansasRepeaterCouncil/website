﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginRequest.aspx.cs" Inherits="LoginRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .label { 
            width: 200px; 
            display: inline-block;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <h1>Create an Account</h1>
        <p><asp:Label ID="lblDirections" runat="server" Text="Complete the form below to create an account and we will email you a password."></asp:Label></p>
        <h2>READ THIS FIRST</h2>
        <ul>
            <li>We highly suggest that you do not use the email address from your school, work, Internet provider, or ARRL address. Eventually, you will (a) not go to school there, (b) not work there, (c) find a better Internet connection, or (d) not renew your ARRL membership - and then we won't have a way to reach you. If you need an alternative for email, try <a target="_blank" href="https://gmail.com">Gmail</a>.</li>
            <li>Also, <u>please don't create an account for your club</u>.  Each account should be for specific people. You can still coordinate and manage repeaters for your club. To learn how, read paragrpah 2.5 on the <a href="/procedures/">Procedures page</a>.</li>
        </ul>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Label ID="Label1" CssClass="label" runat="server" Text="Callsign: " AssociatedControlID="txtCallsign"></asp:Label><asp:TextBox ID="txtCallsign" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="That is not a valid US call sign." ValidationExpression="[AKNWaknw][a-zA-Z]{0,2}[0123456789][a-zA-Z]{1,3}" ControlToValidate="txtCallsign">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Callsign is required." ControlToValidate="txtCallsign">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="txtCallsign" runat="server" ErrorMessage="The call sign you entered does not appear to be associated with a valid license." OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label2" CssClass="label" runat="server" Text="Email address: " AssociatedControlID="txtEmail"></asp:Label><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email address provided is not valid." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email address is required." ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Please do not use an arrl.net email address. <a target='_blank' href='https://github.com/ArkansasRepeaterCouncil/website/issues/639'>Why?</a>" ControlToValidate="txtEmail" OnServerValidate="CustomValidator2_ServerValidate">*</asp:CustomValidator>
        <br />
        <asp:HiddenField ID="hdnName" runat="server" />
        <asp:HiddenField ID="hdnAddress" runat="server" />
        <asp:HiddenField ID="hdnCity" runat="server" />
        <asp:HiddenField ID="hdnState" runat="server" />
        <asp:HiddenField ID="hdnZip" runat="server" />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    </section>
</asp:Content>

