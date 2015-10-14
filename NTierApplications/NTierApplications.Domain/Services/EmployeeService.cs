using System;
using System.Collections.Generic;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;
using NTierApplications.Domain.ServiceInterfaces;

namespace NTierApplications.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

	    /// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
	    public void Add(Employee entity)
	    {
		    if(entity == null)
			    throw new ArgumentNullException("entity");

		    _employeeRepository.Insert(entity);
	    }

	    /// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
	    public void Update(Employee entity)
	    {
			_employeeRepository.Update(entity);
	    }

	    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
	    public void Delete(int id)
	    {
		    if(id == 0)
			    throw new ArgumentNullException("id");

			_employeeRepository.Delete(id);
	    }

	    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
	    public Employee GetById(int id)
	    {
		    if(id == 0)
			    throw new ArgumentNullException("id");

		    return _employeeRepository.GetById(id);
	    }

	    public IEnumerable<Employee> GetAll()
	    {
		    return _employeeRepository.Table;
	    }
    }
}