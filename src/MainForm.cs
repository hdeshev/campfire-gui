using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using mshtml;

namespace CampfireGui
{
	[ComVisible(true)]
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
			this.chatBrowser.DocumentTitleChanged += chatBrowser_DocumentTitleChanged;
			this.chatBrowser.Navigating += chatBrowser_Navigating;
			this.chatBrowser.Navigated += chatBrowser_Navigated;
			this.chatBrowser.Navigate(this.config.CampfireUrl);
		}

		void chatBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
		}

		void chatBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			this.Text = "Loading...";
		}

		private bool OutsideCampfire(string targetUrl)
		{
			return !(targetUrl.Contains("campfirenow.com") || targetUrl.Contains("37signals.com") || targetUrl.Contains("about:"));
		}

		void chatBrowser_DocumentTitleChanged(object sender, EventArgs e)
		{
			this.Text = this.chatBrowser.Document.Title;
		}

		private void chatBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			var url = e.Url.ToString().ToLower();
			if (Regex.IsMatch(url, @"campfirenow.com/room/\d+$"))
			{
				this.ChatRoom();
			}
		}

		protected override void OnActivated(EventArgs e)
		{
			if (this.chatBrowser.Document != null)
			{
				var inputBox = this.chatBrowser.Document.GetElementById("input");
				if (inputBox != null)
				{
					inputBox.Focus();
				}
			}
		}

		private void ChatRoom()
		{
			this.chatBrowser.ObjectForScripting = this;
			string script = GetScript("room.js");
			Eval(script);
		}

		public bool OpenLink(string url)
		{
			if (OutsideCampfire(url))
			{
				Process.Start(url);
				return true;
			}
			else
			{
				return false;
			}
		}

		private void Eval(string script)
		{
			var window = (IHTMLWindow2) this.chatBrowser.Document.Window.DomWindow;
			window.execScript(script, "javascript");
		}

		private string GetScript(string file)
		{
			var stream = typeof(MainForm).Assembly.GetManifestResourceStream("CampfireGui.js." + file);
			var reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}
	}
}