using System.Collections.Generic;
using System.Threading.Tasks;

namespace NTierApplications.Domain.ServiceInterfaces
{
	public interface ICommonServiceAsync<TEntity>
	{
		Task CreateAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task DeleteAsync(int id);
		Task<TEntity> FindByIdAsync(int id);
		Task<IEnumerable<TEntity>> GetAllAsync();
		void Dispose();
	}
}
