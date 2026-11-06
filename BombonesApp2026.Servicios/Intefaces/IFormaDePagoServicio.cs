using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.FormaDePago;

namespace BombonesApp2026.Servicios.Intefaces
{
    public interface IFormaDePagoServicio
    {
        Result<List<FormaDePagoListDto>> ObtenerTodos();
        Result<FormaDePagoListDto> ObtenerPorId(int id);
        Result<FormaDePagoUpdateDto> ObtenerParaEditar(int id);
        Result Agregar(FormaDePagoCreateDto formaDePagoDto);
        Result Editar(FormaDePagoUpdateDto formaDePagoDto   );
        Result Borrar(int id);
        Result<List<FormaDePagoListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<FormaDePagoListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);
        Result<List<FormaDePagoListDto>> ObtenerDatosCombo(FormaDePagoDefault formaDefault);
    }
}
