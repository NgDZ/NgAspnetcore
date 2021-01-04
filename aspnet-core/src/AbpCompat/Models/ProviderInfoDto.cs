using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ProviderInfoDto
	{
		public string ProviderName { get; set; }

		public string ProviderKey { get; set; }

		public ProviderInfoDto() { }
		[JsonConstructor]
		public ProviderInfoDto(string providerKey, string providerName)
		{
			ProviderName = providerName;
			ProviderKey = providerKey;
		}
	}
}
