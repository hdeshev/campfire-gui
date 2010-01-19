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
		appendChatListener();
	});
})();

Campfire.MessageReceivedNotifier = Class.create({
	initialize: function(chat) {
		this.chat = chat;
	},

	onMessagesInserted: function(messages) {
		window.external.MessageReceived();
	}
});

function appendChatListener()
{
	Campfire.Responders.push("MessageReceivedNotifier");

	var chat = window.chat;
	chat.register.apply(chat, Campfire.Responders);
	chat.dispatch("chatCreated");
}



