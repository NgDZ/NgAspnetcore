using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UpdateFeatureDto
	{
		public string Name { get; set; }

		public string Value { get; set; }

		public UpdateFeatureDto() { }
		[JsonConstructor]
		public UpdateFeatureDto(string name, string value)
		{
			Name = name;
			Value = value;
		}
	}
}
