﻿using Api.Ventas.Aplicacion;
using Api.Ventas.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public VentasController(IMediator mediator, IConfiguration configuration)
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
        public async Task<ActionResult<List<VentasDto>>> GetVentas()
        {
            return await _mediator.Send(new Consulta.Ejecuta { });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VentasDto>> GetVenta(int id)
        {
            return await _mediator.Send(new Filtro.Unico { Id = id });
        }
    }
}
