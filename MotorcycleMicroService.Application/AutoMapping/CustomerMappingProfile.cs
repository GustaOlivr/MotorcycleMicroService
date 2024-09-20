using AutoMapper;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;

namespace MotorcycleMicroService.Application.AutoMapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            //RequestDTO to Motorcycle Auto Mapping
            //CreateMap<CreateCustomerRequest, Customer>();
            //CreateMap<UpdateCustomerRequest, Customer>();


            ////Motorcycle to ResponseDTO Auto Mapping
            //CreateMap<Customer, CreateCustomerResponse>();
            //CreateMap<Customer, GetCustomerByIdResponse>();
            //CreateMap<Customer, UpdateCustomerResponse>();

            //// Motorcycle to MotorcycleDto (for use in paginated responses)
            //CreateMap<Customer, CustomerDto>();

            //// Optional: Mapping for paginated responses if needed
            //CreateMap<List<Customer>, GetAllCustomersResponse>()
            //    .ForMember(dest => dest.Motorcycles, opt => opt.MapFrom(src => src)); // Maps List<Motorcycle> to List<MotorcycleDto>
        }
    }
}
