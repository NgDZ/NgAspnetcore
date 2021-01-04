using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TenantCreateDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public string Name { get; set; }

		public string AdminEmailAddress { get; set; }

		public string AdminPassword { get; set; }

		public TenantCreateDto() { }
		[JsonConstructor]
		public TenantCreateDto(string adminEmailAddress, string adminPassword, IDictionary<string, object> extraProperties, string name)
		{
			ExtraProperties = extraProperties;
			Name = name;
			AdminEmailAddress = adminEmailAddress;
			AdminPassword = adminPassword;
		}
	}
}
