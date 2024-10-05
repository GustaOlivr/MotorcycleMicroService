using MotorcycleMicroService.Domain.Entities.Enumerations;

namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Request
{
    /// <summary>
    /// DTO for updating an existing motorcycle's information.
    /// </summary>
    public class UpdateMotorcycleRequest
    {
        /// <summary>
        /// The name of the motorcycle.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of motorcycle (e.g., Cruiser, Sport, etc.).
        /// </summary>
        public MotorcycleType Type { get; set; }

        /// <summary>
        /// The year the motorcycle was manufactured.
        /// </summary>
        public int YearManufacture { get; set; }

        /// <summary>
        /// The license plate of the motorcycle.
        /// </summary>
        public string Plate { get; set; }
    }
}
