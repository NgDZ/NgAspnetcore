using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class LanguageInfo
	{
		public string CultureName
		{
			get;
		}

		public string UiCultureName
		{
			get;
		}

		public string DisplayName
		{
			get;
		}

		public string FlagIcon
		{
			get;
		}

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
