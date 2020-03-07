<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="about_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .avatar { 
            display: inline-block;
            float: left;
            margin-right: 10px;
        }
        #volunteerList {
            list-style-type: none;
        }
        #volunteerList li {
            display: block;
            height: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">About us
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<section>
		<h1>About us</h1>
		<p>
			The Arkansas Repeater Council is a non-profit corporation comprised of repeater operators in the state of Arkansas, created for the purpose of coordinating amateur radio repeater frequencies used in The Natural State.  The ARC has been a non-profit corporation registered with the Arkansas Secreatary of State since 1993.
		</p>
	</section>
	<section>
		<h2>Coordination team</h2>
		<p>
			Repeater coordination and the day-to-day operations of the Council is done by a team of volunteers.  The coordination team consists of:</p>
			<ul id="volunteerList">
				<li><img src="/images/tem.png" alt="Drawing of Tem" class="avatar">Tem Moore, N5KWL (<a href="https://www.qrz.com/db/n5kwl">QRZ</a>)<br>Chief Cat Herder In Charge</li>
                <li><img src="/images/luke.png" alt="Drawing of Luke" class="avatar">Luke Williams, AE5AU (<a href="https://www.qrz.com/db/ae5au">QRZ</a>)<br>Executive Information Sensei</li>
				<li><img src="/images/joshua.png" alt="Drawing of Joshua" class="avatar">Joshua Carroll, AA5JC (<a href="https://www.qrz.com/db/aa5jc">QRZ</a>)<br>Galactic Viceroy of Programming</li>
			</ul>
	</section>
	<section>
		<h2>Officers</h2>
		<p>
			The officers drive the organization by leading the committee through various business decisions and meetings.</p>
			<ul>
				<li>President: Don McDaniel, WA5OOY</li>
				<li>Vice President: Dennis Bedene, N5XMZ</li>
				<li>Secretary/Treasurer: JM Rowe, N5XFW</li>
			</ul>
		<p>Directors</p>
        <ul>
            <li>Wayne Mahnker - WA5LUY (2022)</li>
            <li>Michael Clay - AC5XV (2022)</li>
            <li>Joe Giddons - N5IOZ (2020)</li>
            <li>Tem Moore - N5KWL (2020)</li>
            <li>Joel Echols - N5QLC (2021)</li>
            <li>Johnathan Williams - K5DVT (2021)</li>
        </ul>
	</section>
</asp:Content>

