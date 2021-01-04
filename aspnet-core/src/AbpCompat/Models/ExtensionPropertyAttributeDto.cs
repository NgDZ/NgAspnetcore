using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyAttributeDto
	{
		public string TypeSimple { get; set; }

		public IDictionary<string, object> Config { get; set; }

		public ExtensionPropertyAttributeDto() { }
		[JsonConstructor]
		public ExtensionPropertyAttributeDto(IDictionary<string, object> config, string typeSimple)
		{
			TypeSimple = typeSimple;
			Config = config;
		}
	}
}
