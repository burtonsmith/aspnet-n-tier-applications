using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Win32.SafeHandles;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _userRepository;
	    private readonly IRepository<UserRole> _userRoleRepository; 

		bool _disposed;
		readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

	    public UserService(IRepository<User> userRepository, IRepository<UserRole> userRole)
		{
			_userRepository = userRepository;
	        _userRoleRepository = userRole;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
				_handle.Dispose();

			_disposed = true;
		}


        //
        // Basic CRUD Management
        //


        #region Basic CRUD

        public IQueryable<User> Users => _userRepository.Table.AsQueryable();

        public Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.Insert(user);

            return Task.FromResult<object>(null);
        }

        public Task UpdateAsync(User user)
        {
            _userRepository.Update(user);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.Delete(user.Id);

            return Task.FromResult<object>(null);
        }

        public Task<User> FindByIdAsync(int userId)
        {
            if (userId == 0)
                throw new ArgumentNullException("userId");

            var result = _userRepository.GetById(userId);

            if (result != null)
                return Task.FromResult(result);

            return Task.FromResult<User>(null);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");

            var result =
                _userRepository.Table.FirstOrDefault(x => x.UserName.ToUpper() == userName.ToUpper());

            return Task.FromResult(result);
        }

        #endregion


        //
        // User Info Management
        //


        #region User Info

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            string passwordHash = _userRepository.GetById(user.Id).PasswordHash;

            return Task.FromResult(passwordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var hasPassword = !string.IsNullOrEmpty(_userRepository.GetById(user.Id).PasswordHash);

            return Task.FromResult(bool.Parse(hasPassword.ToString()));
        }

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.SecurityStamp = stamp;

            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetEmailAsync(User user, string email)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.Email = email;

            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.EmailConfirmed = confirmed;

            return Task.FromResult(0);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");

            var result =
                _userRepository.Table.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());

            if (result != null)
                return Task.FromResult(result);

            return Task.FromResult<User>(null);
        }

        public Task SetPhoneNumberAsync(User user, string phoneNumber)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PhoneNumber = phoneNumber;

            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PhoneNumberConfirmed = confirmed;

            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.TwoFactorEnabled = enabled;

            return Task.FromResult(0);

        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.TwoFactorEnabled);
        }

        #endregion


        //
        // Login Management
        //


        #region Login

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.LockoutEndDateUtc.HasValue
                ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                : new DateTimeOffset());
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.LockoutEndDateUtc = lockoutEnd.UtcDateTime;
            _userRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.AccessFailedCount++;
            _userRepository.Update(user);

            return Task.FromResult(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.AccessFailedCount = 0;
            _userRepository.Update(user);

            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.LockoutEnabled = enabled;

            return Task.FromResult(0);
        }

        public async Task<User> FindByLoginAsync(string userName, string password)
        {
            if (userName == null)
                throw new ArgumentNullException("userName");

            return
                await
                    Task.Run(() => _userRepository.Table.FirstOrDefault(x => x.UserName == userName && x.PasswordHash == password));
        }


        public async Task<User> FindByProviderAsync(string loginProvider, string providerKey)
        {
            if (loginProvider == null)
                throw new ArgumentNullException("loginProvider");

            return await Task.Run(() => _userRepository.Table.FirstOrDefault(
                    x =>
                        x.Id ==
                        x.UserLogins.FirstOrDefault(y => y.LoginProvider == loginProvider && y.ProviderKey == providerKey).UserId));
        }

        public async Task<User> FindAsync(string loginProvider, string providerKey)
        {
            if (loginProvider == null)
                throw new ArgumentNullException("loginProvider");

            return await Task.Run(() => _userRepository.Table.FirstOrDefault(x => x.UserName == loginProvider && x.PasswordHash == providerKey));
        }

        public async Task AddLoginAsync(User user, UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            var loginToAdd = new UserLogin()
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            };

            user.UserLogins.Add(loginToAdd);

            await Task.Run(() => _userRepository.Update(user));
        }

        public async Task<User> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            var user = _userRepository.Table.FirstOrDefault(x =>
            {
                var userLogin = x.UserLogins.FirstOrDefault(y => y.LoginProvider == login.LoginProvider && y.ProviderKey == login.ProviderKey);
                return userLogin != null && x.Id == userLogin.UserId;
            });

            return await Task.Run(() => user);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var logins = from l in user.UserLogins
                         select new UserLoginInfo(l.LoginProvider, l.ProviderKey)
                         {
                             LoginProvider = l.LoginProvider,
                             ProviderKey = l.ProviderKey
                         };

            return await Task.Run(() => logins.ToList());
        }

        public async Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            var loginToDelete =
                user.UserLogins.FirstOrDefault(x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey);

            if (loginToDelete == null)
                return;

            user.UserLogins.Remove(loginToDelete);

            await Task.Run(() => _userRepository.Update(user));
        }

        #endregion


        //
        // Claims Management
        //


        #region Claims

        public async Task<IList<Claim>> GetClaimsAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "A valid user us required.");

            var claims = from c in user.UserClaims
                         select new Claim(c.ClaimType, c.ClaimValue);

            return await Task.Run(() => claims.ToList());
        }

        public async Task AddClaimAsync(User user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (claim == null)
                throw new NullReferenceException("claim");

            var newClaim = new UserClaim() { ClaimType = claim.Type, ClaimValue = claim.Value, UserId = user.Id };

            user.UserClaims.Add(newClaim);

            await Task.Run(() => _userRepository.Update(user));
        }

        public async Task RemoveClaimAsync(User user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (claim == null)
                throw new NullReferenceException("claim");

            var claimToDelete = user.UserClaims.FirstOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);

            if (claimToDelete == null)
                return;

            user.UserClaims.Remove(claimToDelete);

            await Task.Run(() => _userRepository.Update(user));
        }

        #endregion


        //
        // Role Management
        //


        #region Roles

        public Task AddToRoleAsync(User user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (string.IsNullOrEmpty(roleName))
                throw new ArgumentException("Argument cannot be null or empty: roleName.");

            var role = _userRoleRepository.Table.FirstOrDefault(x => x.Name == roleName);
            if (role != null)
            {
                user.UserRoles.Add(role);
                _userRepository.Update(user);
            }

            return Task.FromResult<object>(null);
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (string.IsNullOrEmpty(roleName))
                throw new ArgumentException("Argument cannot be null or empty: roleName.");

            var role = _userRoleRepository.Table.FirstOrDefault(x => x.Name == roleName);
            if (role != null)
            {
                user.UserRoles.Remove(role);
                _userRepository.Update(user);
            }

            return Task.FromResult<object>(null);

        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            var roles = new List<string>();
            user.UserRoles.ToList().ForEach(x => roles.Add(x.Name));
            return Task.FromResult<IList<string>>(roles);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("role");
            }

            var roles = new List<string>();
            user.UserRoles.ToList().ForEach(x => roles.Add(x.Name));

            if (roles.Any() && roles.Contains(roleName))
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        #endregion
    }
}
