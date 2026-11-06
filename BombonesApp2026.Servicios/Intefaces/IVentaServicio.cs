using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Venta;

namespace BombonesApp2026.Servicios.Intefaces
{
    public interface IVentaServicio
    {
        Result<ResultadoPaginacionDto<VentaListDto>> ObtenerPaginado(int paginaSolicitada,
    int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo=false, string? textoBuscar=null);
        Result<List<VentaListDto>> ObtenerTodos();
        Result<VentaDetailDto?> ObtenerPorId(int ventaId);
        Result<int> Agregar(VentaCreateDto ventaDto);
        Result AnularVenta(int ventaId);
        Result Facturar(int ventaId);
    }
}
