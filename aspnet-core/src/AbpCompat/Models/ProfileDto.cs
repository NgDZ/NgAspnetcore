using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ProfileDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string PhoneNumber { get; set; }

		public bool IsExternal { get; set; }

		public bool HasPassword { get; set; }

		public ProfileDto() { }
		[JsonConstructor]
		public ProfileDto(string email, IDictionary<string, object> extraProperties, bool hasPassword, bool isExternal, string name, string phoneNumber, string surname, string userName)
		{
			ExtraProperties = extraProperties;
			UserName = userName;
			Email = email;
			Name = name;
			Surname = surname;
			PhoneNumber = phoneNumber;
			IsExternal = isExternal;
			HasPassword = hasPassword;
		}
	}
}
