using System;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UserData
	{
		public Guid Id { get; set; }

		public Guid? TenantId { get; set; }

		public string UserName { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }

		public bool EmailConfirmed { get; set; }

		public string PhoneNumber { get; set; }

		public bool PhoneNumberConfirmed { get; set; }

		public UserData() { }
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
