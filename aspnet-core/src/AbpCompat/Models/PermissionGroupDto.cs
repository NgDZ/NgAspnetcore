using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class PermissionGroupDto
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public List<PermissionGrantInfoDto> Permissions { get; set; }

		public PermissionGroupDto() { }
		[JsonConstructor]
		public PermissionGroupDto(string displayName, string name, List<PermissionGrantInfoDto> permissions)
		{
			Name = name;
			DisplayName = displayName;
			Permissions = permissions;
		}
	}
}
