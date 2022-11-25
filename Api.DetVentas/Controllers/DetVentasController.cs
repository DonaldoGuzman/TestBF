using Api.DetVentas.Aplicacion;
using Api.DetVentas.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetVentasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public DetVentasController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleVentaDto>>> GetVentas()
        {
            return await _mediator.Send(new Consulta.Ejecuta { });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVentaDto>> GetVenta(int id)
        {
            return await _mediator.Send(new Filtro.Unico { Id = id });
        }
    }
}
