using MotorcycleMicroService.Domain.Entities.Enumerations;

namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Response
{
    public class UpdateMotorcycleResponse
    {
        public Guid MotorcycleId { get; set; }
        public string Name { get; set; }
        public string YearManufacture { get; set; }
        public string Plate { get; set; }

        public MotorcycleType Type {  get; set; }
    }
}
