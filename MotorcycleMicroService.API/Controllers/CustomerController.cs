using Microsoft.AspNetCore.Mvc;
using MotorcycleMicroService.Application.Dto.CustomerDto.Requests;
using MotorcycleMicroService.Application.Dto.CustomerDto.Responses;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;
using MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;

namespace MotorcycleMicroService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICreateCustomerUseCase _createCustomerUseCase;
        private readonly IGetCustomerByIdUseCase _getCustomerByIdUseCase;


        public CustomersController(
            ICreateCustomerUseCase createCustomerUseCase, IGetCustomerByIdUseCase getCustomerByIdUseCase )
        {
            _createCustomerUseCase = createCustomerUseCase;
            _getCustomerByIdUseCase = getCustomerByIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest dto)
        {
            CreateCustomerResponse response = await _createCustomerUseCase.ExecuteAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = response.CustomerId }, response);
        }

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
