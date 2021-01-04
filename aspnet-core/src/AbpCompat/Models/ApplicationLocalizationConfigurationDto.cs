using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ApplicationLocalizationConfigurationDto
	{
		public IDictionary<string, IDictionary<string, string>> Values { get; set; }

		public List<LanguageInfo> Languages { get; set; }

		public CurrentCultureDto CurrentCulture { get; set; }

		public string DefaultResourceName { get; set; }

		public IDictionary<string, List<NameValue>> LanguagesMap { get; set; }

		public IDictionary<string, List<NameValue>> LanguageFilesMap { get; set; }

		public ApplicationLocalizationConfigurationDto() { }
		[JsonConstructor]
		public ApplicationLocalizationConfigurationDto(CurrentCultureDto currentCulture, string defaultResourceName, IDictionary<string, List<NameValue>> languageFilesMap, List<LanguageInfo> languages, IDictionary<string, List<NameValue>> languagesMap, IDictionary<string, IDictionary<string, string>> values)
		{
			Values = values;
			Languages = languages;
			CurrentCulture = currentCulture;
			DefaultResourceName = defaultResourceName;
			LanguagesMap = languagesMap;
			LanguageFilesMap = languageFilesMap;
		}
	}
}
