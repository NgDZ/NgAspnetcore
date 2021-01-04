using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IFeaturesController
	{
		Task<GetFeatureListResultDto> FeaturesGetAsync(string providerName, string providerKey);

		Task FeaturesPutAsync(string providerName, string providerKey, UpdateFeaturesDto body);
	}
}
