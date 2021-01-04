using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyAttributeDto
	{
		public string TypeSimple
		{
			get;
		}

		public IDictionary<string, object> Config
		{
			get;
		}

		[JsonConstructor]
		public ExtensionPropertyAttributeDto(IDictionary<string, object> config, string typeSimple)
		{
			TypeSimple = typeSimple;
			Config = config;
		}
	}
}
