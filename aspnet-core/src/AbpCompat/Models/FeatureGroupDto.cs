using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class FeatureGroupDto
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public List<FeatureDto> Features { get; set; }

		public FeatureGroupDto() { }
		[JsonConstructor]
		public FeatureGroupDto(string displayName, List<FeatureDto> features, string name)
		{
			Name = name;
			DisplayName = displayName;
			Features = features;
		}
	}
}
