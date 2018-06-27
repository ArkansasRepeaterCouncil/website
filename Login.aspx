<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">Login
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <h1>Login</h1>
        <asp:login runat="server" PasswordRecoveryText="Reset my password" PasswordRecoveryUrl="~/LoginReset.aspx" TitleText="" UserNameLabelText="Call sign:" UserNameRequiredErrorMessage="Call sign is required." ID="login1" CreateUserText="Request an account" CreateUserUrl="~/LoginRequest.aspx" OnAuthenticate="login1_Authenticate" BorderPadding="0" BorderStyle="None"></asp:login>
    </section>
</asp:Content>

