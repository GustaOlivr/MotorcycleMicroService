using AutoMapper;
using MotorcycleMicroService.Application.Dto.CustomerDto.Requests;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases;
using MotorcycleMicroService.Application.Services;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases.CustomerUseCases
{
    /// <summary>
    /// Use case to handle the creation of a new customer.
    /// </summary>
    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="customerService">Service to manage customer operations.</param>
        /// <param name="mapper">Mapper for DTO to entity conversion.</param>
        public UpdateCustomerUseCase(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the creation of a new customer.
        /// </summary>
        /// <param name="dto">The request DTO containing the customer information.</param>
        /// <returns>A response DTO with the details of the created customer.</returns>
        public async Task<UpdateCustomerResponse> ExecuteAsync(Guid customerId, UpdateCustomerRequest dto)
        {
            Customer customer = await _customerService.GetByIdAsync(customerId);
            _mapper.Map(dto, customer);
            Customer updatedCustomer = await _customerService.UpdateAsync(customer);
            UpdateCustomerResponse response = _mapper.Map<UpdateCustomerResponse>(updatedCustomer);
            return response;
        }
    }
}
