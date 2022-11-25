using System.ComponentModel.DataAnnotations;

namespace Api.Ventas.Model
{
    public class Venta
    {
        [Key]
        public int idVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Cliente { get; set; }
        public int Estado { get; set; }
        public DateTime FechaAnulacion { get; set; }
    }
}
