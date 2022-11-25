using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Producto.Model
{
    public class Productos
    {
        [Key]
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int IdMedida { get; set; }
        public decimal PrecioIngreso { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaIngreso { get; set; }
       public DateTime FechaActualizacion { get; set; }

    }
}
