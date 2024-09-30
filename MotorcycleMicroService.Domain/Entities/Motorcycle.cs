using MotorcycleMicroService.Domain.Entities.Enumerations;

namespace MotorcycleMicroService.Domain.Entities
{
    public sealed class Motorcycle : BaseEntity
    {
        public Guid MotorcycleId { get; set; }
        public string Name { get; set; }
        public MotorcycleType Type { get; set; }
        public string Plate { get; set; }

        public int YearManufacture { get; set; }
        
        public Guid? CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}
