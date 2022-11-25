using Api.DetVentas.DTO;
using Api.DetVentas.Model;
using Api.DetVentas.Persistens;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.DetVentas.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<DetalleVentaDto>>
        {
            //public Boolean Estado { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<DetalleVentaDto>>
        {
            private readonly ContextApp _context;
            private readonly IMapper _mapper;
            public Manejador(ContextApp context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DetalleVentaDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var result = await _context.DetalleVenta.ToListAsync();
                if (result == null)
                {
                    throw new Exception("No existen tipo de clasificadores");
                }
                var resultDTO = _mapper.Map<List<DetalleVenta>, List<DetalleVentaDto>>(result);
                return resultDTO;
            }
        }
    }
}
