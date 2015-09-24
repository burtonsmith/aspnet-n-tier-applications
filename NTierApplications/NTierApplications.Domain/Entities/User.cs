﻿using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace NTierApplications.Domain.Entities
{
	public class User : BaseEntity, IUser<int>
	{

		/// <summary>
		/// User's name
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		///     Email
		/// </summary>
		public virtual string Email { get; set; }

		/// <summary>
		///     True if the email is confirmed, default is false
		/// </summary>
		public virtual bool EmailConfirmed { get; set; }

		/// <summary>
		///     The salted/hashed form of the user password
		/// </summary>
		public virtual string PasswordHash { get; set; }

		/// <summary>
		///     A random value that should change whenever a users credentials have changed (password changed, login removed)
		/// </summary>
		public virtual string SecurityStamp { get; set; }

		/// <summary>
		///     PhoneNumber for the user
		/// </summary>
		public virtual string PhoneNumber { get; set; }

		/// <summary>
		///     True if the phone number is confirmed, default is false
		/// </summary>
		public virtual bool PhoneNumberConfirmed { get; set; }

		/// <summary>
		///     Is two factor enabled for the user
		/// </summary>
		public virtual bool TwoFactorEnabled { get; set; }

		/// <summary>
		///     DateTime in UTC when lockout ends, any time in the past is considered not locked out.
		/// </summary>
		public virtual DateTime? LockoutEndDateUtc { get; set; }

		/// <summary>
		///     Is lockout enabled for this user
		/// </summary>
		public virtual bool LockoutEnabled { get; set; }

		/// <summary>
		///     Used to record failures for the purposes of lockout
		/// </summary>
		public virtual int AccessFailedCount { get; set; }

		public virtual ICollection<UserClaim> UserClaims { get; set; }
		public virtual ICollection<UserLogin> UserLogins { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
