using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionEnumDto
	{
		public List<ExtensionEnumFieldDto> Fields { get; set; }

		public string LocalizationResource { get; set; }

		public ExtensionEnumDto() { }
		[JsonConstructor]
		public ExtensionEnumDto(List<ExtensionEnumFieldDto> fields, string localizationResource)
		{
			Fields = fields;
			LocalizationResource = localizationResource;
		}
	}
}
