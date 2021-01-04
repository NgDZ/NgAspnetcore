using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class PermissionGrantInfoDto
	{
		public string Name
		{
			get;
		}

		public string DisplayName
		{
			get;
		}

		public string ParentName
		{
			get;
		}

		public bool IsGranted
		{
			get;
		}

		public List<string> AllowedProviders
		{
			get;
		}

		public List<ProviderInfoDto> GrantedProviders
		{
			get;
		}

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
