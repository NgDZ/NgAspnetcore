using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IStringValueType
	{
		public string Name { get; set; }

		public IDictionary<string, object> Properties { get; set; }

		public IValueValidator Validator { get; set; }

		public IStringValueType() { }
		[JsonConstructor]
		public IStringValueType(string name, IDictionary<string, object> properties, IValueValidator validator)
		{
			Name = name;
			Properties = properties;
			Validator = validator;
		}
	}
}
