using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace MotorcycleMicroService.Application.UseCases
{
    /// <summary>
    /// Use case to handle the creation of a new motorcycle.
    /// </summary>
    public class CreateMotorcycleUseCase : ICreateMotorcycleUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateMotorcycleUseCase> _logger;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="motorcycleService">Service to manage motorcycle operations.</param>
        /// <param name="mapper">Mapper for DTO to entity conversion.</param>
        /// <param name="logger">Logger for logging information.</param>
        public CreateMotorcycleUseCase(IMotorcycleService motorcycleService, IMapper mapper, ILogger<CreateMotorcycleUseCase> logger)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Executes the creation of a new motorcycle.
        /// </summary>
        /// <param name="dto">The request DTO containing motorcycle information.</param>
        /// <returns>A response DTO with the details of the created motorcycle.</returns>
        public async Task<CreateMotorcycleResponse> ExecuteAsync(CreateMotorcycleRequest dto)
        {
            Motorcycle motorcycle = _mapper.Map<Motorcycle>(dto);
            _logger.LogInformation("Create Motorcycle initiated");
            Motorcycle motorcycleCreated = await _motorcycleService.CreateAsync(motorcycle);
            _logger.LogInformation("Converting Motorcycle in response");
            CreateMotorcycleResponse response = _mapper.Map<CreateMotorcycleResponse>(motorcycleCreated);
            return response;
        }
    }
}
