namespace MotorcycleMicroService.Domain.Entities
{
    public sealed class Customer : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }

        public string Telephone { get; set; }

        public string Cpf { get; set; }

        public ICollection<Motorcycle> Motorcycles { get; set; }
    }
}
