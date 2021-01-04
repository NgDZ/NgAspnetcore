using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityUserDto
	{
		public IDictionary<string, object> ExtraProperties
		{
			get;
		}

		public Guid Id
		{
			get;
		}

		public DateTimeOffset CreationTime
		{
			get;
		}

		public Guid? CreatorId
		{
			get;
		}

		public DateTimeOffset? LastModificationTime
		{
			get;
		}

		public Guid? LastModifierId
		{
			get;
		}

		public bool IsDeleted
		{
			get;
		}

		public Guid? DeleterId
		{
			get;
		}

		public DateTimeOffset? DeletionTime
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

		public bool LockoutEnabled
		{
			get;
		}

		public DateTimeOffset? LockoutEnd
		{
			get;
		}

		public string ConcurrencyStamp
		{
			get;
		}

		[JsonConstructor]
		public IdentityUserDto(string concurrencyStamp, DateTimeOffset creationTime, Guid? creatorId, Guid? deleterId, DateTimeOffset? deletionTime, string email, bool emailConfirmed, IDictionary<string, object> extraProperties, Guid id, bool isDeleted, DateTimeOffset? lastModificationTime, Guid? lastModifierId, bool lockoutEnabled, DateTimeOffset? lockoutEnd, string name, string phoneNumber, bool phoneNumberConfirmed, string surname, Guid? tenantId, string userName)
		{
			ExtraProperties = extraProperties;
			Id = id;
			CreationTime = creationTime;
			CreatorId = creatorId;
			LastModificationTime = lastModificationTime;
			LastModifierId = lastModifierId;
			IsDeleted = isDeleted;
			DeleterId = deleterId;
			DeletionTime = deletionTime;
			TenantId = tenantId;
			UserName = userName;
			Name = name;
			Surname = surname;
			Email = email;
			EmailConfirmed = emailConfirmed;
			PhoneNumber = phoneNumber;
			PhoneNumberConfirmed = phoneNumberConfirmed;
			LockoutEnabled = lockoutEnabled;
			LockoutEnd = lockoutEnd;
			ConcurrencyStamp = concurrencyStamp;
		}
	}
}
