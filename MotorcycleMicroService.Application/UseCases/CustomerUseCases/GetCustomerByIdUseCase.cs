using AutoMapper;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;
using MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases.CustomerUseCases
{
    public class GetCustomerByIdUseCase : IGetCustomerByIdUseCase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public GetCustomerByIdUseCase(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdResponse> ExecuteAsync(Guid customerId)
        {
            Customer customer = await _customerService.GetByIdAsync(customerId);
            GetCustomerByIdResponse response = _mapper.Map<GetCustomerByIdResponse>(customer);
            return response;
        }
    }
}
