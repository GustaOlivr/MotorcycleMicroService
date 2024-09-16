using MotorcycleMicroService.Domain.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Domain.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    public interface ICreateMotorcycleUseCase
    {
        Task<CreateMotorcycleResponse> ExecuteAsync(CreateMotorcycleRequest dto);
    }
}
