using AutoMapper;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;
using MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases.CustomerUseCases
{
    /// <summary>
    /// Use case to handle the retrieval of a customer by their ID.
    /// </summary>
    public class GetCustomerByIdUseCase : IGetCustomerByIdUseCase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="customerService">Service to manage customer operations.</param>
        /// <param name="mapper">Mapper for entity to DTO conversion.</param>
        public GetCustomerByIdUseCase(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the retrieval of a customer by their ID.
        /// </summary>
        /// <param name="customerId">The unique ID of the customer.</param>
        /// <returns>A response DTO with the details of the customer.</returns>
        public async Task<GetCustomerByIdResponse> ExecuteAsync(Guid customerId)
        {
            Customer customer = await _customerService.GetByIdAsync(customerId);
            GetCustomerByIdResponse response = _mapper.Map<GetCustomerByIdResponse>(customer);
            return response;
        }
    }
}
