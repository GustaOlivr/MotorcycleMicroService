using AutoMapper;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    /// <summary>
    /// Use case to handle the retrieval of all motorcycles.
    /// </summary>
    public class GetAllMotorcyclesUseCase : IGetAllMotorcyclesUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="motorcycleService">Service to manage motorcycle operations.</param>
        /// <param name="mapper">Mapper for entity to DTO conversion.</param>
        public GetAllMotorcyclesUseCase(IMotorcycleService motorcycleService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the retrieval of all motorcycles with optional filtering.
        /// </summary>
        /// <param name="request">The request DTO containing filtering information.</param>
        /// <returns>A response DTO with the list of motorcycles and pagination details.</returns>
        public async Task<GetAllMotorcyclesResponse> ExecuteAsync(GetAllMotorcyclesRequest request)
        {
            IList<Motorcycle> motorcycles = await _motorcycleService.GetAllAsync(
                filter: m => (string.IsNullOrEmpty(request.Name) || m.Name.Contains(request.Name)) &&
                             (string.IsNullOrEmpty(request.Plate) || m.Plate.Contains(request.Plate)),
                skip: (request.PageIndex - 1) * request.PageSize,
                take: request.PageSize
            );
            GetAllMotorcyclesResponse response = _mapper.Map<GetAllMotorcyclesResponse>(motorcycles);
            response.TotalCount = motorcycles.Count;
            return response;
        }
    }
}
