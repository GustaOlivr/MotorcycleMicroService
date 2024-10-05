using MotorcycleMicroService.Domain.Entities;

namespace MotorcycleMicroService.Domain.Interfaces.Services
{
    /// <summary>
    /// Defines a service interface for performing CRUD operations and business logic related to motorcycles.
    /// Inherits from the generic service interface.
    /// </summary>
    public interface IMotorcycleService : IGenericService<Motorcycle>
    {
    }
}
