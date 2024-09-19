using AutoMapper;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    public class GetAllMotorcyclesUseCase : IGetAllMotorcyclesUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;

        public GetAllMotorcyclesUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }

        public async Task<GetAllMotorcyclesResponse> ExecuteAsync(GetAllMotorcyclesRequest request)
        {
            // Aplicar filtros e paginação
            var motorcycles = await _motorcycleService.GetAllAsync(
                filter: m => (string.IsNullOrEmpty(request.Name) || m.Name.Contains(request.Name)) &&
                             (string.IsNullOrEmpty(request.Manufacturer) || m.Manufacturer.Contains(request.Manufacturer)),
                skip: (request.PageIndex - 1) * request.PageSize,
                take: request.PageSize
            );

            return _mapper.Map<GetAllMotorcyclesResponse>(motorcycles);
        }
    }
}
