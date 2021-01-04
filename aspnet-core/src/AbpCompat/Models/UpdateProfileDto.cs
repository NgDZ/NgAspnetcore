using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UpdateProfileDto
	{
		public IDictionary<string, object> ExtraProperties
		{
			get;
		}

		public string UserName
		{
			get;
		}

		public string Email
		{
			get;
		}

		public string Name
		{
			get;
		}

		public string Surname
		{
			get;
		}

		public string PhoneNumber
		{
			get;
		}

		[JsonConstructor]
		public UpdateProfileDto(string email, IDictionary<string, object> extraProperties, string name, string phoneNumber, string surname, string userName)
		{
			ExtraProperties = extraProperties;
			UserName = userName;
			Email = email;
			Name = name;
			Surname = surname;
			PhoneNumber = phoneNumber;
		}
	}
}
