using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MotorcycleMicroService.Persistense.Mapping
{
    /// <summary>
    /// Provides configuration for the <see cref="Motorcycle"/> entity.
    /// Inherits from <see cref="BaseEntityConfiguration{Motorcycle}"/> to reuse common configurations.
    /// </summary>
    public sealed class MotorcycleConfiguration : BaseEntityConfiguration<Domain.Entities.Motorcycle>
    {
        /// <summary>
        /// Configures the <see cref="Motorcycle"/> entity.
        /// Defines primary key, properties, and other constraints.
        /// </summary>
        /// <param name="builder">A <see cref="EntityTypeBuilder{Motorcycle}"/> used to configure the <see cref="Motorcycle"/> entity.</param>
        public override void Configure(EntityTypeBuilder<Domain.Entities.Motorcycle> builder)
        {
            // Defines the primary key for the User entity.
            builder.HasKey(x => x.MotorcycleId);

            // Configures the Name property with a maximum length of 100 characters and marks it as required.
            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            // Configures the Manufacturer property with a maximum length of 50 characters and marks it as required.
            builder.Property(x => x.YearManufacture)
                   .HasMaxLength(4)
                   .IsRequired();

            // Configures the Manufacturer property with a maximum length of 50 characters and marks it as required.
            builder.Property(x => x.Manufacturer)
                   .HasMaxLength(100)
                   .IsRequired();

            // Calls the base configuration method to apply additional configurations.
            base.Configure(builder);
        }
    }
}
