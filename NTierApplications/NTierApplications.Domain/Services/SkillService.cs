using System;
using System.Collections.Generic;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
	public class SkillService : ISkillService
	{
		private readonly IRepository<Skill> _skillRepository;

		public SkillService(IRepository<Skill> skillRepository)
		{
			_skillRepository = skillRepository;
		}


		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Add(Skill entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			_skillRepository.Insert(entity);
		}

		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Update(Skill entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			_skillRepository.Update(entity);
		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		public void Delete(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			_skillRepository.Delete(id);
		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		public Skill GetById(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			return _skillRepository.GetById(id);
		}

		public IEnumerable<Skill> GetAll()
		{
			return _skillRepository.Table;
		}
	}
}