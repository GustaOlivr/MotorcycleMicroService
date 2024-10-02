using Microsoft.Extensions.Logging;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.Services
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger) : base(customerRepository, logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Customer> GetCustomerByCpf(string cpf)
        {
            return await _customerRepository.GetCustomerByCpfAsync(cpf);
        }

    }
}
