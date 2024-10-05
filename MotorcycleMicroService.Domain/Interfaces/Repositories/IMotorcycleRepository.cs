using MotorcycleMicroService.Domain.Entities;

namespace MotorcycleMicroService.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Defines a repository interface for performing CRUD operations on motorcycles.
    /// Inherits from the generic repository interface.
    /// </summary>
    public interface IMotorcycleRepository : IGenericRepository<Motorcycle>
    {
    }
}
