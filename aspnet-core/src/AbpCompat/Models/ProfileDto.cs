using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ProfileDto
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

		public bool IsExternal
		{
			get;
		}

		public bool HasPassword
		{
			get;
		}

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
