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
	public class ApplicationRoleManager : RoleManager<UserRole, int>
	{
		public ApplicationRoleManager(IUserRoleService userRoleService) : base(userRoleService)
		{
		}

		public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
		{
			var userRoleRepository = new EfRepository<UserRole>(new NTierApplicationsDataContext("NTierApplicationsDataContext"));
			var userRoleService = new UserRoleService(userRoleRepository);

			return new ApplicationRoleManager(userRoleService);
		}
	}
}