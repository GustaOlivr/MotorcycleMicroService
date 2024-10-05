using AutoMapper;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;

namespace MotorcycleMicroService.Application.AutoMapping
{
    /// <summary>
    /// AutoMapper Profile for Motorcycle entity mappings.
    /// </summary>
    public class MotorcycleMappingProfile : Profile
    {
        public MotorcycleMappingProfile()
        {
            // Map CreateMotorcycleRequest to Motorcycle
            CreateMap<CreateMotorcycleRequest, Motorcycle>();
            // Map UpdateMotorcycleRequest to Motorcycle (for updates)
            CreateMap<UpdateMotorcycleRequest, Motorcycle>();
            // Map LinkMotorcycleToCustomerRequest to Motorcycle (for linking to a customer)
            CreateMap<LinkMotorcycleToCustomerRequest, Motorcycle>();

            // Map Motorcycle to CreateMotorcycleResponse
            CreateMap<Motorcycle, CreateMotorcycleResponse>();
            CreateMap<Motorcycle, GetMotorcycleByIdResponse>();
            CreateMap<Motorcycle, UpdateMotorcycleResponse>();
            CreateMap<Motorcycle, LinkMotorcycleToCustomerResponse>();

            // Map Motorcycle to MotorcycleDto (for use in paginated responses)
            CreateMap<Motorcycle, MotorcycleDto>();

            // Optional: Mapping for paginated responses if needed
            CreateMap<List<Motorcycle>, GetAllMotorcyclesResponse>()
                .ForMember(dest => dest.Motorcycles, opt => opt.MapFrom(src => src)); // Maps List<Motorcycle> to List<MotorcycleDto>
        }
    }
}
