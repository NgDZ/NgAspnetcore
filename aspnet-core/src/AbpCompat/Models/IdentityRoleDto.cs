using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public bool IsStatic { get; set; }

		public bool IsPublic { get; set; }

		public string ConcurrencyStamp { get; set; }

		public IdentityRoleDto() { }
		[JsonConstructor]
		public IdentityRoleDto(string concurrencyStamp, IDictionary<string, object> extraProperties, Guid id, bool isDefault, bool isPublic, bool isStatic, string name)
		{
			ExtraProperties = extraProperties;
			Id = id;
			Name = name;
			IsDefault = isDefault;
			IsStatic = isStatic;
			IsPublic = isPublic;
			ConcurrencyStamp = concurrencyStamp;
		}
	}
}
