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
    <script>
        document.addEventListener('scroll', function (event) {
            $("#scrollPosition").attr("value", $("html").scrollTop());
        }, true /*Capture event*/);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">: Open requests report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section>
	    <h2>Open requests report</h2>
        <asp:Panel ID="pnlOpenRequests" runat="server"></asp:Panel>
        <asp:HiddenField ID="scrollPosition" ClientIDMode="Static" runat="server" />
    </section>
</asp:Content>

