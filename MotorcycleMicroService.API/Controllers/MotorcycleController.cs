using Microsoft.AspNetCore.Mvc;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;

namespace MotorcycleMicroService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly ICreateMotorcycleUseCase _createMotorcycleUseCase;
        private readonly IGetMotorcycleByIdUseCase _getMotorcycleByIdUseCase;
        private readonly IUpdateMotorcycleUseCase _updateMotorcycleUseCase;
        private readonly IDeleteMotorcycleUseCase _deleteMotorcycleUseCase;

        public MotorcyclesController(
            ICreateMotorcycleUseCase createMotorcycleUseCase,
            IGetMotorcycleByIdUseCase getMotorcycleByIdUseCase,
            IUpdateMotorcycleUseCase updateMotorcycleUseCase,
            IDeleteMotorcycleUseCase deleteMotorcycleUseCase)
        {
            _createMotorcycleUseCase = createMotorcycleUseCase;
            _getMotorcycleByIdUseCase = getMotorcycleByIdUseCase;
            _updateMotorcycleUseCase = updateMotorcycleUseCase;
            _deleteMotorcycleUseCase = deleteMotorcycleUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMotorcycleRequest dto)
        {
            CreateMotorcycleResponse response = await _createMotorcycleUseCase.ExecuteAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = response.MotorcycleId }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            GetMotorcycleByIdResponse response = await _getMotorcycleByIdUseCase.ExecuteAsync(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateMotorcycleRequest dto)
        {
            UpdateMotorcycleResponse response = await _updateMotorcycleUseCase.ExecuteAsync(id, dto);
            return Ok(response);
        }

        [HttpDelete("{motorcycleId}")]
        public async Task<IActionResult> Delete(Guid motorcycleId)
        {
            bool response = await _deleteMotorcycleUseCase.ExecuteAsync(motorcycleId);
            if (response = true)
            {
                return NoContent();
            }

            return BadRequest("Algo errado com a requisição");
        }
    }
}
