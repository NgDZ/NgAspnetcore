using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class CurrentUserDto
	{
		public bool IsAuthenticated
		{
			get;
		}

		public Guid? Id
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

		public string SurName
		{
			get;
		}

		public string Email
		{
			get;
		}

		public bool EmailVerified
		{
			get;
		}

		public string PhoneNumber
		{
			get;
		}

		public bool PhoneNumberVerified
		{
			get;
		}

		public List<string> Roles
		{
			get;
		}

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
