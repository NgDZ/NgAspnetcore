using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyDto
	{
		public string Type
		{
			get;
		}

		public string TypeSimple
		{
			get;
		}

		public LocalizableStringDto DisplayName
		{
			get;
		}

		public ExtensionPropertyApiDto Api
		{
			get;
		}

		public ExtensionPropertyUiDto Ui
		{
			get;
		}

		public List<ExtensionPropertyAttributeDto> Attributes
		{
			get;
		}

		public IDictionary<string, object> Configuration
		{
			get;
		}

		public object DefaultValue
		{
			get;
		}

		[JsonConstructor]
		public ExtensionPropertyDto(ExtensionPropertyApiDto api, List<ExtensionPropertyAttributeDto> attributes, IDictionary<string, object> configuration, object defaultValue, LocalizableStringDto displayName, string type, string typeSimple, ExtensionPropertyUiDto ui)
		{
			Type = type;
			TypeSimple = typeSimple;
			DisplayName = displayName;
			Api = api;
			Ui = ui;
			Attributes = attributes;
			Configuration = configuration;
			DefaultValue = defaultValue;
		}
	}
}
