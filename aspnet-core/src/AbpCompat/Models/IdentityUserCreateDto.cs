using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityUserCreateDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public string UserName { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public bool LockoutEnabled { get; set; }

		public List<string> RoleNames { get; set; }

		public string Password { get; set; }

		public IdentityUserCreateDto() { }
		[JsonConstructor]
		public IdentityUserCreateDto(string email, IDictionary<string, object> extraProperties, bool lockoutEnabled, string name, string password, string phoneNumber, List<string> roleNames, string surname, string userName)
		{
			ExtraProperties = extraProperties;
			UserName = userName;
			Name = name;
			Surname = surname;
			Email = email;
			PhoneNumber = phoneNumber;
			LockoutEnabled = lockoutEnabled;
			RoleNames = roleNames;
			Password = password;
		}
	}
}
