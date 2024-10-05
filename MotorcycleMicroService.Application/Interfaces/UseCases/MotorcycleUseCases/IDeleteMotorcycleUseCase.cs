namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    /// <summary>
    /// Defines the use case for deleting a motorcycle.
    /// </summary>
    public interface IDeleteMotorcycleUseCase
    {
        /// <summary>
        /// Asynchronously executes the process of deleting a motorcycle by its unique identifier.
        /// </summary>
        /// <param name="motorcycleId">The unique identifier of the motorcycle to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the deletion was successful.</returns>
        Task<bool> ExecuteAsync(Guid motorcycleId);
    }
}
