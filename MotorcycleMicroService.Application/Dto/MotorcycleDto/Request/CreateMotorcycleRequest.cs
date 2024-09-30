using MotorcycleMicroService.Domain.Entities.Enumerations;

namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Request
{
    public class CreateMotorcycleRequest
    {
        public string Name { get; set; }

        public MotorcycleType Type { get; set; }

        public string Plate { get; set; }

        public int YearManufacture { get; set; }
    }
}
