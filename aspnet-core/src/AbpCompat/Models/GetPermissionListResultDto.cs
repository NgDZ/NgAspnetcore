using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class GetPermissionListResultDto
	{
		public string EntityDisplayName { get; set; }

		public List<PermissionGroupDto> Groups { get; set; }

		public GetPermissionListResultDto() { }
		[JsonConstructor]
		public GetPermissionListResultDto(string entityDisplayName, List<PermissionGroupDto> groups)
		{
			EntityDisplayName = entityDisplayName;
			Groups = groups;
		}
	}
}
