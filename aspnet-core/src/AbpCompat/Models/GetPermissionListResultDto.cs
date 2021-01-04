using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class GetPermissionListResultDto
	{
		public string EntityDisplayName
		{
			get;
		}

		public List<PermissionGroupDto> Groups
		{
			get;
		}

		[JsonConstructor]
		public GetPermissionListResultDto(string entityDisplayName, List<PermissionGroupDto> groups)
		{
			EntityDisplayName = entityDisplayName;
			Groups = groups;
		}
	}
}
