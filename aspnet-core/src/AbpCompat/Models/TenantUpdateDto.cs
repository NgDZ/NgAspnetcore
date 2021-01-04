using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TenantUpdateDto
	{
		public IDictionary<string, object> ExtraProperties
		{
			get;
		}

		public string Name
		{
			get;
		}

		[JsonConstructor]
		public TenantUpdateDto(IDictionary<string, object> extraProperties, string name)
		{
			ExtraProperties = extraProperties;
			Name = name;
		}
	}
}
