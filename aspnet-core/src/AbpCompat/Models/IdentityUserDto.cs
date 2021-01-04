using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IdentityUserDto
	{
		public IDictionary<string, object> ExtraProperties { get; set; }

		public Guid Id { get; set; }

		public DateTimeOffset CreationTime { get; set; }

		public Guid? CreatorId { get; set; }

		public DateTimeOffset? LastModificationTime { get; set; }

		public Guid? LastModifierId { get; set; }

		public bool IsDeleted { get; set; }

		public Guid? DeleterId { get; set; }

		public DateTimeOffset? DeletionTime { get; set; }

		public Guid? TenantId { get; set; }

		public string UserName { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }

		public bool EmailConfirmed { get; set; }

		public string PhoneNumber { get; set; }

		public bool PhoneNumberConfirmed { get; set; }

		public bool LockoutEnabled { get; set; }

		public DateTimeOffset? LockoutEnd { get; set; }

		public string ConcurrencyStamp { get; set; }

		public IdentityUserDto() { }
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
