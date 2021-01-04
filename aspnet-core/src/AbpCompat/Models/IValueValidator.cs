using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IValueValidator
	{
		public string Name
		{
			get;
		}

		public IDictionary<string, object> Properties
		{
			get;
		}

		[JsonConstructor]
		public IValueValidator(string name, IDictionary<string, object> properties)
		{
			Name = name;
			Properties = properties;
		}
	}
}
