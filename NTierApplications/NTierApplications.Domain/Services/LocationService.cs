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
	public class LocationService : ILocationService
	{
		private readonly IRepository<Location> _locationRepository;

		public LocationService(IRepository<Location> locationRepository)
		{
			_locationRepository = locationRepository;
		}

		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Add(Location entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			_locationRepository.Insert(entity);
		}

		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Update(Location entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			_locationRepository.Update(entity);
		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		public void Delete(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			_locationRepository.Delete(id);

		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		public Location GetById(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			return _locationRepository.GetById(id);
		}

		public IEnumerable<Location> GetAll()
		{
			return _locationRepository.Table;
		}
	}
}
