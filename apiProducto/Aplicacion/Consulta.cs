using Api.Producto.DTO;
using Api.Producto.Model;
using Api.Producto.Persistens;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Producto.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<ProductosDto>>
        {
            //public Boolean Estado { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<ProductosDto>>
        {
            private readonly ContextApp _context;
            private readonly IMapper _mapper;
            public Manejador(ContextApp context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProductosDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var result = await _context.Productos.ToListAsync();
                if (result == null)
                {
                    throw new Exception("No existen tipo de clasificadores");
                }
                var resultDTO = _mapper.Map<List<Productos>, List<ProductosDto>>(result);
                return resultDTO;
            }
        }
    }
}
