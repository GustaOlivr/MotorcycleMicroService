using MotorcycleMicroService.Application.Dto.CustomerDto.Requests;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases
{
    public interface ICreateCustomerUseCase
    {
        Task<CreateCustomerResponse> ExecuteAsync(CreateCustomerRequest dto);

    }
}
