using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UpdatePermissionsDto
	{
		public List<UpdatePermissionDto> Permissions { get; set; }

		public UpdatePermissionsDto() { }
		[JsonConstructor]
		public UpdatePermissionsDto(List<UpdatePermissionDto> permissions)
		{
			Permissions = permissions;
		}
	}
}
