using System.Linq.Expressions;

namespace MotorcycleMicroService.Domain.Interfaces.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid entityId);
        Task<List<T>> GetAllAsync(
             Expression<Func<T, bool>> filter = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             int? skip = null,
             int? take = null);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T updatedEntity);
        Task<bool> DeleteAsync(Guid entityId);
    }
}
