<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginReset.aspx.cs" Inherits="LoginReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlBefore" runat="server">
        <section>
            <h1>Reset password</h1>
            <p><asp:Label ID="lblDirections" runat="server" Text="Enter your callsign to send an email with a new password to your email address we have on file."></asp:Label></p>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="Callsign: "></asp:Label><asp:TextBox ID="txtCallsign" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="That is not a valid US call sign." ValidationExpression="[AKNWaknw][a-zA-Z]{0,2}[0123456789][a-zA-Z]{1,3}" ControlToValidate="txtCallsign">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Callsign is required." ControlToValidate="txtCallsign">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        </section>
    </asp:Panel>
    <asp:Panel ID="pnlAfter" runat="server" Visible="false">
        <section>
            <asp:Label ID="lblFeedback" runat="server" Text="Label"></asp:Label>
        </section>
    </asp:Panel>
</asp:Content>

