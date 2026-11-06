using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.TipoBombon;

namespace BombonesApp2026.Servicios.Intefaces
{
    public interface ITipoBombonServicio
    {
        Result<List<TipoBombonListDto>> ObtenerTodos();
        Result<TipoBombonListDto> ObtenerPorId(int id);
        Result<TipoBombonUpdateDto> ObtenerParaEditar(int id);
        Result<TipoBombonDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(TipoBombonCreateDto tipoBombonDto);
        Result Editar(TipoBombonUpdateDto tipoBombonDto);
        Result Borrar(TipoBombonDeleteDto tipoBombonDto);
        Result<List<TipoBombonListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<TipoBombonListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo=null, string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo=null, string? textoBuscar = null);
        Result<List<TipoBombonListDto>> ObtenerDatosCombo(TipoBombonDefault tipoDefault);
    }
}
