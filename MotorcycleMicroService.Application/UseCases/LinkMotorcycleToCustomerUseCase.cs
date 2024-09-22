using AutoMapper;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;

namespace MotorcycleMicroService.Application.UseCases
{
    public class LinkMotorcycleToCustomerUseCase : ILinkMotorcycleToCustomerUseCase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public LinkMotorcycleToCustomerUseCase(IMotorcycleService motorcycleService,ICustomerService customerService, IMapper mapper)
        {
            _motorcycleService = motorcycleService;
            _customerService = customerService;
            _mapper = mapper;
        }
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
