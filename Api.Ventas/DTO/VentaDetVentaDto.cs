namespace Api.Ventas.DTO
{
    public class VentaDetVentaDto
    {
        public int idVenta { get; set; }
        public int idDetalleVenta { get; set; }
        public int idProducto { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Cliente { get; set; }
        public int Estado { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
