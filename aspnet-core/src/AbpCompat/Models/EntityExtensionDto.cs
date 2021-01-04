using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class EntityExtensionDto
	{
		public IDictionary<string, ExtensionPropertyDto> Properties
		{
			get;
		}

		public IDictionary<string, object> Configuration
		{
			get;
		}

		[JsonConstructor]
		public EntityExtensionDto(IDictionary<string, object> configuration, IDictionary<string, ExtensionPropertyDto> properties)
		{
			Properties = properties;
			Configuration = configuration;
		}
	}
}
