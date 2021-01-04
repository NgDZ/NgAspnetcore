using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityRoleDtoListResultDto
	{
		public List<IdentityRoleDto> Items { get; set; }

		public IdentityRoleDtoListResultDto() { }
		[JsonConstructor]
		public IdentityRoleDtoListResultDto(List<IdentityRoleDto> items)
		{
			Items = items;
		}
	}
}
