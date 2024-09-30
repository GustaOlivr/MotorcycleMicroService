//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using AutoMapper;
//using MotorcycleMicroService.Application.UseCases;
//using MotorcycleMicroService.Domain.Interfaces.Services;
//using MotorcycleMicroService.Domain.Entities;
//using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
//using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
//using System.Threading.Tasks;
//using MotorcycleMicroService.Domain.Entities.Enumerations;
//using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;

//namespace MotorcycleMicroService.Tests.UseCases
//{
//    [TestClass]
//    public class CreateMotorcycleUseCaseTests
//    {
//        private Mock<IMotorcycleService> _motorcycleServiceMock;
//        private Mock<IMapper> _mapperMock;
//        private CreateMotorcycleUseCase _createMotorcycleUseCase;

//        [TestInitialize]
//        public void Setup()
//        {
//            _motorcycleServiceMock = new Mock<IMotorcycleService>();
//            _mapperMock = new Mock<IMapper>();

//            _createMotorcycleUseCase = new CreateMotorcycleUseCase(
//                _motorcycleServiceMock.Object,
//                _mapperMock.Object);
//        }

//        [TestMethod]
//        public async Task ExecuteAsync_ShouldReturnCreateMotorcycleResponse_WhenMotorcycleIsCreated()
//        {
            
//           CreateMotorcycleRequest dto = new CreateMotorcycleRequest
//           {
//               Name = "Fazer Teste",
//               Plate = "ABCD123",
//               Type = MotorcycleType.Street,
//               YearManufacture = 2017
//           };

//            var motorcycle = new Motorcycle
//            {
//                Name = "Fazer Teste",
//                Plate = "ABCD123",
//                Type = MotorcycleType.Street,
//                YearManufacture = 2017
//            };

//            var createdMotorcycle = new Motorcycle
//            {
//                MotorcycleId = Guid.NewGuid(),
//                Name = "Fazer Teste",
//                Plate = "ABCD123",
//                Type = MotorcycleType.Street,
//                YearManufacture = 2017
//            };

//            var expectedResponse = new CreateMotorcycleResponse
//            {
//                MotorcycleId = createdMotorcycle.MotorcycleId,
//                Name = "Fazer Teste",
//                Plate = "ABCD123",
//                Type = MotorcycleType.Street,
//                YearManufacture = "2017"
//            };

//            // Configurar o mock do IMapper
//            _mapperMock.Setup(m => m.Map<Motorcycle>(dto)).Returns(motorcycle);

//            // Configurar o mock do IMotorcycleService
//            _motorcycleServiceMock.Setup(s => s.CreateAsync(motorcycle)).ReturnsAsync(createdMotorcycle);

//            // Configurar o mock do IMapper para mapear a entidade criada para o response
//            _mapperMock.Setup(m => m.Map<CreateMotorcycleResponse>(createdMotorcycle)).Returns(expectedResponse);

//           var result = await _createMotorcycleUseCase.ExecuteAsync(dto);
//            CreateMotorcycleResponse response = new CreateMotorcycleUseCase(_motorcycleServiceMock, _mapperMock).ExecuteAsync(dto);


//            Assert.IsNotNull(result);
//            Assert.AreEqual(expectedResponse.MotorcycleId, result.MotorcycleId);
//            Assert.AreEqual(expectedResponse.Name, result.Name);
//            Assert.AreEqual(expectedResponse.Plate, result.Plate);
//            Assert.AreEqual(expectedResponse.Type, result.Type);

//            // Verificar se os métodos mockados foram chamados corretamente
//            _mapperMock.Verify(m => m.Map<Motorcycle>(dto), Times.Once);
//            _motorcycleServiceMock.Verify(s => s.CreateAsync(motorcycle), Times.Once);
//            _mapperMock.Verify(m => m.Map<CreateMotorcycleResponse>(createdMotorcycle), Times.Once);
//        }

//    }
//}
