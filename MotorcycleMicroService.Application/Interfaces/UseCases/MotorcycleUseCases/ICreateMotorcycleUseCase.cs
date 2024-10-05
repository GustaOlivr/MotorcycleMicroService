using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    /// <summary>
    /// Defines the use case for creating a new motorcycle.
    /// </summary>
    public interface ICreateMotorcycleUseCase
    {
        /// <summary>
        /// Asynchronously executes the process of creating a new motorcycle.
        /// </summary>
        /// <param name="dto">The request data transfer object (DTO) containing motorcycle information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response DTO for the created motorcycle.</returns>
        Task<CreateMotorcycleResponse> ExecuteAsync(CreateMotorcycleRequest dto);
    }
}
