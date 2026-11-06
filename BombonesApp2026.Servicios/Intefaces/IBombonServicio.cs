using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Bombon;

namespace BombonesApp2026.Servicios.Intefaces
{
    public interface IBombonServicio
    {
        Result<List<BombonListDto>> ObtenerTodos();
        Result<ResultadoPaginacionDto<BombonListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);

        Result<BombonListDto> ObtenerPorId(int id);
        Result<BombonUpdateDto> ObtenerParaEditar(int id);
        Result<int> Agregar(BombonCreateDto bombonDto);
        Result Editar(BombonUpdateDto bombonDto);
        Result Borrar(BombonDeleteDto bombonDto);
        Result<BombonDeleteDto> ObtenerParaBorrar(int productoId);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
                    bool? filtroActivo = null);
        Result<List<BombonComboDto>> ObtenerDatosCombo(BombonDefault defaultBombon, bool activos);
    }
}
