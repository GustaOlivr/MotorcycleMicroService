using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    /// <summary>
    /// Use case to handle linking a motorcycle to a customer.
    /// </summary>
    public class LinkMotorcycleToCustomerUseCase : ILinkMotorcycleToCustomerUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="motorcycleService">Service to manage motorcycle operations.</param>
        /// <param name="customerService">Service to manage customer operations.</param>
        /// <param name="mapper">Mapper for DTO to entity conversion.</param>
        public LinkMotorcycleToCustomerUseCase(IMotorcycleService motorcycleService, ICustomerService customerService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the linking of a motorcycle to a customer.
        /// </summary>
        /// <param name="dto">The request DTO containing motorcycle and customer information.</param>
        /// <returns>A response DTO with the details of the updated motorcycle.</returns>
        public async Task<LinkMotorcycleToCustomerResponse> ExecuteAsync(LinkMotorcycleToCustomerRequest dto)
        {
            Customer existentCustomer = await _customerService.GetCustomerByCpf(dto.CustomerCpf);
            Motorcycle motorcycleExistent = await _motorcycleService.GetByIdAsync(dto.MotorcycleId);
            motorcycleExistent.CustomerId = existentCustomer.CustomerId;
            Motorcycle updatedMotorcycle = await _motorcycleService.UpdateAsync(motorcycleExistent);
            LinkMotorcycleToCustomerResponse response = _mapper.Map<LinkMotorcycleToCustomerResponse>(updatedMotorcycle);
            return response;
        }
    }
}
