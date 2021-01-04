using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TenantDtoPagedResultDto
	{
		public List<TenantDto> Items { get; set; }

		public long TotalCount { get; set; }

		public TenantDtoPagedResultDto() { }
		[JsonConstructor]
		public TenantDtoPagedResultDto(List<TenantDto> items, long totalCount)
		{
			Items = items;
			TotalCount = totalCount;
		}
	}
}
