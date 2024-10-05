using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    /// <summary>
    /// Use case to handle the update of an existing motorcycle.
    /// </summary>
    public class UpdateMotorcycleUseCase : IUpdateMotorcycleUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="motorcycleService">Service to manage motorcycle operations.</param>
        /// <param name="mapper">Mapper for DTO to entity conversion.</param>
        public UpdateMotorcycleUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the update of a motorcycle by its ID.
        /// </summary>
        /// <param name="motorcycleId">The unique ID of the motorcycle to update.</param>
        /// <param name="dto">The request DTO containing the updated information.</param>
        /// <returns>A response DTO with the details of the updated motorcycle.</returns>
        public async Task<UpdateMotorcycleResponse> ExecuteAsync(Guid motorcycleId, UpdateMotorcycleRequest dto)
        {
            Motorcycle motorcycle = await _motorcycleService.GetByIdAsync(motorcycleId);
            _mapper.Map(dto, motorcycle);
            Motorcycle updatedMotorcycle = await _motorcycleService.UpdateAsync(motorcycle);
            UpdateMotorcycleResponse response = _mapper.Map<UpdateMotorcycleResponse>(updatedMotorcycle);
            return response;
        }
    }
}
