using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TenantDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public TenantDto() { }
		[JsonConstructor]
		public TenantDto(IDictionary<string, object> extraProperties, Guid id, string name)
		{
			ExtraProperties = extraProperties;
			Id = id;
			Name = name;
		}
	}
}
