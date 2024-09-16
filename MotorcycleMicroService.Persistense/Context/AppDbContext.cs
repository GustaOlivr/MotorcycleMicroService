using Microsoft.EntityFrameworkCore;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Persistense.Mapping;

namespace MotorcycleMicroService.Persistense.Context
{
    /// <summary>
    /// Represents the application's database context, providing access to the database entities.
    /// Inherits from <see cref="DbContext"/>.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class with specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for the <see cref="User"/> entity.
        /// </summary>
        public DbSet<Motorcycle> Motorcycles { get; set; }

        /// <summary>
        /// Configures the Entity Framework model when creating the entities in the database.
        /// This method is called when the context is used for the first time.
        /// </summary>
        /// <param name="builder">A <see cref="ModelBuilder"/> used to build the model for the entities.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MotorcycleConfiguration());
            //Add other configurations
        }
    }
}
