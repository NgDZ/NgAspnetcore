using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class CurrentCultureDto
	{
		public string DisplayName
		{
			get;
		}

		public string EnglishName
		{
			get;
		}

		public string ThreeLetterIsoLanguageName
		{
			get;
		}

		public string TwoLetterIsoLanguageName
		{
			get;
		}

		public bool IsRightToLeft
		{
			get;
		}

		public string CultureName
		{
			get;
		}

		public string Name
		{
			get;
		}

		public string NativeName
		{
			get;
		}

		public DateTimeFormatDto DateTimeFormat
		{
			get;
		}

		[JsonConstructor]
		public CurrentCultureDto(string cultureName, DateTimeFormatDto dateTimeFormat, string displayName, string englishName, bool isRightToLeft, string name, string nativeName, string threeLetterIsoLanguageName, string twoLetterIsoLanguageName)
		{
			DisplayName = displayName;
			EnglishName = englishName;
			ThreeLetterIsoLanguageName = threeLetterIsoLanguageName;
			TwoLetterIsoLanguageName = twoLetterIsoLanguageName;
			IsRightToLeft = isRightToLeft;
			CultureName = cultureName;
			Name = name;
			NativeName = nativeName;
			DateTimeFormat = dateTimeFormat;
		}
	}
}
