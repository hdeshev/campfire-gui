(function() {
	function onclick() {
		var source = window.event.srcElement;
		if (source.tagName.toLowerCase() == "a") {
			var handled = window.external.OpenLink(source.href);
			if (handled)
				return false;
		}
	}

	window.onload = (function() {
		document.onclick = onclick;
	});
})();