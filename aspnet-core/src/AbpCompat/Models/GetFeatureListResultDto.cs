using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class GetFeatureListResultDto
	{
		public List<FeatureGroupDto> Groups
		{
			get;
		}

		[JsonConstructor]
		public GetFeatureListResultDto(List<FeatureGroupDto> groups)
		{
			Groups = groups;
		}
	}
}
