using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases
{
    /// <summary>
    /// Defines the use case for retrieving a customer by its ID.
    /// </summary>
    public interface IGetCustomerByIdUseCase
    {
        /// <summary>
        /// Asynchronously executes the process of retrieving a customer by their unique identifier.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response DTO for the retrieved customer.</returns>
        Task<GetCustomerByIdResponse> ExecuteAsync(Guid customerId);
    }
}
