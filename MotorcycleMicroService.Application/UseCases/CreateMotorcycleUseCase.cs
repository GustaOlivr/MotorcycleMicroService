using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    public class CreateMotorcycleUseCase : ICreateMotorcycleUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;

        public CreateMotorcycleUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }

        public async Task<CreateMotorcycleResponse> ExecuteAsync(CreateMotorcycleRequest dto)
        {
            Motorcycle motorcycle = _mapper.Map<Motorcycle>(dto);
            Motorcycle motorcycleCreated = await _motorcycleService.CreateAsync(motorcycle);
            CreateMotorcycleResponse response = _mapper.Map<CreateMotorcycleResponse>(motorcycleCreated);
            return response;
        }
    }
}
