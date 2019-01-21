<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="repeaters_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="/repeaters/repeaters.css">
    <script>
        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(getLocation_callback);
            } else {
                alert("Geolocation is not supported by this browser.");
            }
        }

        function getLocation_callback(position) {
            document.getElementById("ctl00_ContentPlaceHolder1_txtSearch").value = position.coords.latitude + ", " + position.coords.longitude;
            document.getElementById("ctl00_ContentPlaceHolder1_btnSearch").click();
        }
    </script>
    <style type="text/css">
        .lblSearch { 
            display: inline-block;
            width: 100px;
            text-align: right;
        }
        .searchDescription {
            margin-left: 105px;
            font-size: 0.6em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		    <h1>Repeater directory</h1>
            <p style="font-size: 0.7em;">Note: This list should not be used to find an open frequency, as some repeaters are coordinated privately.</p>
            <div>
                <asp:Label ID="Label1" CssClass="lblSearch" runat="server" Text="Search:"></asp:Label>
                <asp:TextBox ID="txtSearch" runat="server" Width="468px"></asp:TextBox>
            &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                <input id="btnDetect" type="button" value="Detect my location" onclick="getLocation();" />
                <br />
                <div class="searchDescription">Frequency, city, callsign, or &#39;latitude, longitude&#39;</div><br />
            </div>
		    <asp:Label ID="repeaterList" runat="server" Text=""></asp:Label>
            <br />
            <br />
    </section>
</asp:Content>

