using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ObjectExtensionsDto
	{
		public IDictionary<string, ModuleExtensionDto> Modules { get; set; }

		public IDictionary<string, ExtensionEnumDto> Enums { get; set; }

		public ObjectExtensionsDto() { }
		[JsonConstructor]
		public ObjectExtensionsDto(IDictionary<string, ExtensionEnumDto> enums, IDictionary<string, ModuleExtensionDto> modules)
		{
			Modules = modules;
			Enums = enums;
		}
	}
}
