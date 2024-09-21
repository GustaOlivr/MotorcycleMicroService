using AutoMapper;
using MotorcycleMicroService.Application.Dto.CustomerDto.Requests;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;
using MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases.CustomerUseCases
{
    public class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CreateCustomerUseCase(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<CreateCustomerResponse> ExecuteAsync(CreateCustomerRequest dto)
        {
            Customer customer = _mapper.Map<Customer>(dto);
            Customer customerCreated = await _customerService.CreateAsync(customer);
            CreateCustomerResponse response = _mapper.Map<CreateCustomerResponse>(customerCreated);
            return response;
        }
    }
}
