using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierApplications.Data.Context;
using NTierApplications.Domain.Entities;
using NTierApplications.Domain.Repositories;

namespace NTierApplications.Data.Repositories
{
	public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
	{
		protected readonly NTierApplicationsDataContext _dbContext;
		protected readonly DbSet<TEntity> _dbSet;

		public EfRepository(NTierApplicationsDataContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<TEntity>();
		}

		/// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Insert(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			try
			{
				_dbSet.Add(entity);
				_dbContext.SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{
				ThrowValidationError(ex);
			}
		}

		/// <exception cref="DbUpdateConcurrencyException">
		///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
		///             concurrency violation; that is, a row has been changed in the database since it was queried.
		///             </exception>
		/// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
		public void Update(TEntity entity)
		{
			try
			{
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
			{
				ThrowValidationError(ex);
			}
		}

		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null" />.</exception>
		/// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
		/// <exception cref="DbUpdateConcurrencyException">
		///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
		///             concurrency violation; that is, a row has been changed in the database since it was queried.
		///             </exception>
		public void Delete(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			try
			{
				var entity = _dbSet.Find(id);
				_dbContext.Entry(entity).State = EntityState.Deleted;
				_dbContext.SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{
				ThrowValidationError(ex);
			}
		}

		public IEnumerable<TEntity> Table
		{
			get { return _dbSet; }
		}

		public TEntity GetById(int id)
		{
			return _dbSet.Find(id);
		}

		#region Helper Methods
		public Exception ThrowValidationError(DbEntityValidationException ex)
		{
			var msg = String.Empty;

			foreach (var validationErrors in ex.EntityValidationErrors)
			{
				foreach (var validationError in validationErrors.ValidationErrors)
				{
					msg += String.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
				}
			}

			throw new Exception(msg, ex);
		}
		#endregion

	}
}
