using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    public class UpdateMotorcycleUseCase : IUpdateMotorcycleUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;

        public UpdateMotorcycleUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }
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
