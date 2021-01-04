using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public interface ITenantController
	{
		Task<TenantDto> TenantsGetAsync(Guid id);

		Task<TenantDto> TenantsPutAsync(Guid id, TenantUpdateDto body);

		Task TenantsDeleteAsync(Guid id);

		Task<TenantDtoPagedResultDto> TenantsGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

		Task<TenantDto> TenantsPostAsync(TenantCreateDto body);

		Task<string> DefaultConnectionStringGetAsync(Guid id);

		Task DefaultConnectionStringPutAsync(Guid id, string defaultConnectionString);

		Task DefaultConnectionStringDeleteAsync(Guid id);
	}
}
