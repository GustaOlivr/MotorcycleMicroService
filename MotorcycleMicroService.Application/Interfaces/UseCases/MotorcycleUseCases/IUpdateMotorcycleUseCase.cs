using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    public interface IUpdateMotorcycleUseCase
    {
        Task<UpdateMotorcycleResponse> ExecuteAsync(Guid motorcycleId, UpdateMotorcycleRequest dto);
    }
}
