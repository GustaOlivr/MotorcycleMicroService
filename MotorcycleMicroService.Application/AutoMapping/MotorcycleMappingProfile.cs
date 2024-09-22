using AutoMapper;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Domain.Entities;

namespace MotorcycleMicroService.Application.AutoMapping
{
    public class MotorcycleMappingProfile : Profile
    {
        public MotorcycleMappingProfile()
        {
            //RequestDTO to Motorcycle Auto Mapping
            CreateMap<CreateMotorcycleRequest, Motorcycle>();
            CreateMap<UpdateMotorcycleRequest, Motorcycle>();
            CreateMap<LinkMotorcycleToCustomerRequest, Motorcycle>();


            //Motorcycle to ResponseDTO Auto Mapping
            CreateMap<Motorcycle, CreateMotorcycleResponse>();
            CreateMap<Motorcycle, GetMotorcycleByIdResponse>();
            CreateMap<Motorcycle, UpdateMotorcycleResponse>();

            // Motorcycle to MotorcycleDto (for use in paginated responses)
            CreateMap<Motorcycle, MotorcycleDto>();

            // Optional: Mapping for paginated responses if needed
            CreateMap<List<Motorcycle>, GetAllMotorcyclesResponse>()
                .ForMember(dest => dest.Motorcycles, opt => opt.MapFrom(src => src)); // Maps List<Motorcycle> to List<MotorcycleDto>

            CreateMap<Motorcycle, LinkMotorcycleToCustomerResponse>();

        }
    }
}
