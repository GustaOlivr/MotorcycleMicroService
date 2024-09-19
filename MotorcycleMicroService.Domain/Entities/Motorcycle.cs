namespace MotorcycleMicroService.Domain.Entities
{
    public class Motorcycle : BaseEntity
    {
        public Guid MotorcycleId { get; set; }
        public string Name { get; set; }
        public string YearManufacture { get; set; }
        public string Manufacturer { get; set; }
    }
}
