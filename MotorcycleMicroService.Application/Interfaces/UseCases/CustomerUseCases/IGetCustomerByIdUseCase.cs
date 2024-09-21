using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases
{
    public interface IGetCustomerByIdUseCase
    {
        Task<GetCustomerByIdResponse> ExecuteAsync(Guid customerId);
    }
}
