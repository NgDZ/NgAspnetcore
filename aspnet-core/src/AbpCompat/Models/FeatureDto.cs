using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class FeatureDto
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public string Value { get; set; }

		public FeatureProviderDto Provider { get; set; }

		public string Description { get; set; }

		public IStringValueType ValueType { get; set; }

		public int Depth { get; set; }

		public string ParentName { get; set; }

		public FeatureDto() { }
		[JsonConstructor]
		public FeatureDto(int depth, string description, string displayName, string name, string parentName, FeatureProviderDto provider, string value, IStringValueType valueType)
		{
			Name = name;
			DisplayName = displayName;
			Value = value;
			Provider = provider;
			Description = description;
			ValueType = valueType;
			Depth = depth;
			ParentName = parentName;
		}
	}
}
