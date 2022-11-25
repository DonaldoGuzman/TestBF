using Api.Producto.Aplicacion;
using Api.Producto.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Producto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public ProductosController(IMediator mediator, IConfiguration configuration)
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
        public async Task<ActionResult<List<ProductosDto>>> GetProductos()
        {
            return await _mediator.Send(new Consulta.Ejecuta { });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductosDto>> GetProducto(int id)
        {
            return await _mediator.Send(new Filtro.Unico { Id = id });
        }
    }
}
