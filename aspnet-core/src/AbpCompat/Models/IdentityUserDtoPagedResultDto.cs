using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityUserDtoPagedResultDto
	{
		public List<IdentityUserDto> Items { get; set; }

		public long TotalCount { get; set; }

		public IdentityUserDtoPagedResultDto() { }
		[JsonConstructor]
		public IdentityUserDtoPagedResultDto(List<IdentityUserDto> items, long totalCount)
		{
			Items = items;
			TotalCount = totalCount;
		}
	}
}
