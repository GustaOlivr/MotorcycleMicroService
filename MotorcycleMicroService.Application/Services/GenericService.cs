using Microsoft.EntityFrameworkCore;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace MotorcycleMicroService.Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<T> GetByIdAsync(Guid entityId)
        {
            return await _genericRepository.GetByIdAsync(entityId);
        }

        public async Task<List<T>> GetAllAsync(
                   Expression<Func<T, bool>> filter = null,
                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                   int? skip = null,
                   int? take = null)
        {
            IQueryable<T> query = _genericRepository.GetAll();

            // Aplica o filtro se fornecido
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Aplica a ordenação se fornecida
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Aplica a paginação se fornecido
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync(); // Executa a consulta de forma assíncrona
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T updatedEntity)
        {
            await _genericRepository.UpdateAsync(updatedEntity);
            return updatedEntity;
        }

        public async Task<bool> DeleteAsync(Guid entityId)
        {
            await _genericRepository.DeleteAsync(entityId);
            return true;
        }
    }
}
