using Microsoft.AspNetCore.Mvc;
using MotorcycleMicroService.Application.Dto.CustomerDto.Requests;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;

namespace MotorcycleMicroService.API.Controllers
{
    /// <summary>
    /// Controller for managing customer-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICreateCustomerUseCase _createCustomerUseCase;
        private readonly IGetCustomerByIdUseCase _getCustomerByIdUseCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="createCustomerUseCase">Use case for creating customers.</param>
        /// <param name="getCustomerByIdUseCase">Use case for retrieving a customer by ID.</param>
        public CustomersController(
            ICreateCustomerUseCase createCustomerUseCase,
            IGetCustomerByIdUseCase getCustomerByIdUseCase)
        {
            _createCustomerUseCase = createCustomerUseCase;
            _getCustomerByIdUseCase = getCustomerByIdUseCase;
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="dto">The customer data transfer object containing customer details.</param>
        /// <returns>A created customer response along with a location header.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest dto)
        {
            CreateCustomerResponse response = await _createCustomerUseCase.ExecuteAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = response.CustomerId }, response);
        }

        /// <summary>
        /// Retrieves a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer details if found; otherwise, a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            GetCustomerByIdResponse response = await _getCustomerByIdUseCase.ExecuteAsync(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllMotorcyclesRequest dto)
        //{
        //    GetAllMotorcyclesResponse response = await _getAllMotorcyclesUseCase.ExecuteAsync(dto);
        //    if (response == null)
        //        return NotFound();

        //    return Ok(response);
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(Guid id, [FromBody] UpdateMotorcycleRequest dto)
        //{
        //    UpdateMotorcycleResponse response = await _updateMotorcycleUseCase.ExecuteAsync(id, dto);
        //    return Ok(response);
        //}

        //[HttpDelete("{motorcycleId}")]
        //public async Task<IActionResult> Delete(Guid motorcycleId)
        //{
        //    bool response = await _deleteMotorcycleUseCase.ExecuteAsync(motorcycleId);
        //    if (response = true)
        //    {
        //        return NoContent();
        //    }

        //    return BadRequest("Algo errado com a requisição");
        //}
    }
}
