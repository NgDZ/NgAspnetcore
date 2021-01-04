using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleDtoPagedResultDto
	{
		public List<IdentityRoleDto> Items
		{
			get;
		}

		public long TotalCount
		{
			get;
		}

		[JsonConstructor]
		public IdentityRoleDtoPagedResultDto(List<IdentityRoleDto> items, long totalCount)
		{
			Items = items;
			TotalCount = totalCount;
		}
	}
}
