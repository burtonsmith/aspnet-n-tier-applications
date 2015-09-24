using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
	public class UserClaimService : IUserClaimService
	{
		private readonly IRepository<UserClaim> _userClaimRepository;

		public UserClaimService(IRepository<UserClaim> userClaimRepository)
		{
			_userClaimRepository = userClaimRepository;
		}

		public async Task CreateAsync(UserClaim claim)
		{
			await Task.Run(() => _userClaimRepository.Insert(claim));
		}

		public async Task UpdateAsync(UserClaim claim)
		{
			if(claim == null)
				throw new NullReferenceException("claim");

			await Task.Run(() => _userClaimRepository.Update(claim));
		}

		public async Task DeleteAsync(int id)
		{
			if (id == 0)
				throw new NullReferenceException("id");

			await Task.Run(() => _userClaimRepository.Delete(id));
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Task<UserClaim> FindByIdAsync(int claimId)
		{
			if(claimId == 0)
				throw new ArgumentNullException("claimId");

			var claim = _userClaimRepository.Table.FirstOrDefault(x=>x.Id == claimId);
			return Task.FromResult(claim);
		}

		public Task<IEnumerable<UserClaim>> GetAllAsync()
		{
			return Task.FromResult(_userClaimRepository.Table);
		}

		public Task<UserRole> FindByNameAsync(string claimName)
		{
			throw new NotImplementedException();
		}
	}
}
