using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionEnumDto
	{
		public List<ExtensionEnumFieldDto> Fields
		{
			get;
		}

		public string LocalizationResource
		{
			get;
		}

		[JsonConstructor]
		public ExtensionEnumDto(List<ExtensionEnumFieldDto> fields, string localizationResource)
		{
			Fields = fields;
			LocalizationResource = localizationResource;
		}
	}
}
