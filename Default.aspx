<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', {'packages':['corechart']});
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var countCurrent = parseInt(document.getElementById("hdnCountCurrent").value);
            var countExpired = parseInt(document.getElementById("hdnCountExpired").value);

            var data = google.visualization.arrayToDataTable([
                ['Status', 'Repeaters'],
                ['Current', countCurrent],
                ['Expired', countExpired]
            ]);
// Line removed           console.log(data)

            var options = {
                backgroundColor: 'transparent',
                colors: ['#ed6750', '#46c742'],
                legend: { textStyle: { color: '#ffffff', fontSize: 18 } },
                reverseCategories: true,
                title: 'Number of repeaters with current records',
                titleTextStyle: { color: '#ffffff', fontName: 'Cinzel Decorative', fontSize: 23, bold: true }
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            chart.draw(data, options);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="hdnPayPalEmail" ClientIDMode="Static" runat="server" />
    <section>
        <h1>
            <% if (Utilities.StateToDisplay == "AR") { %>
                <asp:label id="lblState1" runat="server" text=""></asp:label> Repeater Council
                <div style="display:inline-block; vertical-align:middle; margin-left:15px; text-align:center;">

<!-- Changes and Addition 041626 ghcjr -->

                    <asp:HyperLink ID="lnkPayPal" runat="server" Target="_blank">
                        <img src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif"
                            alt="Donate with PayPal"
                            style="vertical-align:middle;" />
                    </asp:HyperLink>
                    <br />
                    <span style="font-size:13px; font-weight:bold;">501(c)(3) Non-Profit Organization</span>
                </div>
            <% } %>
        </h1>
		<p>
			The <asp:label id="lblState2" runat="server" text=""></asp:label> Repeater Council coordinates
amateur radio repeater frequencies. We utilize available data from our own database, as well as information from surrounding states.  We use our own standards and guidelines as well as those of the <a href="http://iowarepeater.org/mid-america-coordination-council/">Mid-America Coordination Council</a>.
		</p>
    </section>
<!-- The End of Changes and Addition 041626 ghcjr -->
    <section>
        <div id="homeStatsContainer">
            <div class="stat">
                <h1><asp:label id="lblCount" ClientIDMode="Static" runat="server" text="100"></asp:label></h1>
                <span class="normalText">active coordinated repeaters</span>
            </div>
            <div class="stat">
                <h1><asp:label id="lblCoordinationCount" runat="server" text="100"></asp:label></h1>
                <span class="normalText">coordinations automatically processed on this site</span>
            </div>
            <div class="stat">
                <h1><asp:label id="lblAverageDaysPerCoordination" runat="server" text="10"></asp:label> days</h1>
                <span class="normalText">average time to coordinate a repeater</span>
            </div>
            <span class="stretch"></span>
        </div>
        <div class="currentRepeaters" id="piechart"></div>
    </section>
    <section>
        <div class="homepageListing mostWanted">
            <asp:Panel ID="pnlMostWanted" runat="server"></asp:Panel>
        </div>
        <div class="homepageListing recentChanges"><asp:label id="lblRecentChanges" runat="server" text="Ch-ch-ch-ch-changes"></asp:label></div>
    </section>

    <asp:HiddenField ID="hdnCountCurrent" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnCountExpired" ClientIDMode="Static" runat="server" />
</asp:Content>

