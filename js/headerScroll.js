try {
	$(function () {
		$(window).scroll(function (e) {
			if (this.scrollY > 220) {
				$("html").addClass("scrolled");
			} else {
				$("html").removeClass("scrolled");
			}
		});
	});
}
catch(err) {}