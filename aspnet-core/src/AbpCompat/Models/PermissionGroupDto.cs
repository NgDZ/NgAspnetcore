using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class PermissionGroupDto
	{
		public string Name
		{
			get;
		}

		public string DisplayName
		{
			get;
		}

		public List<PermissionGrantInfoDto> Permissions
		{
			get;
		}

		[JsonConstructor]
		public PermissionGroupDto(string displayName, string name, List<PermissionGrantInfoDto> permissions)
		{
			Name = name;
			DisplayName = displayName;
			Permissions = permissions;
		}
	}
}
