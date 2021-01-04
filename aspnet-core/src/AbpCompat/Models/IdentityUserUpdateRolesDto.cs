using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityUserUpdateRolesDto
	{
		public List<string> RoleNames { get; set; }

		public IdentityUserUpdateRolesDto() { }
		[JsonConstructor]
		public IdentityUserUpdateRolesDto(List<string> roleNames)
		{
			RoleNames = roleNames;
		}
	}
}
