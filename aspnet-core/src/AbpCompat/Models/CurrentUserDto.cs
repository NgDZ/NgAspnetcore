using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class CurrentUserDto
	{
		public bool IsAuthenticated { get; set; }

		public Guid? Id { get; set; }

		public Guid? TenantId { get; set; }

		public string UserName { get; set; }

		public string Name { get; set; }

		public string SurName { get; set; }

		public string Email { get; set; }

		public bool EmailVerified { get; set; }

		public string PhoneNumber { get; set; }

		public bool PhoneNumberVerified { get; set; }

		public List<string> Roles { get; set; }

		public CurrentUserDto() { }
		[JsonConstructor]
		public CurrentUserDto(string email, bool emailVerified, Guid? id, bool isAuthenticated, string name, string phoneNumber, bool phoneNumberVerified, List<string> roles, string surName, Guid? tenantId, string userName)
		{
			IsAuthenticated = isAuthenticated;
			Id = id;
			TenantId = tenantId;
			UserName = userName;
			Name = name;
			SurName = surName;
			Email = email;
			EmailVerified = emailVerified;
			PhoneNumber = phoneNumber;
			PhoneNumberVerified = phoneNumberVerified;
			Roles = roles;
		}
	}
}
