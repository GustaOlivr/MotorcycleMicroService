using AutoMapper;
using Moq;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Application.UseCases;
using MotorcycleMicroService.Domain.Entities.Enumerations;
using MotorcycleMicroService.Domain.Entities;
using MotorcycleMicroService.Domain.Interfaces.Services;
using System.Xml.Linq;
using MotorcycleMicroService.Application.AutoMapping;

namespace MotorcycleMicroService.Tests
{
    public class CreateMotorcycleUseCaseTests
    {

        private readonly Mock<IMotorcycleService> _motorcycleServiceMock;
        private readonly IMapper _mapper;
        private readonly CreateMotorcycleUseCase _createMotorcycleUseCase;

        public CreateMotorcycleUseCaseTests()
        {
            _motorcycleServiceMock = new Mock<IMotorcycleService>();

            // Reutilizando a configuração de mapeamento existente na aplicação
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MotorcycleMappingProfile());  // Adiciona o perfil de mapeamento existente
            });
            _mapper = config.CreateMapper();

            _createMotorcycleUseCase = new CreateMotorcycleUseCase(_motorcycleServiceMock.Object, _mapper);
        }

        [Fact]
        public async Task ExecuteAsync_ProductExists_ReturnsProductDto()
        {
            CreateMotorcycleRequest dto = new CreateMotorcycleRequest
            {
                Name = "Fazer Teste",
                Plate = "ABCD123",
                Type = MotorcycleType.Street,
                YearManufacture = 2017
            };

            Motorcycle createdMotorcycle = new Motorcycle
            {
                MotorcycleId = Guid.NewGuid(),
                Name = "Fazer Teste",
                Plate = "ABCD123",
                Type = MotorcycleType.Street,
                YearManufacture = 2017
            };

            var expectedResponse = new CreateMotorcycleResponse
            {
                MotorcycleId = createdMotorcycle.MotorcycleId,
                Name = "Fazer Teste",
                Plate = "ABCD123",
                Type = MotorcycleType.Street,
                YearManufacture = "2017"
            };


            _motorcycleServiceMock
    .Setup(service => service.CreateAsync(It.IsAny<Motorcycle>()))
    .ReturnsAsync(createdMotorcycle);

            // Act: Executa o use case
            var result = await _createMotorcycleUseCase.ExecuteAsync(dto);

            // Assert: Verifica se o serviço foi chamado corretamente e se o retorno está correto
            _motorcycleServiceMock.Verify(service => service.CreateAsync(It.IsAny<Motorcycle>()), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(expectedResponse.MotorcycleId, result.MotorcycleId);
            Assert.Equal(expectedResponse.Name, result.Name);
            Assert.Equal(expectedResponse.Plate, result.Plate);
            Assert.Equal(expectedResponse.Type, result.Type);

        }

        [Fact]
        public async Task ExecuteAsync_ShouldCallCreateAsync_WithCorrectMappedMotorcycle()
        {
            // Arrange
            CreateMotorcycleRequest dto = new CreateMotorcycleRequest
            {
                Name = "Fazer Teste",
                Plate = "ABCD123",
                Type = MotorcycleType.Street,
                YearManufacture = 2017
            };

            Motorcycle? motorcycleCreated = null;

            _motorcycleServiceMock
                .Setup(service => service.CreateAsync(It.IsAny<Motorcycle>()))
                .Callback<Motorcycle>(motorcycle => motorcycleCreated = motorcycle)
                .ReturnsAsync(new Motorcycle { MotorcycleId = Guid.NewGuid(), Type = MotorcycleType.Street, YearManufacture = 2017, Plate = "ABCD123", Name = "Fazer Teste" });

            // Act
            await _createMotorcycleUseCase.ExecuteAsync(dto);

            // Assert: Verifica se o objeto Motorcycle mapeado está correto
            Assert.NotNull(motorcycleCreated);
            Assert.Equal(dto.Type, motorcycleCreated.Type);
            Assert.Equal(dto.YearManufacture, motorcycleCreated.YearManufacture);
            Assert.Equal(dto.Plate, motorcycleCreated.Plate);
        }
    }
}