<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="repeaters_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="/repeaters/repeaters.css">
    <style type="text/css">
        label { 
            display: inline-block;
            width: 200px; 
            text-align: right;
            margin-right: 10px;
        }
    </style>
    <script>
        var positionElement = "position";

        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            } else { 
                alert("Geolocation is not supported by this browser.");
            }
        }

        function showPosition(position) {
            document.getElementById("txtLatitude").value = position.coords.latitude;
            document.getElementById("txtLongitude").value = position.coords.longitude;
            //document.getElementById("btnSubmit").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		<h1>Repeaters near a point</h1>
        <p>Enter the latitude, longitude, and distance away for a list of repeaters.</p>
        <label>Latitude: </label><asp:TextBox ID="txtLatitude" runat="server" ClientIDMode="Static"></asp:TextBox><br />
        <label>Longitude: </label><asp:TextBox ID="txtLongitude" runat="server" ClientIDMode="Static"></asp:TextBox><br />
        <label>Distance in miles: </label><asp:TextBox ID="txtDistance" Text="30" runat="server" ClientIDMode="Static"></asp:TextBox><br />
        <button onclick="getLocation();return false;">Detect current location</button> <asp:Button ID="btnSubmit" runat="server" Text="Submit" ClientIDMode="Static" />
        <hr />
		<asp:Label ID="repeaterList" runat="server" Text=""></asp:Label>
    </section>
</asp:Content>

