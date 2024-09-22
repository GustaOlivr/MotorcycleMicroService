using MotorcycleMicroService.Domain.Entities;

namespace MotorcycleMicroService.Domain.Interfaces.Services
{
    public interface ICustomerService : IGenericService<Customer>
    {
        Task<Customer> GetCustomerByCpf(string cpf);
    }
}
