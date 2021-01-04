using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ObjectExtensionsDto
	{
		public IDictionary<string, ModuleExtensionDto> Modules
		{
			get;
		}

		public IDictionary<string, ExtensionEnumDto> Enums
		{
			get;
		}

		[JsonConstructor]
		public ObjectExtensionsDto(IDictionary<string, ExtensionEnumDto> enums, IDictionary<string, ModuleExtensionDto> modules)
		{
			Modules = modules;
			Enums = enums;
		}
	}
}
