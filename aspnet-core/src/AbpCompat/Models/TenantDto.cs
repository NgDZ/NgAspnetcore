using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TenantDto
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

		[JsonConstructor]
		public TenantDto(IDictionary<string, object> extraProperties, Guid id, string name)
		{
			ExtraProperties = extraProperties;
			Id = id;
			Name = name;
		}
	}
}
