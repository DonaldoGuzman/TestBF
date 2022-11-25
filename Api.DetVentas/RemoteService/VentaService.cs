using Api.DetVentas.RemoteInterface;
using Api.DetVentas.RemoteModel;
using System.Text.Json;

namespace Api.DetVentas.RemoteService
{
    public class VentaService : IVentaService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<VentaService> _logger;
        private readonly IConfiguration _configuration;

        public VentaService(IHttpClientFactory httpClient,
                ILogger<VentaService> logger,
                IConfiguration iconfiguration)
            
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = iconfiguration;
        }

        public async Task<(bool resultado, VentaRemote venta, string ErrorMessage)> GetVenta(int idVenta)
        {
            var url = _configuration.GetSection("Services: Ventas");
            try
            {
                var cliente = _httpClient.CreateClient("Venta");
                var response = await cliente.GetAsync($"api/Venta/{idVenta}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<VentaRemote>(contenido, options);
                    return (true, resultado, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }

        }
    }
}
