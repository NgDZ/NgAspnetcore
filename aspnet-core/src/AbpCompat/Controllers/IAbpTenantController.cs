using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IAbpTenantController
	{
		Task<FindTenantResultDto> ByNameAsync(string name);

		Task<FindTenantResultDto> ByIdAsync(Guid id);
	}
}
