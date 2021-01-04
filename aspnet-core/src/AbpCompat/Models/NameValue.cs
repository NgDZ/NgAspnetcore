using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class NameValue
	{
		public string Name { get; set; }

		public string Value { get; set; }

		public NameValue() { }
		[JsonConstructor]
		public NameValue(string name, string value)
		{
			Name = name;
			Value = value;
		}
	}
}
