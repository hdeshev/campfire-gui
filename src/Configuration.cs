using System.Configuration;
using System.Runtime.InteropServices;

namespace CampfireGui
{
	[ComVisible(true)]
	public class Configuration
	{
		public string CampfireUrl
		{
			get
			{
				return ReadSettingString("CampfireUrl");
			}
		}
		
		public string Username
		{
			get
			{
				return ReadSettingString("Username");
			}
		}

		public string Password
		{
			get
			{
				return ReadSettingString("Password");
			}
		}

		private string ReadSettingString(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}