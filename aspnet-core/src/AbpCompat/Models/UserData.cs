using System;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UserData
	{
		public Guid Id
		{
			get;
		}

		public Guid? TenantId
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

		public bool EmailConfirmed
		{
			get;
		}

		public string PhoneNumber
		{
			get;
		}

		public bool PhoneNumberConfirmed
		{
			get;
		}

		[JsonConstructor]
		public UserData(string email, bool emailConfirmed, Guid id, string name, string phoneNumber, bool phoneNumberConfirmed, string surname, Guid? tenantId, string userName)
		{
			Id = id;
			TenantId = tenantId;
			UserName = userName;
			Name = name;
			Surname = surname;
			Email = email;
			EmailConfirmed = emailConfirmed;
			PhoneNumber = phoneNumber;
			PhoneNumberConfirmed = phoneNumberConfirmed;
		}
	}
}
