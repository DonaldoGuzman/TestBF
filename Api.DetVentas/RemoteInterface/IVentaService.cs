using Api.DetVentas.RemoteModel;

namespace Api.DetVentas.RemoteInterface
{
    public interface IVentaService
    {
        Task<(bool resultado, VentaRemote venta, string ErrorMessage)> GetVenta(int idVenta);
    }
}
