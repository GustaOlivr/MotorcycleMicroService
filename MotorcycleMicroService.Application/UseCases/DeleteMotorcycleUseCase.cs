using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    /// <summary>
    /// Use case to handle the deletion of a motorcycle.
    /// </summary>
    public class DeleteMotorcycleUseCase : IDeleteMotorcycleUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="motorcycleService">Service to manage motorcycle operations.</param>
        /// <param name="mapper">Mapper for entity to DTO conversion.</param>
        public DeleteMotorcycleUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the deletion of a motorcycle by its ID.
        /// </summary>
        /// <param name="motorcycleId">The unique ID of the motorcycle to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        public async Task<bool> ExecuteAsync(Guid motorcycleId)
        {
            bool motorcycleDeleted = await _motorcycleService.DeleteAsync(motorcycleId);
            return motorcycleDeleted;
        }
    }
}
