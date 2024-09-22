using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    public interface ILinkMotorcycleToCustomerUseCase
    {
        Task<LinkMotorcycleToCustomerResponse> ExecuteAsync(LinkMotorcycleToCustomerRequest dto);
    }
}
