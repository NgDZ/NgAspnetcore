using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class FeatureProviderDto
	{
		public string Name
		{
			get;
		}

		public string Key
		{
			get;
		}

		[JsonConstructor]
		public FeatureProviderDto(string key, string name)
		{
			Name = name;
			Key = key;
		}
	}
}
