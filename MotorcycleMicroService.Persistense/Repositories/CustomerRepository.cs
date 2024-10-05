using Microsoft.EntityFrameworkCore;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Persistense.Context;

namespace MotorcycleMicroService.Persistense.Repositories
{
    /// <summary>
    /// Repository specific for the <see cref="Customer"/> entity.
    /// </summary>
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CustomerRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        /// <summary>
        /// Retrieves a customer by their CPF.
        /// </summary>
        /// <param name="cpf">The CPF of the customer to retrieve.</param>
        /// <returns>The customer corresponding to the provided CPF.</returns>
        public async Task<Customer> GetCustomerByCpfAsync(string cpf)
        {
            return await _context.Set<Customer>().FirstOrDefaultAsync(customer => customer.Cpf == cpf);
        }
    }
}
