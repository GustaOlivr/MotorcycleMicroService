using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    public interface ICreateMotorcycleUseCase
    {
        Task<CreateMotorcycleResponse> ExecuteAsync(CreateMotorcycleRequest dto);
    }
}
