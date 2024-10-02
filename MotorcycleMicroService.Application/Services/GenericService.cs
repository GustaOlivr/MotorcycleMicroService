using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace MotorcycleMicroService.Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        private readonly ILogger<GenericService<T>> _logger;

        public GenericService(IGenericRepository<T> genericRepository, ILogger<GenericService<T>> logger)
        {
            _genericRepository = genericRepository;
            _logger = logger;
        }

        public async Task<T> GetByIdAsync(Guid entityId)
        {
            _logger.LogInformation("Attempting to retrieve entity of type {EntityType} with ID {EntityId}.", typeof(T).Name, entityId);

            var entity = await _genericRepository.GetByIdAsync(entityId);

            if (entity == null)
            {
                _logger.LogWarning("Entity of type {EntityType} with ID {EntityId} was not found.", typeof(T).Name, entityId);
            }
            else
            {
                _logger.LogInformation("Successfully retrieved entity of type {EntityType} with ID {EntityId}.", typeof(T).Name, entityId);
            }

            return entity;
        }

        public async Task<List<T>> GetAllAsync(
                   Expression<Func<T, bool>> filter = null,
                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                   int? skip = null,
                   int? take = null)
        {
            _logger.LogInformation("Retrieving all entities of type {EntityType} with filter {Filter}.", typeof(T).Name, filter);

            IQueryable<T> query = _genericRepository.GetAll();

            if (filter != null)
            {
                query = query.Where(filter);
                _logger.LogInformation("Applied filter to the query.");
            }

            if (orderBy != null)
            {
                query = orderBy(query);
                _logger.LogInformation("Applied ordering to the query.");
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
                _logger.LogInformation("Applied skip of {Skip} records to the query.", skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
                _logger.LogInformation("Applied take of {Take} records to the query.", take.Value);
            }

            var result = await query.ToListAsync();
            _logger.LogInformation("Successfully retrieved {Count} entities of type {EntityType}.", result.Count, typeof(T).Name);

            return result;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _logger.LogInformation("Creating a new entity of type {EntityType}.", typeof(T).Name);

            await _genericRepository.AddAsync(entity);

            _logger.LogInformation("Successfully created entity of type {EntityType}.", typeof(T).Name);

            return entity;
        }

        public async Task<T> UpdateAsync(T updatedEntity)
        {
            _logger.LogInformation("Updating entity of type {EntityType}.", typeof(T).Name);

            await _genericRepository.UpdateAsync(updatedEntity);

            _logger.LogInformation("Successfully updated entity of type {EntityType}.", typeof(T).Name);

            return updatedEntity;
        }

        public async Task<bool> DeleteAsync(Guid entityId)
        {
            _logger.LogInformation("Attempting to delete entity of type {EntityType} with ID {EntityId}.", typeof(T).Name, entityId);

            await _genericRepository.DeleteAsync(entityId);

            _logger.LogInformation("Successfully deleted entity of type {EntityType} with ID {EntityId}.", typeof(T).Name, entityId);

            return true;
        }
    }
}
