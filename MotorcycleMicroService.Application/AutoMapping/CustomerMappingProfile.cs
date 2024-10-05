using AutoMapper;
using MotorcycleMicroService.Application.Dto.CustomerDto.Requests;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;
using MotorcycleMicroService.Domain.Entities;

namespace MotorcycleMicroService.Application.AutoMapping
{
    /// <summary>
    /// AutoMapper Profile for Customer entity mappings.
    /// </summary>
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            // Map CreateCustomerRequest to Customer
            CreateMap<CreateCustomerRequest, Customer>();

            // Map Customer to CreateCustomerResponse
            CreateMap<Customer, CreateCustomerResponse>();
            CreateMap<Customer, GetCustomerByIdResponse>();
        }
    }
}
