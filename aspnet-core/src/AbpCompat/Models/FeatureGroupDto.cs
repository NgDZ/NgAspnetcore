using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class FeatureGroupDto
	{
		public string Name
		{
			get;
		}

		public string DisplayName
		{
			get;
		}

		public List<FeatureDto> Features
		{
			get;
		}

		[JsonConstructor]
		public FeatureGroupDto(string displayName, List<FeatureDto> features, string name)
		{
			Name = name;
			DisplayName = displayName;
			Features = features;
		}
	}
}
