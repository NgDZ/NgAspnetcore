using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UpdateProfileDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string PhoneNumber { get; set; }

		public UpdateProfileDto() { }
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
