using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityUserUpdateRolesDto
	{
		public List<string> RoleNames
		{
			get;
		}

		[JsonConstructor]
		public IdentityUserUpdateRolesDto(List<string> roleNames)
		{
			RoleNames = roleNames;
		}
	}
}
