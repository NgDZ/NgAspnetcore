using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class FeaturesController : ApiController
	{
		[HttpGet]
		[Route("api/feature-management/features", Name = "features")]
		public Task<GetFeatureListResultDto> FeaturesGet([FromQuery] string providerName, [FromQuery] string providerKey)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPut]
		[Route("api/feature-management/features", Name = "features2")]
		public Task FeaturesPut([FromQuery] string providerName, [FromQuery] string providerKey, [FromBody] UpdateFeaturesDto body)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
