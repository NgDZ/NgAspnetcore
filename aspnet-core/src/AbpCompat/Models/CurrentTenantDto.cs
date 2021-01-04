using System;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class CurrentTenantDto
	{
		public Guid? Id
		{
			get;
		}

		public string Name
		{
			get;
		}

		public bool IsAvailable
		{
			get;
		}

		[JsonConstructor]
		public CurrentTenantDto(Guid? id, bool isAvailable, string name)
		{
			Id = id;
			Name = name;
			IsAvailable = isAvailable;
		}
	}
}
