using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleCreateDto
	{
		public IDictionary<string, object> ExtraProperties
		{
			get;
		}

		public string Name
		{
			get;
		}

		public bool IsDefault
		{
			get;
		}

		public bool IsPublic
		{
			get;
		}

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
