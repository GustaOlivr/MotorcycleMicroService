using Microsoft.AspNetCore.Mvc;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;

namespace MotorcycleMicroService.API.Controllers
{
    /// <summary>
    /// Controller for managing motorcycle-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly ICreateMotorcycleUseCase _createMotorcycleUseCase;
        private readonly IGetMotorcycleByIdUseCase _getMotorcycleByIdUseCase;
        private readonly IUpdateMotorcycleUseCase _updateMotorcycleUseCase;
        private readonly IDeleteMotorcycleUseCase _deleteMotorcycleUseCase;
        private readonly IGetAllMotorcyclesUseCase _getAllMotorcyclesUseCase;
        private readonly ILinkMotorcycleToCustomerUseCase _linkMotorcycleToCustomerUseCase;
        private readonly ILogger<MotorcyclesController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MotorcyclesController"/> class.
        /// </summary>
        /// <param name="createMotorcycleUseCase">Use case for creating motorcycles.</param>
        /// <param name="getMotorcycleByIdUseCase">Use case for retrieving a motorcycle by ID.</param>
        /// <param name="updateMotorcycleUseCase">Use case for updating a motorcycle.</param>
        /// <param name="deleteMotorcycleUseCase">Use case for deleting a motorcycle.</param>
        /// <param name="getAllMotorcyclesUseCase">Use case for retrieving all motorcycles.</param>
        /// <param name="linkMotorcycleToCustomerUseCase">Use case for linking a motorcycle to a customer.</param>
        /// <param name="logger">Logger for logging information and errors.</param>
        public MotorcyclesController(
            ICreateMotorcycleUseCase createMotorcycleUseCase,
            IGetMotorcycleByIdUseCase getMotorcycleByIdUseCase,
            IUpdateMotorcycleUseCase updateMotorcycleUseCase,
            IDeleteMotorcycleUseCase deleteMotorcycleUseCase,
            IGetAllMotorcyclesUseCase getAllMotorcyclesUseCase,
            ILinkMotorcycleToCustomerUseCase linkMotorcycleToCustomerUseCase,
            ILogger<MotorcyclesController> logger)
        {
            _createMotorcycleUseCase = createMotorcycleUseCase;
            _getMotorcycleByIdUseCase = getMotorcycleByIdUseCase;
            _updateMotorcycleUseCase = updateMotorcycleUseCase;
            _deleteMotorcycleUseCase = deleteMotorcycleUseCase;
            _getAllMotorcyclesUseCase = getAllMotorcyclesUseCase;
            _linkMotorcycleToCustomerUseCase = linkMotorcycleToCustomerUseCase;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new motorcycle.
        /// </summary>
        /// <param name="dto">The motorcycle data transfer object containing motorcycle details.</param>
        /// <returns>A created motorcycle response along with a location header.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMotorcycleRequest dto)
        {
            _logger.LogInformation("Request initiated");

            CreateMotorcycleResponse response = await _createMotorcycleUseCase.ExecuteAsync(dto);
            _logger.LogInformation("Response: {@response}", response);

            return CreatedAtAction(nameof(Get), new { id = response.MotorcycleId }, response);
        }

        /// <summary>
        /// Retrieves a motorcycle by its ID.
        /// </summary>
        /// <param name="id">The ID of the motorcycle to retrieve.</param>
        /// <returns>The motorcycle details if found; otherwise, a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            GetMotorcycleByIdResponse response = await _getMotorcycleByIdUseCase.ExecuteAsync(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Retrieves all motorcycles.
        /// </summary>
        /// <param name="dto">The request object for retrieving all motorcycles.</param>
        /// <returns>A list of motorcycles.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMotorcyclesRequest dto)
        {
            GetAllMotorcyclesResponse response = await _getAllMotorcyclesUseCase.ExecuteAsync(dto);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Updates an existing motorcycle.
        /// </summary>
        /// <param name="id">The ID of the motorcycle to update.</param>
        /// <param name="dto">The motorcycle data transfer object containing updated details.</param>
        /// <returns>The updated motorcycle response.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateMotorcycleRequest dto)
        {
            UpdateMotorcycleResponse response = await _updateMotorcycleUseCase.ExecuteAsync(id, dto);
            return Ok(response);
        }

        /// <summary>
        /// Deletes a motorcycle by its ID.
        /// </summary>
        /// <param name="motorcycleId">The ID of the motorcycle to delete.</param>
        /// <returns>A no-content response if successful; otherwise, a bad request response.</returns>
        [HttpDelete("{motorcycleId}")]
        public async Task<IActionResult> Delete(Guid motorcycleId)
        {
            bool response = await _deleteMotorcycleUseCase.ExecuteAsync(motorcycleId);
            if (response == true)
            {
                return NoContent();
            }

            return BadRequest("Something went wrong with the request");
        }

        /// <summary>
        /// Links a motorcycle to a customer.
        /// </summary>
        /// <param name="dto">The request object containing the linking details.</param>
        /// <returns>A created response with the linked motorcycle.</returns>
        [HttpPost("link")]
        public async Task<IActionResult> LinkMotorcycleToCustomer([FromBody] LinkMotorcycleToCustomerRequest dto)
        {
            LinkMotorcycleToCustomerResponse response = await _linkMotorcycleToCustomerUseCase.ExecuteAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = response.MotorcycleId }, response);
        }
    }
}
