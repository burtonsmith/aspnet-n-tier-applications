using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IRepository<Department> _departmentRepository;

		public DepartmentService(IRepository<Department> departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Add(Department entity)
		{
			if(entity == null)
				throw new ArgumentNullException("entity");

			_departmentRepository.Insert(entity);
		}

		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Update(Department entity)
		{
			_departmentRepository.Update(entity);
		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		public void Delete(int id)
		{
			if(id == 0)
				throw new ArgumentNullException("id");

			_departmentRepository.Delete(id);
		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		public Department GetById(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			return _departmentRepository.GetById(id);
		}

		public IEnumerable<Department> GetAll()
		{
			return _departmentRepository.Table;
		}
	}
}
