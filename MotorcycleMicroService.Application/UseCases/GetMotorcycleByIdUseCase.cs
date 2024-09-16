using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    public class GetMotorcycleByIdUseCase : IGetMotorcycleByIdUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;


        public GetMotorcycleByIdUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }

        public async Task<GetMotorcycleByIdResponse> ExecuteAsync(Guid id)
        {
            Motorcycle motorcycle = await _motorcycleService.GetByIdAsync(id);
            GetMotorcycleByIdResponse response = _mapper.Map<GetMotorcycleByIdResponse>(motorcycle);
            return response;
        }
    }
}
