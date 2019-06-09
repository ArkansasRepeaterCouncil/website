<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="dashboard_expiredrepeaters_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .repeaterList {
            margin-left: auto;
            margin-right: auto;
            width: 800px;
            margin-bottom: 20px;
        }
        .updatesList {
            width: 800px;
            margin-left: auto;
            margin-right: auto;
        }
        .updatesList ul {
            margin-top: 0;
            padding-top: 0;
            font-size: 0.7em;
        }
        .expiredRepeaterNote {
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">: Expired repeaters report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section>
	    <h2>Expired repeaters report</h2>
        <asp:UpdatePanel ID="pnlExpiredRepeaters" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>

            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

