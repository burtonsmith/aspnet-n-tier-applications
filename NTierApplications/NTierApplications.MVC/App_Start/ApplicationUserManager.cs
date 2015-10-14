using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NTierApplications.Data.Context;
using NTierApplications.Data.Repositories;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.ServiceInterfaces;
using NTierApplications.Domain.Services;

namespace NTierApplications.MVC
{
	// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
	public class ApplicationUserManager : UserManager<User, int>
	{
		public ApplicationUserManager(IUserService userService)
			: base(userService)
		{
		}

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var userRepository = new EfRepository<User>(new NTierApplicationsDataContext("NTierApplicationsDataContext"));
            var userRoleRepository = new EfRepository<UserRole>(new NTierApplicationsDataContext("NTierApplicationsDataContext"));

            var userService = new UserService(userRepository, userRoleRepository);

			var manager = new ApplicationUserManager(userService);
			// Configure validation logic for usernames
			manager.UserValidator = new UserValidator<User, int>(manager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};

			// Configure validation logic for passwords
			manager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = true,
				RequireDigit = true,
				RequireLowercase = true,
				RequireUppercase = true,
			};

			// Configure user lockout defaults
			manager.UserLockoutEnabledByDefault = true;
			manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			manager.MaxFailedAccessAttemptsBeforeLockout = 5;

			// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
			// You can write your own provider and plug it in here.
			manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User, int>
			{
				MessageFormat = "Your security code is {0}"
			});
			manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User, int>
			{
				Subject = "Security Code",
				BodyFormat = "Your security code is {0}"
			});
			manager.EmailService = new EmailService();
			manager.SmsService = new SmsService();
			var dataProtectionProvider = options.DataProtectionProvider;
			if (dataProtectionProvider != null)
			{
				manager.UserTokenProvider =
					new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
			}
			return manager;
		}
	}
}