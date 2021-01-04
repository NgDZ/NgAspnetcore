using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyUiLookupDto
	{
		public string Url { get; set; }

		public string ResultListPropertyName { get; set; }

		public string DisplayPropertyName { get; set; }

		public string ValuePropertyName { get; set; }

		public string FilterParamName { get; set; }

		public ExtensionPropertyUiLookupDto() { }
		[JsonConstructor]
		public ExtensionPropertyUiLookupDto(string displayPropertyName, string filterParamName, string resultListPropertyName, string url, string valuePropertyName)
		{
			Url = url;
			ResultListPropertyName = resultListPropertyName;
			DisplayPropertyName = displayPropertyName;
			ValuePropertyName = valuePropertyName;
			FilterParamName = filterParamName;
		}
	}
}
