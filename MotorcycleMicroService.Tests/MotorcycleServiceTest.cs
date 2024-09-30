using Moq;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Application.Services;
using Xunit;
using System;
using System.Threading.Tasks;
using MotorcycleMicroService.Domain.Entities.Enumerations;

namespace MotorcycleMicroService.Tests.Services
{
    public class MotorcycleServiceTests
    {
        private readonly Mock<IMotorcycleRepository> _motorcycleRepositoryMock;
        private readonly MotorcycleService _motorcycleService;

        public MotorcycleServiceTests()
        {
            // Cria o mock do repositório
            _motorcycleRepositoryMock = new Mock<IMotorcycleRepository>();

            // Cria a instância do serviço a ser testado, passando o mock do repositório
            _motorcycleService = new MotorcycleService(_motorcycleRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedMotorcycle()
        {
            // Arrange: prepara os dados e o comportamento do mock
            var motorcycle = new Motorcycle
            {
                MotorcycleId = Guid.NewGuid(),
                Name = "Yamaha",
                Plate = "ABC123",
                Type = MotorcycleType.Street,
                YearManufacture = 2020
            };

            // Configura o mock para adicionar a moto
            _motorcycleRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Motorcycle>()))
                .Returns(Task.CompletedTask);

            // Act: chama o método do serviço
            var result = await _motorcycleService.CreateAsync(motorcycle);

            // Assert: verifica se o método retorna a moto correta
            Assert.NotNull(result);
            Assert.Equal(motorcycle.Name, result.Name);
            Assert.Equal(motorcycle.Plate, result.Plate);
            _motorcycleRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Motorcycle>()), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMotorcycle_WhenFound()
        {
            // Arrange
            var motorcycleId = Guid.NewGuid();
            var motorcycle = new Motorcycle
            {
                MotorcycleId = motorcycleId,
                Name = "Honda",
                Plate = "XYZ789",
                Type = MotorcycleType.Sport,
                YearManufacture = 2018
            };

            // Configura o mock para retornar uma moto específica pelo ID
            _motorcycleRepositoryMock.Setup(repo => repo.GetByIdAsync(motorcycleId))
                .ReturnsAsync(motorcycle);

            // Act
            var result = await _motorcycleService.GetByIdAsync(motorcycleId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(motorcycleId, result.MotorcycleId);
            Assert.Equal("Honda", result.Name);
            _motorcycleRepositoryMock.Verify(repo => repo.GetByIdAsync(motorcycleId), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDelete()
        {
            // Arrange
            var motorcycleId = Guid.NewGuid();

            // Configura o mock para deletar uma moto específica pelo ID
            _motorcycleRepositoryMock.Setup(repo => repo.DeleteAsync(motorcycleId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _motorcycleService.DeleteAsync(motorcycleId);

            // Assert: verifica se o método delete foi chamado corretamente
            Assert.True(result);
            _motorcycleRepositoryMock.Verify(repo => repo.DeleteAsync(motorcycleId), Times.Once);
        }
    }
}
