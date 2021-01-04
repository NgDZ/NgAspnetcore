using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class LanguageInfo
	{
		public string CultureName { get; set; }

		public string UiCultureName { get; set; }

		public string DisplayName { get; set; }

		public string FlagIcon { get; set; }

		public LanguageInfo() { }
		[JsonConstructor]
		public LanguageInfo(string cultureName, string displayName, string flagIcon, string uiCultureName)
		{
			CultureName = cultureName;
			UiCultureName = uiCultureName;
			DisplayName = displayName;
			FlagIcon = flagIcon;
		}
	}
}
