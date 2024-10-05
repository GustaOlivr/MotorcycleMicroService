using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    /// <summary>
    /// Defines the use case for retrieving a motorcycle by its ID.
    /// </summary>
    public interface IGetMotorcycleByIdUseCase
    {
        /// <summary>
        /// Asynchronously executes the process of retrieving a motorcycle by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the motorcycle.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response DTO for the retrieved motorcycle.</returns>
        Task<GetMotorcycleByIdResponse> ExecuteAsync(Guid id);
    }
}
