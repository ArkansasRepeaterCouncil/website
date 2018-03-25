$(function() {
	$( window ).scroll(function(e) {
		console.log(this.scrollY);
		if (this.scrollY > 220) {
			$("html").addClass("scrolled");
		} else {
			$("html").removeClass("scrolled");
		}
	});
});
