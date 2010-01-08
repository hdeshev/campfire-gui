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

//TODO: this doesn't get invoked at all.
Campfire.GrowlNotifier = Class.create({
	initialize: function(chat) {
		this.chat = chat;
	},

	onMessagesInserted: function(messages) {
		window.external.MessageReceived();
	}
});
Campfire.Responders.push("GrowlNotifier");