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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">: About
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<section>
		<h1>About us</h1>
		<p>
			The Arkansas Repeater Council is a non-profit incorporation comprised of repeater operators in the state of Arkansas, created for the purpose of coordinating amateur radio repeater frequencies used in the state.
		</p>
	</section>
	<section>
		<h2>Coordination team</h2>
		<p>
			Repeater coordination and the day-to-day operations of the Council is done by a team of volunteers.  The coordination team consists of:
			<ul id="volunteerList">
				<li><img src="/images/tem.png" alt="Drawing of Tem" class="avatar">Tem Moore, N5KWL<br>Chief Cat Herder In Charge</li>
                <li><img src="/images/luke.png" alt="Drawing of Luke" class="avatar">Luke Williams, AE5AU<br>Executive Information Sensei</li>
				<li><img src="/images/joshua.png" alt="Drawing of Joshua" class="avatar">Joshua Carroll, N5JLC<br>Galactic Viceroy of Programming</li>
			</ul>
		</p>
	</section>
	<section>
		<h2>Officers</h2>
		<p>
			The officers drive the organization by leading the committee through various business decisions and meetings.
			<ul>
				<li>President: Don McDaniel, WA5OOY</li>
				<li>Vice President: Dennis Bedene, N5XMZ</li>
				<li>Secretary/Treasurer: JM Rowe, N5XFW</li>
			</ul>
		</p>
	</section>
</asp:Content>

