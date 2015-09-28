using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Domain.ServiceInterfaces
{
	public interface IUserService : 
		IUserPasswordStore<User, int>,
		IUserSecurityStampStore<User, int>,
		IUserEmailStore<User, int>,
		IUserPhoneNumberStore<User, int>,
		IUserTwoFactorStore<User, int>,
		IUserLockoutStore<User,	int>,
		IUserLoginStore<User, int>,
		IUserClaimStore<User, int>,
		IUserStore<User, int> // Kept so I know it was implemented.
	{
		Task<User> FindByLoginAsync(string userName, string password);
		Task<IEnumerable<User>> GetAllAsync();
		Task<User> FindByProviderAsync(string loginProvider, string providerKey);
		Task<User> FindAsync(string loginProvider, string providerKey);
	}
}