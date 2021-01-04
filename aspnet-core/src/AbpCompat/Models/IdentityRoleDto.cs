using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleDto
	{
		public IDictionary<string, object> ExtraProperties
		{
			get;
		}

		public Guid Id
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

		public bool IsStatic
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
