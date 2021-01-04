using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityUserDtoPagedResultDto
	{
		public List<IdentityUserDto> Items
		{
			get;
		}

		public long TotalCount
		{
			get;
		}

		[JsonConstructor]
		public IdentityUserDtoPagedResultDto(List<IdentityUserDto> items, long totalCount)
		{
			Items = items;
			TotalCount = totalCount;
		}
	}
}
