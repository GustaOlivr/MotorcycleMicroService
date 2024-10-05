using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    /// <summary>
    /// Defines the use case for linking a motorcycle to a customer.
    /// </summary>
    public interface ILinkMotorcycleToCustomerUseCase
    {
        /// <summary>
        /// Asynchronously executes the process of linking a motorcycle to a customer.
        /// </summary>
        /// <param name="dto">The request data transfer object (DTO) containing the linking information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response DTO for the linked motorcycle and customer.</returns>
        Task<LinkMotorcycleToCustomerResponse> ExecuteAsync(LinkMotorcycleToCustomerRequest dto);
    }
}
