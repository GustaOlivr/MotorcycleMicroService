using MotorcycleMicroService.Domain.Entities.Enumerations;

namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Response
{
    public class GetMotorcycleByIdResponse
    {
        public Guid MotorcycleId { get; set; }
        public string Name { get; set; }
        public MotorcycleType Type { get; set; }

        public string Plate { get; set; }

        public int YearManufacture { get; set; }
    }
}
