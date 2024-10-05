using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    /// <summary>
    /// Defines the use case for updating an existing motorcycle.
    /// </summary>
    public interface IUpdateMotorcycleUseCase
    {
        /// <summary>
        /// Asynchronously executes the process of updating an existing motorcycle.
        /// </summary>
        /// <param name="motorcycleId">The unique identifier of the motorcycle to update.</param>
        /// <param name="dto">The request DTO containing updated motorcycle information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response DTO for the updated motorcycle.</returns>
        Task<UpdateMotorcycleResponse> ExecuteAsync(Guid motorcycleId, UpdateMotorcycleRequest dto);
    }
}
