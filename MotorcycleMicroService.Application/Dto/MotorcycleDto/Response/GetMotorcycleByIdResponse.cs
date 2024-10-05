using MotorcycleMicroService.Domain.Entities.Enumerations;

namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Response
{
    /// <summary>
    /// DTO for retrieving a single motorcycle by its unique identifier.
    /// </summary>
    public class GetMotorcycleByIdResponse
    {
        /// <summary>
        /// The unique identifier of the motorcycle.
        /// </summary>
        public Guid MotorcycleId { get; set; }

        /// <summary>
        /// The name of the motorcycle.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the motorcycle (e.g., Cruiser, Sport, etc.).
        /// </summary>
        public MotorcycleType Type { get; set; }

        /// <summary>
        /// The license plate of the motorcycle.
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// The year the motorcycle was manufactured.
        /// </summary>
        public int YearManufacture { get; set; }
    }
}
