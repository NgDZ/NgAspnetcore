using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleDtoPagedResultDto
	{
		public List<IdentityRoleDto> Items { get; set; }

		public long TotalCount { get; set; }

		public IdentityRoleDtoPagedResultDto() { }
		[JsonConstructor]
		public IdentityRoleDtoPagedResultDto(List<IdentityRoleDto> items, long totalCount)
		{
			Items = items;
			TotalCount = totalCount;
		}
	}
}
