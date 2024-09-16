namespace MotorcycleMicroService.Domain.Dto.MotorcycleDto.Request
{
    public class CreateMotorcycleRequest
    {
        public string Name { get; set; }
        public string YearManufacture { get; set; }
        public string Manufacturer { get; set; }
    }
}
