using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TenantCreateDto
	{
		public IDictionary<string, object> ExtraProperties
		{
			get;
		}

		public string Name
		{
			get;
		}

		public string AdminEmailAddress
		{
			get;
		}

		public string AdminPassword
		{
			get;
		}

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
