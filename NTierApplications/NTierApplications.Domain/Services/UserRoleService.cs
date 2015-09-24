using System;
using System.Linq;
using System.Threading.Tasks;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
	public class UserRoleService : IUserRoleService
	{
		private readonly IRepository<UserRole> _userRoleRepository;

		public UserRoleService(IRepository<UserRole> userRoleRepository)
		{
			_userRoleRepository = userRoleRepository;
		} 

		public async Task CreateAsync(UserRole role)
		{
			if(role == null)
				throw new ArgumentNullException("role");

			await Task.Run(() => _userRoleRepository.Insert(role));
		}

		public async Task DeleteAsync(UserRole role)
		{
			if(role == null)
				throw new ArgumentNullException("role");

			await Task.Run((() => _userRoleRepository.Delete(role.Id)));
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public async Task<UserRole> FindByIdAsync(int roleId)
		{
			if(roleId == 0)
				throw new ArgumentNullException("roleId");

			return await Task.FromResult(_userRoleRepository.GetById(roleId));
		}

		public async Task<UserRole> FindByNameAsync(string roleName)
		{
			if(roleName == null)
				throw new ArgumentNullException("roleName");

			return await Task.FromResult(_userRoleRepository.Table.FirstOrDefault(x => x.Name == roleName));
		}

		public async Task UpdateAsync(UserRole role)
		{
			if(role == null)
				throw new ArgumentNullException("role");

			await Task.Run((() => _userRoleRepository.Update(role)));
		}
	}
}
