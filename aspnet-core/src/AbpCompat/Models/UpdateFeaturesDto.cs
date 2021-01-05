using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UpdateFeaturesDto
	{
		public List<UpdateFeatureDto> Features { get; set; }

		public UpdateFeaturesDto() { }
		[JsonConstructor]
		public UpdateFeaturesDto(List<UpdateFeatureDto> features)
		{
			Features = features;
		}
	}
}