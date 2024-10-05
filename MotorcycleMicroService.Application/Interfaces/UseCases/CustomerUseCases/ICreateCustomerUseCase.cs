using MotorcycleMicroService.Application.Dto.CustomerDto.Requests;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases
{
    /// <summary>
    /// Defines the use case for creating a new customer.
    /// </summary>
    public interface ICreateCustomerUseCase
    {
        /// <summary>
        /// Asynchronously executes the process of creating a new customer.
        /// </summary>
        /// <param name="dto">The request data transfer object (DTO) containing customer information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response DTO for the created customer.</returns>
        Task<CreateCustomerResponse> ExecuteAsync(CreateCustomerRequest dto);
    }
}
