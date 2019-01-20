<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="repeaters_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="/repeaters/repeaters.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		    <h1>Repeater directory</h1>
            <p style="font-size: 0.7em;">Note: This list should not be used to find an open frequency, as some repeaters are coordinated privately.  If you need to coordinate a repeater please complete a request and just let us know if you have certain frequency requirements or preferences and allow us to find a frequency for you.</p>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Search: "></asp:Label>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Go" />
                <br />
            </div>
		    <asp:Label ID="repeaterList" runat="server" Text=""></asp:Label>
            <br />
            <br />
    </section>
</asp:Content>

