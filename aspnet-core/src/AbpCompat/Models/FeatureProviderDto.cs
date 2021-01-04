using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class FeatureProviderDto
	{
		public string Name { get; set; }

		public string Key { get; set; }

		public FeatureProviderDto() { }
		[JsonConstructor]
		public FeatureProviderDto(string key, string name)
		{
			Name = name;
			Key = key;
		}
	}
}
