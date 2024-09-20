using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.Services
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
