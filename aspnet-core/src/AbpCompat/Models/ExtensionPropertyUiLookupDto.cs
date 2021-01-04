using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyUiLookupDto
	{
		public string Url
		{
			get;
		}

		public string ResultListPropertyName
		{
			get;
		}

		public string DisplayPropertyName
		{
			get;
		}

		public string ValuePropertyName
		{
			get;
		}

		public string FilterParamName
		{
			get;
		}

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
