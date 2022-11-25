using Api.Producto.DTO;
using Api.Producto.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Producto.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Productos, ProductosDto>();
        }
        
    }
}
