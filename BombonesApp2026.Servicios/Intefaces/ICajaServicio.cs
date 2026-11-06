using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Caja;

namespace BombonesApp2026.Servicios.Intefaces
{
    public interface ICajaServicio
    {
        Result<List<CajaListDto>> ObtenerTodos();
        Result<ResultadoPaginacionDto<CajaListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);

        Result<CajaListDto> ObtenerPorId(int id);
        Result<CajaUpdateDto> ObtenerParaEditar(int id);
        Result<int> Agregar(CajaCreateDto CajaDto);
        Result Editar(CajaUpdateDto CajaDto);
        Result Borrar(CajaDeleteDto CajaDto);
        Result<CajaDeleteDto> ObtenerParaBorrar(int productoId);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
                    bool? filtroActivo = null, string? textBuscar=null);
        Result<CajaDetailDto> ObtenerCajaConDetalle(int cajaId);
    }
}
