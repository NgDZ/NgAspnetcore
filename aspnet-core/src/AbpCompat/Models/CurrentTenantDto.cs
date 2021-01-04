using System;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class CurrentTenantDto
	{
		public Guid? Id { get; set; }

		public string Name { get; set; }

		public bool IsAvailable { get; set; }

		public CurrentTenantDto() { }
		[JsonConstructor]
		public CurrentTenantDto(Guid? id, bool isAvailable, string name)
		{
			Id = id;
			Name = name;
			IsAvailable = isAvailable;
		}
	}
}
