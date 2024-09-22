using MotorcycleMicroService.Domain.Entities.Enumerations;

namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Request
{
    public class LinkMotorcycleToCustomerRequest
    {
        public Guid MotorcycleId { get; set; }

        public string CustomerCpf { get; set; }
    }
}
