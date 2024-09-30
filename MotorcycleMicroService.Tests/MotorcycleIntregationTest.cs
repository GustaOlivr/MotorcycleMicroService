using Microsoft.EntityFrameworkCore;
using MotorcycleMicroService.Application.Services;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Persistense.Context;
using MotorcycleMicroService.Persistense.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MotorcycleMicroService.Tests.IntegrationTests
{
    public class MotorcycleServiceIntegrationTests : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly MotorcycleService _motorcycleService;

        public MotorcycleServiceIntegrationTests()
        {
            // Configuração do DbContext com InMemoryDatabase
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "MotorcycleInMemoryDb")
                .Options;

            _context = new AppDbContext(options);
            _motorcycleRepository = new MotorcycleRepository(_context);
            _motorcycleService = new MotorcycleService(_motorcycleRepository);
        }

        [Fact]
        public async Task CreateMotorcycle_ShouldAddMotorcycleToDatabase()
        {
            // Arrange
            var newMotorcycle = new Motorcycle
            {
                MotorcycleId = Guid.NewGuid(),
                Name = "Yamaha MT-07"
            };

            // Act
            await _motorcycleService.CreateAsync(newMotorcycle);
            var result = await _motorcycleService.GetByIdAsync(newMotorcycle.MotorcycleId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Yamaha MT-07", result.Name);
        }

        [Fact]
        public async Task GetAllMotorcycles_ShouldReturnAllMotorcycles()
        {
            // Arrange
            await _motorcycleService.CreateAsync(new Motorcycle { MotorcycleId = Guid.NewGuid(), Name = "Yamaha" });
            await _motorcycleService.CreateAsync(new Motorcycle { MotorcycleId = Guid.NewGuid(), Name = "Honda" });

            // Act
            var motorcycles = await _motorcycleService.GetAllAsync();

            // Assert
            Assert.Equal(2, motorcycles.Count);
        }

        [Fact]
        public async Task UpdateMotorcycle_ShouldModifyMotorcycleDetails()
        {
            // Arrange
            var motorcycle = new Motorcycle { MotorcycleId = Guid.NewGuid(), Name = "Kawasaki" };
            await _motorcycleService.CreateAsync(motorcycle);

            // Act
            motorcycle.Name = "Kawasaki Z900";
            await _motorcycleService.UpdateAsync(motorcycle);
            var updatedMotorcycle = await _motorcycleService.GetByIdAsync(motorcycle.MotorcycleId);

            // Assert
            Assert.Equal("Kawasaki Z900", updatedMotorcycle.Name);
        }

        [Fact]
        public async Task DeleteMotorcycle_ShouldRemoveMotorcycleFromDatabase()
        {
            // Arrange
            var motorcycle = new Motorcycle { MotorcycleId = Guid.NewGuid(), Name = "Ducati" };
            await _motorcycleService.CreateAsync(motorcycle);

            // Act
            await _motorcycleService.DeleteAsync(motorcycle.MotorcycleId);
            var result = await _motorcycleService.GetByIdAsync(motorcycle.MotorcycleId);

            // Assert
            Assert.Null(result);
        }

        // Método para limpar o banco de dados em memória após cada teste
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
