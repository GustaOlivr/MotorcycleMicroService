using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace MotorcycleMicroService.Application.Services
{
    public class MotorcycleService : GenericService<Motorcycle>, IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly ILogger<MotorcycleService> _logger;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository, ILogger<MotorcycleService> logger)
            : base(motorcycleRepository, logger) 
        {
            _motorcycleRepository = motorcycleRepository;
            _logger = logger;
        }
    }
}
