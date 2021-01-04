using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IAbpApplicationConfigurationController
	{
		Task<ApplicationConfigurationDto> ApplicationConfigurationAsync();
	}
}
