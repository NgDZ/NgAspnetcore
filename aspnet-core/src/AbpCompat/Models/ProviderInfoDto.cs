using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ProviderInfoDto
	{
		public string ProviderName
		{
			get;
		}

		public string ProviderKey
		{
			get;
		}

		[JsonConstructor]
		public ProviderInfoDto(string providerKey, string providerName)
		{
			ProviderName = providerName;
			ProviderKey = providerKey;
		}
	}
}
