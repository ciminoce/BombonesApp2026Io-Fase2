using BombonesApp2026.Entidades;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface IVentaRepositorio
    {
        List<Venta> ObtenerTodos();
        Venta? ObtenerPorId(int ventaId, bool tracked=false);
        (List<Venta> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
        void Agregar(Venta venta);

    }
}
