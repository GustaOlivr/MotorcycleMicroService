namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Response
{
    public class CreateMotorcycleResponse
    {
        public Guid MotorcycleId { get; set; }
        public string Name { get; set; }
        public string YearManufacture { get; set; }
        public string Manufacturer { get; set; }
    }
}
