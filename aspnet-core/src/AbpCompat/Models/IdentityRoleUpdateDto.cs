using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleUpdateDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public bool IsPublic { get; set; }

		public string ConcurrencyStamp { get; set; }

		public IdentityRoleUpdateDto() { }
		[JsonConstructor]
		public IdentityRoleUpdateDto(string concurrencyStamp, IDictionary<string, object> extraProperties, bool isDefault, bool isPublic, string name)
		{
			ExtraProperties = extraProperties;
			Name = name;
			IsDefault = isDefault;
			IsPublic = isPublic;
			ConcurrencyStamp = concurrencyStamp;
		}
	}
}
