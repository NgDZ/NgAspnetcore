using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class NameValue
	{
		public string Name
		{
			get;
		}

		public string Value
		{
			get;
		}

		[JsonConstructor]
		public NameValue(string name, string value)
		{
			Name = name;
			Value = value;
		}
	}
}
