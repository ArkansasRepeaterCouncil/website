$.getJSON( "https://repeatercoordinationservice.azurewebsites.net/api/GetPublicList?state=ar", function( data ) {
	var items = [];
	
	items.push("<thead><tr><th>Callsign</th><th>Trustee</th><th>Status</th><th>City</th><th>Offset</th><th>Attributes</th></tr></thead>");
	
	items.push("<tbody>");
	
	$.each( data, function( index, obj ) {
		items.push( "<tr>" );
		
		items.push( "<td>" + obj.Callsign + "</td>" );
		items.push( "<td>" + obj.Trustee + "</td>" );
		items.push( "<td>" + obj.Status + "</td>" );
		items.push( "<td>" + obj.City + "</td>" );
		items.push( "<td>" + obj.Offset + "</td>" );
		
		items.push( "<td>" );
		
		var attributes = [];
		getValueIfNotNull(obj.Analog_InputAccess, "input tone: ", attributes);
		getValueIfNotNull(obj.Analog_OutputAccess, "output tone: ", attributes);
		getValueIfNotNull(obj.DSTAR_Module, "D-Star module: ", attributes);
		getValueIfNotNull(obj.DMR_ID, "DMR ID: ", attributes);
		getNameIfNotNull(obj.AutoPatch, "autopatch", attributes);
		getNameIfNotNull(obj.EmergencyPower, "emergency power", attributes);
		getNameIfNotNull(obj.Linked, "linked, ", attributes);
		getNameIfNotNull(obj.RACES, "RACES", attributes);
		getNameIfNotNull(obj.ARES, "ARES", attributes);
		getNameIfNotNull(obj.Weather, "weather net", attributes);
		
		$.each( attributes, function( index, attribute ) {
			items.push(index < attributes.length - 1 ? attribute + ", " : attribute);
		});
					  
		items.push( "</td>" );
		items.push( "</tr>" );
	});
	
	items.push( "</tbody>" );
	
	$( "<table/>", {
		"class": "repeaterListTable",
		html: items.join( "" )
	}).appendTo( "#repeaterList" );
	
});
	
function getValueIfNotNull(val, prefixString, arr) {
	val != null ? arr.push(prefixString + val) : "";
}
 
function getNameIfNotNull(val, name, arr) {
	(((val != null) && (val != 0) && (val != false)) ? arr.push(name) : "" );
}