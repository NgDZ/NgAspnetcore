using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class EntityExtensionDto
	{
		public IDictionary<string, ExtensionPropertyDto> Properties { get; set; }

		public IDictionary<string, object> Configuration { get; set; }

		public EntityExtensionDto() { }
		[JsonConstructor]
		public EntityExtensionDto(IDictionary<string, object> configuration, IDictionary<string, ExtensionPropertyDto> properties)
		{
			Properties = properties;
			Configuration = configuration;
		}
	}
}
