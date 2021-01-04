using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TenantDtoPagedResultDto
	{
		public List<TenantDto> Items
		{
			get;
		}

		public long TotalCount
		{
			get;
		}

		[JsonConstructor]
		public TenantDtoPagedResultDto(List<TenantDto> items, long totalCount)
		{
			Items = items;
			TotalCount = totalCount;
		}
	}
}
