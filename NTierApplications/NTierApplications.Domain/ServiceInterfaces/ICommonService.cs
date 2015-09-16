using System.Collections.Generic;

namespace NTierApplications.Domain.ServiceInterfaces
{
    public interface ICommonService<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}