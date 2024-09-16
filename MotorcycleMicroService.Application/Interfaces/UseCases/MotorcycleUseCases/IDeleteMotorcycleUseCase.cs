namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    public interface IDeleteMotorcycleUseCase
    {
        Task<bool> ExecuteAsync(Guid MotorcycleId);
    }
}
