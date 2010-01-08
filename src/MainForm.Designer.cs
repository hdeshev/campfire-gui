namespace CampfireGui
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.chatBrowser = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// chatBrowser
			// 
			this.chatBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chatBrowser.Location = new System.Drawing.Point(0, 0);
			this.chatBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.chatBrowser.Name = "chatBrowser";
			this.chatBrowser.Size = new System.Drawing.Size(684, 462);
			this.chatBrowser.TabIndex = 0;
			this.chatBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.chatBrowser_DocumentCompleted);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 462);
			this.Controls.Add(this.chatBrowser);
			this.Name = "MainForm";
			this.Text = "Campfire!";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser chatBrowser;
	}
}