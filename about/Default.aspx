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
			The Arkansas Repeater Council, Inc. is a non-profit corporation comprised of repeater operators in the state of Arkansas, created for the purpose of coordinating amateur radio repeater frequencies used in The Natural State.  The ARC has been a non-profit corporation registered with the Arkansas Secreatary of State since 1993.
		</p>
		<p>
			A copy of our by-laws can be found at <a href="https://docs.google.com/document/d/1nljesPaWwOPJg2ACq8huP7m-mTFHLi0laum9kuHX-mY/edit?usp=sharing">https://docs.google.com/document/d/1nljesPaWwOPJg2ACq8huP7m-mTFHLi0laum9kuHX-mY</a>.
		</p>
	</section>
	<section>
		<h2>Coordination team</h2>
		<p>
			Repeater coordination and the day-to-day operations of the Council is done by a team of volunteers.  The coordination team consists of:</p>
			<ul id="volunteerList">
				<li><img src="/images/tem.png" alt="Drawing of Tem" class="avatar">Tem Moore, <a href="https://www.qrz.com/db/n5kwl">N5KWL</a><br>Chief Cat Herder In Charge</li>
                <li><img src="/images/luke.png" alt="Drawing of Luke" class="avatar">Luke Williams, <a href="https://www.qrz.com/db/ae5au">AE5AU</a><br>Executive Information Sensei</li>
				<li><img src="/images/joshua.png" alt="Drawing of Joshua" class="avatar">Joshua Carroll, <a href="https://www.qrz.com/db/aa5jc">AA5JC</a><br>Galactic Viceroy of Programming</li>
			</ul>
	</section>
	<section>
		<h2>Officers</h2>
		<p>
			The officers drive the organization by leading the committee through various business decisions and meetings.</p>
			<ul>
				<li>President: Don McDaniel, <a href="https://www.qrz.com/db/wa5ooy">WA5OOY</a></li>
				<li>Vice President: Dennis Bedene, <a href="https://www.qrz.com/db/n5xmz">N5XMZ</a></li>
				<li>Secretary/Treasurer: JM Rowe, <a href="https://www.qrz.com/db/n5xfw">N5XFW</a></li>
			</ul>
		<p>Directors</p>
        <ul>
			<li>Wayne Mahnker - <a href="https://www.qrz.com/db/wa5luy">WA5LUY</a> (2022)</li>
			<li>Michael Clay - <a href="https://www.qrz.com/db/ac5xv">AC5XV</a> (2022)</li>
			<li>Chris Daniel - <a href="https://www.qrz.com/db/w5awx">W5AWX</a> (2023)</li>
			<li>Joshua Carroll - <a href="https://www.qrz.com/db/aa5jc">AA5JC</a> (2023)</li>
			<li>Joel Echols - <a href="https://www.qrz.com/db/n5qlc">N5QLC</a> (2021)</li>
			<li>Jon Williams - <a href="https://www.qrz.com/db/k5dvt">K5DVT</a> (2021)</li>
        </ul>
	</section>
</asp:Content>

