<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="update_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #formPanel input, #formPanel checkbox {
            margin-left: 5px;
            margin-right: 15px;
        }
        .formLabel {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <h1><asp:Label ID="lblRepeaterName" runat="server" Text="Label"></asp:Label></h1>
        <asp:Panel ID="formPanel" runat="server" ClientIDMode="Static"></asp:Panel>
    </section>

</asp:Content>

