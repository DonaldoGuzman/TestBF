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
    public class Filtro
    {
        public class Unico : MediatR.IRequest<ProductosDto>
        {
            public int Id { get; set; }
        }
        public class Manejador : IRequestHandler<Unico, ProductosDto>
        {
            private readonly ContextApp _context;
            private readonly IMapper _mapper;
            public Manejador(ContextApp context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ProductosDto> Handle(Unico request, CancellationToken cancellationToken)
            {
                var result = await _context.Productos.Where(x => x.idProducto == request.Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new Exception("No se encontró el tipo de clasificador");
                }
                var resultDto = _mapper.Map<Productos, ProductosDto>(result);
                return resultDto;
            }
        }
    }
}
