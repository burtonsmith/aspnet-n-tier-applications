using Microsoft.AspNet.Identity;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Domain.ServiceInterfaces
{
	public interface IUserRoleService : IRoleStore<UserRole, int>
	{
		 
	}
}