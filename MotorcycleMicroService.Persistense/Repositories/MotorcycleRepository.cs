using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Persistense.Context;

namespace MotorcycleMicroService.Persistense.Repositories
{
    public class MotorcycleRepository : GenericRepository<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
