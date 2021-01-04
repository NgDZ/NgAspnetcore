using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleCreateDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public bool IsPublic { get; set; }

		public IdentityRoleCreateDto() { }
		[JsonConstructor]
		public IdentityRoleCreateDto(IDictionary<string, object> extraProperties, bool isDefault, bool isPublic, string name)
		{
			ExtraProperties = extraProperties;
			Name = name;
			IsDefault = isDefault;
			IsPublic = isPublic;
		}
	}
}
