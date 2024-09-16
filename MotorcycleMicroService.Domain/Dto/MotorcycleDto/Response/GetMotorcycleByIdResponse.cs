namespace MotorcycleMicroService.Domain.Dto.MotorcycleDto.Response
{
    public class GetMotorcycleByIdResponse
    {
        public Guid MotorcycleId { get; set; }
        public string Name { get; set; }
        public string YearManufacture { get; set; }
        public string Manufacturer { get; set; }
    }
}
