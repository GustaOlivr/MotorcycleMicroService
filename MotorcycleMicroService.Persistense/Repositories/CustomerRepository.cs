using Microsoft.EntityFrameworkCore;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Persistense.Context;

namespace MotorcycleMicroService.Persistense.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<Customer> GetCustomerByCpfAsync(string cpf)
        {
            return await _context.Set<Customer>().FirstOrDefaultAsync(customer => customer.Cpf == cpf);
        }
    }
}
