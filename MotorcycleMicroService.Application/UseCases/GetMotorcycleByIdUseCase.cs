using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    /// <summary>
    /// Use case to handle the retrieval of a motorcycle by its ID.
    /// </summary>
    public class GetMotorcycleByIdUseCase : IGetMotorcycleByIdUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="motorcycleService">Service to manage motorcycle operations.</param>
        /// <param name="mapper">Mapper for entity to DTO conversion.</param>
        public GetMotorcycleByIdUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the retrieval of a motorcycle by its ID.
        /// </summary>
        /// <param name="id">The unique ID of the motorcycle to retrieve.</param>
        /// <returns>A response DTO with the details of the motorcycle.</returns>
        public async Task<GetMotorcycleByIdResponse> ExecuteAsync(Guid id)
        {
            Motorcycle motorcycle = await _motorcycleService.GetByIdAsync(id);
            GetMotorcycleByIdResponse response = _mapper.Map<GetMotorcycleByIdResponse>(motorcycle);
            return response;
        }
    }
}
