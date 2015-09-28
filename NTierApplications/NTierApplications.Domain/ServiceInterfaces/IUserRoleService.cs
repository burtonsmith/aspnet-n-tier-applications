using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Domain.ServiceInterfaces
{
	public interface IUserRoleService : IRoleStore<UserRole, int>, IQueryableRoleStore<UserRole, int>
	{

    }
}