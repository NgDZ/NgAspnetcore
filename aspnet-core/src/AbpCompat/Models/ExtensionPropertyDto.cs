using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyDto
	{
		public string Type { get; set; }

		public string TypeSimple { get; set; }

		public LocalizableStringDto DisplayName { get; set; }

		public ExtensionPropertyApiDto Api { get; set; }

		public ExtensionPropertyUiDto Ui { get; set; }

		public List<ExtensionPropertyAttributeDto> Attributes { get; set; }

		public IDictionary<string, object> Configuration { get; set; }

		public object DefaultValue { get; set; }

		public ExtensionPropertyDto() { }
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
