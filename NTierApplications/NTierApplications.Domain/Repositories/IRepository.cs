using System.Collections.Generic;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        IEnumerable<TEntity> Table { get; }
        TEntity GetById(int id);
    }
}