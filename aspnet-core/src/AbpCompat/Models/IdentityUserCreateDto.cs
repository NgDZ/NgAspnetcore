using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityUserCreateDto
	{
		public IDictionary<string, object> ExtraProperties
		{
			get;
		}

		public string UserName
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

		public string Email
		{
			get;
		}

		public string PhoneNumber
		{
			get;
		}

		public bool LockoutEnabled
		{
			get;
		}

		public List<string> RoleNames
		{
			get;
		}

		public string Password
		{
			get;
		}

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
