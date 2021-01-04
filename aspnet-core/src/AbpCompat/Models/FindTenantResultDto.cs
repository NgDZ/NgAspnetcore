using System;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class FindTenantResultDto
	{
		public bool Success
		{
			get;
		}

		public Guid? TenantId
		{
			get;
		}

		public string Name
		{
			get;
		}

		[JsonConstructor]
		public FindTenantResultDto(string name, bool success, Guid? tenantId)
		{
			Success = success;
			TenantId = tenantId;
			Name = name;
		}
	}
}
