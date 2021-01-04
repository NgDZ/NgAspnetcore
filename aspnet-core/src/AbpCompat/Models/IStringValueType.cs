using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IStringValueType
	{
		public string Name
		{
			get;
		}

		public IDictionary<string, object> Properties
		{
			get;
		}

		public IValueValidator Validator
		{
			get;
		}

		[JsonConstructor]
		public IStringValueType(string name, IDictionary<string, object> properties, IValueValidator validator)
		{
			Name = name;
			Properties = properties;
			Validator = validator;
		}
	}
}
