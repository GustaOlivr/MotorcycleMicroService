using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace MotorcycleMicroService.Application.UseCases
{
    public class CreateMotorcycleUseCase : ICreateMotorcycleUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateMotorcycleUseCase> _logger;

        public CreateMotorcycleUseCase(IMotorcycleService motorcycleService, IMapper mapper, ILogger <CreateMotorcycleUseCase> logger)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateMotorcycleResponse> ExecuteAsync(CreateMotorcycleRequest dto)
        {
            Motorcycle motorcycle = _mapper.Map<Motorcycle>(dto);
            _logger.LogDebug("Create Motorcycle initiated");
            Motorcycle motorcycleCreated = await _motorcycleService.CreateAsync(motorcycle);
            _logger.LogDebug("Converting Motorcycle in response");
            CreateMotorcycleResponse response = _mapper.Map<CreateMotorcycleResponse>(motorcycleCreated);
            return response;
        }
    }
}
