<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="procedures_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    #docContainer ol { counter-reset: item; }
    #docContainer li { 
	    display: block;
	    margin-top: 0.5em;
    }
    #docContainer li:before {
      content: counters(item, ".") " ";
      counter-increment: item
    }

    #docContainer > ol > li { 
	    margin-bottom: 2em; 
	    font-size: 24px;
    }
    #docContainer > ol > li:before { content: "§" counters(item, ".") ". "; }
    #docContainer ol li ol { font-size: 18px; }

    #docContainer ol.alpha { list-style-type: lower-alpha; }
    #docContainer ol.alpha > li { display: list-item; }
    #docContainer ol.alpha > li:before { content: ""; }

    #docContainer > ol > li > ol > li > ol { list-style-type: lower-alpha; }
    #docContainer > ol > li > ol > li > ol > li { display: list-item; }
    #docContainer > ol > li > ol > li > ol > li:before { content: ""; }

    #docContainer > ol > li > ol > li > ol > li > ol { list-style-type: decimal; }
    #docContainer > ol > li > ol > li > ol > li > ol > li { display: list-item; }
    #docContainer > ol > li > ol > li > ol > li > ol > li:before { content: ""; }

    #docContainer blockquote { 
	    background-color: rgba(0,0,0,0.1); 
	    padding: 5px;
	    border-radius: 10px;
	    font-style: italic;
    }

    #docContainer table, #docContainer td, #docContainer th {
	    border: 1px solid;
	    padding: 5px;
	    border-collapse: collapse
    }

    #docContainer table {
	    margin: 15px;
    }
</style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">Procedures
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a class="namedAnchor" name="procedures"></a>
    <section>
        <h1>Arkansas Repeater Council Procedures and Standards</h1>

        <div id="docContainer">
         <ol>
          <li>Purpose
           <ol class="alpha">
            <li>The Arkansas Repeater Council is the body recognized to coordinate amateur radio repeaters in the state of
             Arkansas.</li>
            <li>The purpose of coordinating a repeater or frequency is to reduce harmful interference to other fixed operations.
             Coordinating a repeater or frequency with other fixed operations demonstrates good engineering and amateur
             practice.</li>
            <li>
             Part 97, Section 205, Item C provides a clear purpose for frequency coordinators:
             <blockquote>Where the transmissions of a repeater cause harmful interference to another repeater, the two station
              licensees are equally and fully responsible for resolving the interference unless the operation of one station is
              recommended by a frequency coordinator and the operation of the other station is not. In that case, the licensee
              of the non-coordinated repeater has primary responsibility to resolve the interference.</blockquote>
            </li>
           </ol>
          </li>
          <li>Processes
           <ol>
            <li>Account creation procedure
             <ol>
              <li>To login to this website you must first create an account. This can be done by anyone with a valid FCC license
               by following these steps:
               <ol>
                <li>Browse to arkansasrepeatercouncil.org.</li>
                <li>Click &quot;Login&quot;.</li>
                <li>Click &quot;Request an account&quot;.</li>
                <li>Enter your callsign and email address.</li>
                <li>Click &quot;Submit&quot;.</li>
                <li>Check your email for a password, then return to this site to login.</li>
               </ol>
              </li>
             </ol>
            </li>
            <li>Coordination request procedure
             <ol>
              <li>In order to request a new coordination for a repeater, anyone with a valid amateur radio license issued by the
               FCC may complete the following steps:
               <ol>
                <li>Login to the Arkansas Repeater Council site at arkansasrepeatercouncil.org/Login.aspx.</li>
                <li>Once logged-in, click the "Request coordination" link in the menu.</li>
                <li>Complete and submit the request form.</li>
               </ol>
              </li>
              <li>
               After submitting the form, the following automated process will begin:
               <ol>
                <li>The website will determine which states are within 90 miles of the proposed repeater site.</li>
                <li>It will then email each of the coordinators for each of those states with a link that they can use to give
                 you a response.</li>
                <li>If a coordinator has to decline a request, they are required to provide a reason.</li>
                <li>If any coordinator takes longer than 30 days to reply to a proposed coordination, it will be automatically
                 approved.</li>
               </ol>
              </li>
             </ol>
            </li>
            <li>Coordination update procedure
             <ol>
              <li>Coordination records are required to be updated at least once every three years.</li>
              <li>Coordination records must be updated within sixty (60) days of a change in trustee.</li>
              <li>In order to update a coordination, complete the following steps:
               <ol>
                <li>Login to the Arkansas Repeater Council site at arkansasrepeatercouncil.org/Login.aspx.</li>
                <li>Once logged-in, click the "Update" button next to the repeater you need to update.<br>
                 (Note: This button is only shown if you have a repeater for which you are a trustee.)</li>
                <li>Review the repeater information and make any needed changes.</li>
                <li>Even if no changes were made, click "Save".</li>
               </ol>
              </li>
             </ol>
            </li>
            <li>Coordination transfer procedure
             <ol>
              <li>A coordination may be transferred only under certain conditions. If a coordinated repeater system that is
               currently in complete operation is sold or otherwise transfers ownership, the coordination will transfer with the
               repeater system. Any such sale or transfer must include the actual equipment that comprises the repeater system.
              </li>
              <li>Both parties must work together to complete the following process to complete the transfer:
               <ol>
                <li>Contact the individual to whom you want to transfer a repeater, and ensure they are registered on this site.
                </li>
                <li>Login to the Arkansas Repeater Council site at arkansasrepeatercouncil.org/Login.aspx.</li>
                <li>Once logged-in, click the "Update" button next to the repeater you need to update. <br>
                 (Note: This button is only shown if you have a repeater for which you are a trustee.)</li>
                <li>Next to the trustee textbox, click the button labelled, "Change" - this will populate the list of options.
                </li>
                <li>Select the new trustee in the list.</li>
                <li>Click "Save".</li>
               </ol>
              </li>
             </ol>
            </li>
            <li>Procedure for adding additional users to your coordination
             <ol>
              <li>Most repeaters have a single trustee. This creates problems if the trustee becomes unable to maintain their
               coordination. The Arkansas Repeater Council web site enables trustees to add secondary users to their repeater
               coordinations. These users can perform any of the same tasks as the trustee to keep their coordination up to
               date.</li>
              <li>In order to add an additional user to a coordination, follow these steps:
               <ol>
                <li>Contact the individual you want to add to a repeater, and ensure they are registered on this site.</li>
                <li>Login to the Arkansas Repeater Council site at arkansasrepeatercouncil.org/Login.aspx.</li>
                <li>Once logged-in, click the "Update" button next to the repeater you need to update. <br>
                 (Note: This button is only shown if you have a repeater for which you are a trustee.)</li>
                <li>Click the “Users” tab, then click the “Add new” button.</li>
                <li>Select the new user from the list.</li>
                <li>Click "Save".</li>
               </ol>
              </li>
             </ol>
            </li>
           </ol>
          <li>Guidelines
           <ol>
            <li>General
             <ol>
              <li>Repeater records are required to be updated at least once every 3 years.</li>
              <li>A minimal fee for coordination is charged once every three years to pay for the website and associated fees.
               The non-refundable fee is $3. The coordinators may decrease or disregard this fee if there are sufficient funds
               for the foreseeable future.</li>
              <li>The coordinators will maintain a band-plan in consultation with those of the Mid-America Coordination Council
               and neighboring states.</li>
             </ol>
            </li>
            <li>Geographical separation of repeaters
             <ol>
              <li>Co-channel repeaters (those on the same frequency) must be at least be 90 miles apart. This applies to systems
               on the 52, 144, 220, 440, 902, and 1215 MHz bands.</li>
              <li>Repeaters on adjacent frequencies also have physical separation requirements. Refer to the following table for
               those requirements:
               <table>
                <tr>
                 <th>Band (MHz)</th>
                 <th>Spacing</th>
                 <th>Separation</th>
                </tr>
                <tr>
                 <td>52</td>
                 <td>20 kHz</td>
                 <td>20 miles</td>
                </tr>
                <tr>
                 <td>144</td>
                 <td>15 kHz</td>
                 <td>40 miles</td>
                </tr>
                <tr>
                 <td> </td>
                 <td>20 kHz</td>
                 <td>25 miles</td>
                </tr>
                <tr>
                 <td> </td>
                 <td>30 kHz</td>
                 <td>20 miles</td>
                </tr>
                <tr>
                 <td>220</td>
                 <td>20 kHz</td>
                 <td>40 miles</td>
                </tr>
                <tr>
                 <td> </td>
                 <td>40 kHz</td>
                 <td>5 miles</td>
                </tr>
                <tr>
                 <td>440</td>
                 <td>25 kHz</td>
                 <td>5 miles</td>
                </tr>
                <tr>
                 <td> </td>
                 <td>40 kHz</td>
                 <td>1 miles</td>
                </tr>
                <tr>
                 <td>902</td>
                 <td>25 kHz</td>
                 <td>5 miles</td>
                </tr>
                <tr>
                 <td> </td>
                 <td>50 kHz</td>
                 <td>1 mile</td>
                </tr>
                <tr>
                 <td>1215</td>
                 <td>25 kHz</td>
                 <td>5 miles</td>
                </tr>
                <tr>
                 <td> </td>
                 <td>50 kHz</td>
                 <td>1 mile</td>
                </tr>
               </table>
              </li>
             </ol>
            </li>
            <li>Changes to a coordination
             <ol>
              <li>Coordination records must be updated within sixty (60) days of a change in trustee.</li>
              <li>A coordination may be transferred to another trustee only if a coordinated repeater system, that is currently
               in complete operation, is sold or otherwise transfers ownership. The coordination will transfer with the repeater
               system. Any such sale or transfer must include the actual equipment that comprises the repeater system. Both
               parties must work together to complete the transfer process online within 15 days of the transfer of ownership.
              </li>
              <li>If there is any change to the operating parameters of a coordinated repeater (transmit power, antenna height,
               ERP, location, or frequency) outside of the allowed deviation limits, the coordination is automatically void and
               the frequency will be returned to the pool for reassignment.</li>
              <li>Certain deviations to the operating parameters of a coordinated repeater are allowed. These deviations are
               based on the values given when the repeater was initially coordinated. The allowed deviations are as follows:
               <ol>
                <li>Power may not be increased more than 5 watts from the originally coordinated power at duplexer output</li>
                <li>Antenna height may not be increased more than 50 feet (15 meters) from the originally coordinated height
                </li>
                <li>Effective radiated power may not be more than 300 watts.</li>
                <li>Location may not change more than 1 mile in any direction from the originally coordinated location</li>
                <li>Frequency may not be changed at all without re-coordination.</li>
               </ol>
              </li>
             </ol>
            </li>
            <li>Unused frequencies and construction
             <ol>
              <li>If the frequency of a coordinated repeater is stopped being used, the coordination will be automatically
               voided after 15 days. This action ensures that frequencies remain available as much as possible.</li>
              <li>If a repeater must be taken offline, or it has a malfunction, then the trustee should immediately update its
               coordination record to show it is temporarily off-the-air for 30 days. The trustee may extend this by adding a
               note to the record once every 30 days. A coordination can be held in these cases for a maximum of 180 days after
               which, if the repeater is still not back in service, the coordination will be void. The trustee must update the
               repeater's record online at the time the repeater is placed into regular service to retain coordination.</li>
              <li>After a coordination request has been approved, the applicant has 180 days to complete the repeater
               installation and update the repeater's record that the repeater is operational. If problems arise and more than
               180 days are required, then a coordinator must be notified to request an extension of 60 days. Only one extension
               may be granted. The trustee must update the repeater's record online at the time the repeater is placed into
               regular service to retain coordination.</li>
             </ol>
            </li>
            <li>Miscellaneous specification and definitions
             <ol>
              <li>A portable repeater is a repeater which can be placed on a location 72 hours before and after an event. The
               repeater may be a coordinated repeater. It may also be set up for an emergency. It must stay within state
               boundaries.</li>
              <li>A temporary repeater is used when a coordinated repeater has experienced a site failure (fallen tower, fire,
               etc.). It can be placed up to 25 miles from its coordinated site for no more than 30 days. An extension can be
               granted by the coordinator upon request by the trustee. After repairs are completed, the repeater must be
               returned to its coordinated site within 72 hours.</li>
             </ol>
            </li>
           </ol>
          </li>
         </ol>
        </div>
    </section>

	
	</asp:Content>

