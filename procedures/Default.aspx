<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="procedures_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
        width: 209px;
    }
    .auto-style2 {
        text-decoration: underline;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">Procedures
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		<h1>Procedures</h1>
		<ul>
            <li><a href="#faq">Frequently asked questions</a></li>
			<li><a href="#procedures">Procedures</a><br />
                <ul>
                    <li><a href="#coordinationprocedure">Coordination requests</a></li>
                    <li><a href="#updateprocedure">Updates</a></li>
                    <li><a href="#transferprocedure">Transfers</a></li>
                </ul>
			</li>
			<li><a href="#principles">Principles</a><br />
                <ul>
                    <li><a href="#deviationlimits">Deviation limits</a></li>
                </ul>
			</li>
			<li><a href="#guidelines">Guidelines</a><br />
                <ul>
                    <li><a href="#bandplans">Band plans</a></li>
                    <li><a href="#geographicalseparation">Geographical separation of repeaters</a></li>
                    <li><a href="#adjacentfrequency">Adjacent frequency separation</a></li>
                    <li><a href="#miscspec">Miscellaneous specification & definitions</a></li>
                    <li><a href="#constructionperiod">Repeater construction period</a></li>
                    <li><a href="#coordinationmodification">Modification to existing coordination</a></li>
                </ul>
			</li>

		</ul>
	</section>

	<a class="namedAnchor" name="faq"></a>
	<section>
		<h2>Frequently asked questions</h2>
        <ol>
            <li>I've heard that there are no frequencies available.  Is that true?<ul>
                <li>In most cases, there are plently of frequencies available.&nbsp; It would be difficult for us to say one way or the other without access to all of the surrounding states&#39; databases.&nbsp; But from what we&#39;ve seen so far, there are frequencies available in all corners of the state.<br />&nbsp;</li>
                </ul>
            </li>
            <li>Am I required to coordinate my repeater?<ul>
                <li>No you are not.&nbsp; However, if someone else coordinates the frequency you are using, then we (and the ARRL) will side with the coordinated repeater.</li>
                </ul>
            </li>
        </ol>
    </section>

	<a class="namedAnchor" name="procedures"></a>
	<section>
		<h2>Procedures</h2>
		Any individual or organization desiring to establish an amateur radio repeater in Arkansas should first submit a coordination request.&nbsp; This section will outline that process.
		
		<a class="namedAnchor" name="coordinationprocedure"></a><h3>Coordination request procedure</h3>
        <ol>
            <li>Login to the Arkansas Repeater Council site at <a href="https://www.arkansasrepeatercouncil.org/Login.aspx">arkansasrepeatercouncil.org/Login.aspx</a>. (Create an account if you don't already have one.)</li>
            <li>Once logged-in, click the &quot;Request coordination&quot; link in the menu.</li>
            <li>Complete and submit the request form.</li>
            <li>Wait for the magic to happen.&nbsp; What&#39;s the magic?&nbsp; I&#39;m so glad you asked...</li>
        </ol>

        <p>Once your request is submitted, the website will automatically determine which states are within 90 miles of your proposed repeater site.&nbsp; It will then email each of the coordinators for each of those states with a link that they can use to give you a response.&nbsp; If a coordinator has to decline a request they will provide a reason.</p>

        <div style="width: 644px; font-size: 0.75em; margin-left: auto; margin-right: auto; background-color: rgba(255, 255, 255, 0.4);">
        Coordination workflow, including automated parts of the process:<br />
        <a href="../images/CoordinationWorkflow.jpg" target="_blank"><img alt="" src="../images/CoordinationWorkflow.jpg" style="margin: 5px; height: 328px; width: 634px" /></a>
		</div>

        <a class="namedAnchor" name="updateprocedure"></a><h3>Update procedure</h3>
        <p>The Arkansas Repeater Council requires that all records be updated at least every three years. Repeater records must be updated within sixty (60) days of a change in trustee.</p>
        <ol>
            <li>Login to the Arkansas Repeater Council site at <a href="https://www.arkansasrepeatercouncil.org/Login.aspx">arkansasrepeatercouncil.org/Login.aspx</a>. (Create an account if you don't already have one.</li>
            <li>Once logged-in, click the &quot;Update&quot; button next to the repeater you need to update. (Note: This button is only shown if you have a repeater for which you are a trustee.)</li>
            <li>Review the repeater information and make any needed changes.</li>
            <li>Even if no changes were made... click &quot;Save&quot;. That's it.</li>
        </ol>

        <a class="namedAnchor" name="transferprocedure"></a><h3>Transfer procedure</h3>
        <p>A frequency coordination may be transferred under certain conditions. If a coordinated repeater system
    that is currently in complete operation is sold, the coordination will transfer with the repeater system.
    Any such sale or transfer must include the actual equipment that comprises the repeater system. </p>
        <ol>
            <li>Contact the individual to whom you want to transfer a repeater, and ensure they are registered on this site.</li>
            <li>Login to the Arkansas Repeater Council site at <a href="https://www.arkansasrepeatercouncil.org/Login.aspx">arkansasrepeatercouncil.org/Login.aspx</a>. (Create an account if you don't already have one.</li>
            <li>Once logged-in, click the &quot;Update&quot; button next to the repeater you need to update. (Note: This button is only shown if you have a repeater for which you are a trustee.)</li>
            <li>Next to the trustee textbox, click the button labelled, &quot;Change&quot; - this will populate the list of options.</li>
            <li>Select the new trustee in the list.</li>
            <li>Click &quot;Save&quot;.</li>
        </ol>
	</section>

	<a class="namedAnchor" name="principles"></a>
	<section>
		<h2>Principles</h2>
		<p>
Frequency coordination exists for the purpose of reducing or eliminating interference between amateur radio repeaters. In Arkansas, the Arkansas Repeater Council is the recognized
Coordinator.
		</p><p>
Frequency coordination is voluntary. By obtaining coordination, you avail yourself the protection of the FCC if there is a problem between your repeater and an uncoordinated
repeater. The uncoordinated machine is responsible for correcting the problem, not you.
</p><p>
The ARC adheres to regional (MACC) and national (NFCC) standards of coordination.
This requires working with other states to prevent interference to everyone. Since the different
organizations are voluntary, not everybody replies promptly. The ARC tries to provide
coordination within a sixty-day time frame. This time frame starts from the date of receipt by the
            coordinator, till responses from surrounding states that are affected by the coordination and
notification is sent back to the repeater owner or trustee. If a coordination response is not
received, the coordinator advises the state involved that the coordination is proceeding without
their input.
</p><p>
            After the coordination is completed and the repeater is on the air, if there is any change to the operating parameters (transmit power, antenna height, ERP,
location, or frequency) outside of the published deviation limits below, the coordination is automatically
void and the frequency will be returned to the pool for reassignment. 
</p>
<a name="deviationlimits" class="namedAnchor"></a>
        <h3>Deviation limits</h3>
<p>
Repeaters may be changed, but the following specifications are only allowed deviations as follows:</p>
    <ul>
    <li>Power - No more than 5 watts from coordinated power (at duplexer output)</li>
    <li>Antenna height - No more than +50 ft. from coordinated height</li>
    <li>ERP - 300 Watts maximum</li>
    <li>Location - Not more than 1 mile in any direction from coordinated location</li>
    <li>Frequency - No changes without re-coordination</li>
    </ul>
<p>
If a frequency is not used or has stopped being used, the coordination will be voided 15 days
after receipt of notification to the repeater owner or trustee that this action will be taken unless
the repeater is put back into service. This action insures that frequencies remain available as
much as possible. 
</p><p>
After a coordination request has been approved, the applicant has 180 days to
complete the repeater installation and update the repeater&#39;s record that the repeater is operational. If problems arise and more than 180
days are required, then the coordinator must be notified to request an extension of 60 days.
</p><p>
Coordination is voluntary and depends on you to help keep interference to a minimum.
When interference occurs between two coordinated repeaters, the ARC will work with all parties
involved to try and resolve the problem to everyone's satisfaction. The FCC has final jurisdiction
on any and all complaints.
</p><p>
The ARC charges a minimal fee for coordination to offset mailing and telephone charges.
The non-refundable fee is $10.00. ARC members pay $5.00.
Currently, fees for coordination have been suspended unless the council funds drop below a
pre-set level.</p>
</section>
	<a class="namedAnchor" name="guidelines"></a>
	<section>
		<h2>Guidelines</h2>
		The Arkansas Repeater Council requires that repeater records be updated every 3 years.
        <a class="namedAnchor" name="bandplans"></a>
		<h3>Band plans</h3>
The member state coordinators shall adhere as closely as possible to the use of the various
band plans as adopted by the Mid-America Coordination Council.
Use of the modified band plans is at the option of the local State coordinators with the consent of adjacent MACC state coordinators.
        <a class="namedAnchor" name="geographicalseparation"></a>
		<h3>Geographical separation of repeaters</h3>
The minimum geographical spacing between the two closest points of the systems in question
shall be 90 miles (effective 03-02-2013 per vote at annual membership meeting).
This spacing is considered valid for systems on the 52, 144, 220, 440, 902 and
1215 MHz bands. This applies to separations in and out of the state.
        <a class="namedAnchor" name="adjacentfrequency"></a>
		<h3>Adjacent frequency separation</h3>
		<table>
			<tr><td class="auto-style2">Band (MHz)</td><td class="auto-style2">Spacing</td><td class="auto-style2">Separation</td><td class="auto-style1">&nbsp;</td><td class="auto-style2">Band (MHz)</td><td class="auto-style2">Spacing</td><td class="auto-style2">Separation</td></tr>
			<tr><td>52</td><td>20 kHz</td><td>20 miles</td><td class="auto-style1">&nbsp;</td><td>440</td><td>25 kHz</td><td>5 miles</td></tr>
			<tr><td>&nbsp;</td><td>40 kHz</td><td>No minimum</td><td class="auto-style1">&nbsp;</td><td>&nbsp;</td><td>40 kHz</td><td>1 mile</td></tr>
			<tr><td>144</td><td>15 kHz</td><td>40 miles</td><td class="auto-style1">&nbsp;</td><td>&nbsp;</td><td>50 kHz</td><td>No minimum</td></tr>
			<tr><td>&nbsp;</td><td>20 kHz</td><td>25 miles</td><td class="auto-style1">&nbsp;</td><td>902</td><td>25 kHz</td><td>5 miles</td></tr>
			<tr><td>&nbsp;</td><td>30 kHz</td><td>20 miles</td><td class="auto-style1">&nbsp;</td><td>&nbsp;</td><td>50 kHz</td><td>1 mile</td></tr>
			<tr><td>220</td><td>20 kHz</td><td>40 miles</td><td class="auto-style1">&nbsp;</td><td>&nbsp;</td><td>75 kHz</td><td>No minimum</td></tr>
			<tr><td>&nbsp;</td><td>40 kHz</td><td>5 miles</td><td class="auto-style1">&nbsp;</td><td>1215</td><td>25 kHz</td><td>5 miles</td></tr>
			<tr><td>&nbsp;</td><td>60 kHz</td><td>No minimum</td><td class="auto-style1">&nbsp;</td><td>&nbsp;</td><td>50 kHz</td><td>1 mile</td></tr>
			<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td class="auto-style1">&nbsp;</td><td>&nbsp;</td><td>75 kHz</td><td>No minimum</td></tr>
			</table>
        <a class="namedAnchor" name="miscspec"></a>
		<h3>Miscellaneous specifications &amp; definitions</h3>
		<ul>
			<li>Closed repeater: Applications will be coordinated as SNP repeaters.</li>
			<li>Portable repeater: A repeater which can be placed on a location 72 hours before and after
      an event. The repeater may be a coordinated repeater. It may also be set up for an emergency. It must stay within state boundaries.</li>
			<li>Temporary repeater: A repeater that had a site failure (fallen tower, fire, etc.). It can be
      moved up to 25 miles from it's coordinated site for no more than 30 days. An extension can
      be granted by the coordinator upon request by the repeater owner / trustee. After repairs are
      completed, the repeater must be returned to its coordinated site within 72 hours. </li>
		</ul>
        <a class="namedAnchor" name="constructionperiod"></a>
	    <h3>Repeater Construction Period</h3>
		    Upon approval of a request for coordination, a period of 180 days is allowed to place the repeater into operation. Operation is defined as "fully tested repeater operation from the final repeater location or site". If the system is not in operation after this construction period, the coordination is automatically
    withdrawn. If however, during this 180 day period, the applicant determines that he will be unable to place the repeater on the assigned frequency into operation, he may request an extension of no more than 60 days. If the construction and installation of the repeater system is not completed within this 
    extended period, the frequency assignment is automatically withdrawn. The applicant may then re-apply for the coordination, but there is no guarantee that the previously coordinated frequency will be available.
    This allows for efficient use of valuable spectrum and ensures that frequency pairs are not wasted by holding assignments for protracted periods when applicants fail to construct in a timely manner.
    The applicant must update the repeater&#39;s record online at the time the repeater is placed into regular
    service for the applicant to retain coordination.
    If a previously constructed repeater system is rendered inoperative for more than 60 days, the sponsor must update the repeater&#39;s record to reflect its status as &quot;Temporarily off the air&quot;. The sponsor will then have 90 days to return the repeater system to the air. The sponsor will update the repeater&#39;s record when the system is returned to operation.
		    <a class="namedAnchor" name="coordinationmodification"></a>
		    <h3>Modification to existing coordination</h3>

    Any modification or change in the original coordination (i.e.- TX Power, Ant. Height, ERP, Location or Frequency) will automatically void the coordination. Deviations allowed are set forth in the coordination guidelines, however the repeater&#39;s record must be updated online within 30 days of any allowed changes. 
    If a repeater is to be moved from its coordinated location, the sponsor of the system must submit a request for relocation. The coordinator will confirm that the proposed change in location meets all the criteria set forth in the coordination guidelines. If it is determined that the proposed relocation of the repeater will not conform to the applicable coordination guidelines, the application for relocation will not be granted. If a sponsor begins operation of the repeater system prior to receiving an approval of the change of location from the coordinator, then the repeater&#39;s coordination is forfeit.</section>
</asp:Content>

