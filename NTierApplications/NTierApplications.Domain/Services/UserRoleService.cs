using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
	public class UserRoleService : IUserRoleService
	{
		private readonly IRepository<UserRole> _userRoleRepository;
		bool _disposed;
		readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

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

		/// <summary>
		///     Use DeleteByIdAsync instead as this it will throw an exception when the new instance of the object is created in the Repository.
		/// </summary>
		public async Task DeleteAsync(UserRole role)
		{
            if (role == null)
                throw new ArgumentNullException("role");

            await Task.Run((() => _userRoleRepository.Delete(role.Id)));
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

		public async Task<UserRole> FindByIdAsync(int roleId)
		{
			if(roleId == 0)
				throw new ArgumentNullException("roleId", "You must add a roleId.");

			return await Task.FromResult(_userRoleRepository.GetById(roleId));
		}

		public async Task<UserRole> FindByNameAsync(string roleName)
		{
			if(roleName == null)
				throw new ArgumentNullException("roleName");

			return await Task.FromResult(_userRoleRepository.Table.FirstOrDefault(x => x.Name == roleName));
		}

		public IEnumerable<UserRole> GetAll()
		{
			return _userRoleRepository.Table;
		}

		public async Task UpdateAsync(UserRole role)
		{
			if(role == null)
				throw new ArgumentNullException("role");

			await Task.Run((() => _userRoleRepository.Update(role)));
		}

		public IQueryable<UserRole> Roles
		{
			get { return _userRoleRepository.Table.AsQueryable(); }
		}

		public async Task DeleteByIdAsync(int id)
		{
			if (id == default(int))
				throw new ArgumentNullException("id");

			await Task.Run((() => _userRoleRepository.Delete(id)));
		}
	}
}
