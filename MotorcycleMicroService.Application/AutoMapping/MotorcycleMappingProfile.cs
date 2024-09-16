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


            //Motorcycle to ResponseDTO Auto Mapping
            CreateMap<Motorcycle, CreateMotorcycleResponse>();
            CreateMap<Motorcycle, GetMotorcycleByIdResponse>();
            CreateMap<Motorcycle, UpdateMotorcycleResponse>();
        }
    }
}
