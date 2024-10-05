using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Persistense.Context;

namespace MotorcycleMicroService.Persistense.Repositories
{
    /// <summary>
    /// Repository specific for the <see cref="Motorcycle"/> entity.
    /// </summary>
    public class MotorcycleRepository : GenericRepository<Motorcycle>, IMotorcycleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MotorcycleRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public MotorcycleRepository(AppDbContext context) : base(context)
        {
            // Add specific methods for Motorcycle here if needed
        }
    }
}
