using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
	public class UserLoginService : IUserLoginService
	{
		private readonly IRepository<UserLogin> _userLoginRepository;

		public UserLoginService(IRepository<UserLogin> userLoginRepository)
		{
			_userLoginRepository = userLoginRepository;
		}

		public async Task CreateAsync(UserLogin entity)
		{
			await Task.Run(() => _userLoginRepository.Insert(entity));
		}

		public async Task UpdateAsync(UserLogin entity)
		{
			await Task.Run(() => _userLoginRepository.Update(entity));
		}

		public async Task DeleteAsync(int id)
		{
			var login = Task.FromResult(_userLoginRepository.Table.FirstOrDefault(x => x.Id == id));
			if (login == null)
				return;

			await Task.Run(() => _userLoginRepository.Delete(login.Id));
		}

		public Task<UserLogin> FindByNameAsync(string userName)
		{
			throw new NotImplementedException();
		}

		public async Task<UserLogin> FindByIdAsync(int id)
		{
			return await Task.FromResult(_userLoginRepository.Table.FirstOrDefault(x => x.Id == id));
		}

		public async Task<IEnumerable<UserLogin>> GetAllAsync()
		{
			return await Task.FromResult(_userLoginRepository.Table);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
