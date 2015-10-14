using System;
using System.Collections.Generic;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
	public class NamePrefixService : INamePrefixService
	{
		private readonly IRepository<NamePrefix> _namePrefixRepository;

		public NamePrefixService(IRepository<NamePrefix> namePrefixRepository)
		{
			_namePrefixRepository = namePrefixRepository;
		}

		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Add(NamePrefix entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			_namePrefixRepository.Insert(entity);
		}

		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Update(NamePrefix entity)
		{
			_namePrefixRepository.Update(entity);
		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		public void Delete(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			_namePrefixRepository.Delete(id);
		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		public NamePrefix GetById(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			return _namePrefixRepository.GetById(id);
		}

		public IEnumerable<NamePrefix> GetAll()
		{
			return _namePrefixRepository.Table;
		}
	}
}