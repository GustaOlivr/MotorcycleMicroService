using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    public class DeleteMotorcycleUseCase : IDeleteMotorcycleUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;

        public DeleteMotorcycleUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }

        public async Task<bool> ExecuteAsync(Guid motorcycleId)
        {
            bool motorcycleDeleted = await _motorcycleService.DeleteAsync(motorcycleId);
            return motorcycleDeleted;
        }
    }
}
