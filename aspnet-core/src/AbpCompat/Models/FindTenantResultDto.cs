using System;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class FindTenantResultDto
	{
		public bool Success { get; set; }

		public Guid? TenantId { get; set; }

		public string Name { get; set; }

		public FindTenantResultDto() { }
		[JsonConstructor]
		public FindTenantResultDto(string name, bool success, Guid? tenantId)
		{
			Success = success;
			TenantId = tenantId;
			Name = name;
		}
	}
}
