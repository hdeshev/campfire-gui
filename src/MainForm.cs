using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace CampfireGui
{
	public partial class MainForm : Form
	{
		private Configuration config;

		public MainForm()
		{
			InitializeComponent();
			this.config = new Configuration();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			chatBrowser.Navigate(this.config.CampfireUrl);
		}

		private void chatBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (e.Url.ToString().ToLower().Contains("login"))
			{
				this.Login();
			}
		}

		private void Login()
		{
			var scriptTemplate = @"
(function(){{
	window.onload = (function(){{
		var userBox = document.getElementById('username');
		var passwordBox = document.getElementById('password');

		userBox.value = '{0}';
		passwordBox.value = '{1}';

		var submitButton = document.getElementById('commit');
		submitButton.click();
	}});
}})();";
			var script = string.Format(scriptTemplate, this.config.Username, this.config.Password);
			var window = (mshtml.IHTMLWindow2) chatBrowser.Document.Window.DomWindow;
			window.execScript(script, "javascript");
		}
	}
}