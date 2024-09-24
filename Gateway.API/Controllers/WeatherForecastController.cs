using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace Gateway.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(HttpClient httpClient, ILogger<WeatherForecastController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            // URL do microsserviço de motorcycle
            var motorcycleServiceUrl = "http://localhost:5255/api/motorcycles"; // Altere para HTTP

            try
            {
                // Fazendo uma requisição GET ao microsserviço de motorcycle
                var response = await _httpClient.GetAsync(motorcycleServiceUrl);

                // Verifica se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Deserializa o conteúdo da resposta
                    var motorcycles = await response.Content.ReadFromJsonAsync<IEnumerable<object>>();
                    return Ok(motorcycles);
                }
                else
                {
                    _logger.LogError("Falha ao chamar o microsserviço de motorcycle.");
                    return StatusCode((int)response.StatusCode, "Falha ao acessar o microsserviço de motorcycle.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante a chamada ao microsserviço de motorcycle.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}
