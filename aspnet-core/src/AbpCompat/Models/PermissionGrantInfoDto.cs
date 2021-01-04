using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class PermissionGrantInfoDto
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public string ParentName { get; set; }

		public bool IsGranted { get; set; }

		public List<string> AllowedProviders { get; set; }

		public List<ProviderInfoDto> GrantedProviders { get; set; }

		public PermissionGrantInfoDto() { }
		[JsonConstructor]
		public PermissionGrantInfoDto(List<string> allowedProviders, string displayName, List<ProviderInfoDto> grantedProviders, bool isGranted, string name, string parentName)
		{
			Name = name;
			DisplayName = displayName;
			ParentName = parentName;
			IsGranted = isGranted;
			AllowedProviders = allowedProviders;
			GrantedProviders = grantedProviders;
		}
	}
}
