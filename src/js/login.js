(function(){
	function login()
	{
		var userBox = document.getElementById('username');
		var passwordBox = document.getElementById('password');

		userBox.value = window.external.Username;
		passwordBox.value = window.external.Password;

		var submitButton = document.getElementById('commit');
		submitButton.click();
	}
	
	window.onload = (function(){
		window.setTimeout(login, 300);
	});
})();