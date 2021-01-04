using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class CurrentCultureDto
	{
		public string DisplayName { get; set; }

		public string EnglishName { get; set; }

		public string ThreeLetterIsoLanguageName { get; set; }

		public string TwoLetterIsoLanguageName { get; set; }

		public bool IsRightToLeft { get; set; }

		public string CultureName { get; set; }

		public string Name { get; set; }

		public string NativeName { get; set; }

		public DateTimeFormatDto DateTimeFormat { get; set; }

		public CurrentCultureDto() { }
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
