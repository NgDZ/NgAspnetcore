using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ModuleExtensionDto
	{
		public IDictionary<string, EntityExtensionDto> Entities { get; set; }

		public IDictionary<string, object> Configuration { get; set; }

		public ModuleExtensionDto() { }
		[JsonConstructor]
		public ModuleExtensionDto(IDictionary<string, object> configuration, IDictionary<string, EntityExtensionDto> entities)
		{
			Entities = entities;
			Configuration = configuration;
		}
	}
}
