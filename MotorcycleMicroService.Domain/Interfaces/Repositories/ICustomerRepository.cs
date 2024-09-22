using MotorcycleMicroService.Domain.Entities;

namespace MotorcycleMicroService.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerByCpfAsync(string cpf);
    }
}
