using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleUpdateDto
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

		public string ConcurrencyStamp
		{
			get;
		}

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
