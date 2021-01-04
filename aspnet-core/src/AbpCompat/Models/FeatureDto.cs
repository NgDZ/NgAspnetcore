using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class FeatureDto
	{
		public string Name
		{
			get;
		}

		public string DisplayName
		{
			get;
		}

		public string Value
		{
			get;
		}

		public FeatureProviderDto Provider
		{
			get;
		}

		public string Description
		{
			get;
		}

		public IStringValueType ValueType
		{
			get;
		}

		public int Depth
		{
			get;
		}

		public string ParentName
		{
			get;
		}

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
