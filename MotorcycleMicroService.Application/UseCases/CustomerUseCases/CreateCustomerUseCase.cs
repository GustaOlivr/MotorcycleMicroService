using AutoMapper;
using MotorcycleMicroService.Application.Dto.CustomerDto.Requests;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;
using MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases.CustomerUseCases
{
    /// <summary>
    /// Use case to handle the creation of a new customer.
    /// </summary>
    public class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="customerService">Service to manage customer operations.</param>
        /// <param name="mapper">Mapper for DTO to entity conversion.</param>
        public CreateCustomerUseCase(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the creation of a new customer.
        /// </summary>
        /// <param name="dto">The request DTO containing the customer information.</param>
        /// <returns>A response DTO with the details of the created customer.</returns>
        public async Task<CreateCustomerResponse> ExecuteAsync(CreateCustomerRequest dto)
        {
            Customer customer = _mapper.Map<Customer>(dto);
            Customer customerCreated = await _customerService.CreateAsync(customer);
            CreateCustomerResponse response = _mapper.Map<CreateCustomerResponse>(customerCreated);
            return response;
        }
    }
}
