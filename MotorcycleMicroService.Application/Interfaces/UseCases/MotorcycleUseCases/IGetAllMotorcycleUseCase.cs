using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    /// <summary>
    /// Defines the use case for retrieving all motorcycles.
    /// </summary>
    public interface IGetAllMotorcyclesUseCase
    {
        /// <summary>
        /// Asynchronously executes the process of retrieving all motorcycles based on filtering options.
        /// </summary>
        /// <param name="dto">The request DTO containing filtering and pagination options.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response DTO for the list of motorcycles.</returns>
        Task<GetAllMotorcyclesResponse> ExecuteAsync(GetAllMotorcyclesRequest dto);
    }
}
