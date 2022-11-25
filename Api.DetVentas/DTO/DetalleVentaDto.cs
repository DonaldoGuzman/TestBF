namespace Api.DetVentas.DTO
{
    public class DetalleVentaDto
    {
        public int idDetalleVenta { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public int idProducto { get; set; }
        public int idVenta { get; set; }
    }
}
