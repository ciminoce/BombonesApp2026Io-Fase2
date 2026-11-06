using BombonesApp2026.Entidades;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface IProductoRepositorio
    {
        Producto? ObtenerPorId(int productoId, bool tracked=false);
        List<Producto> ObtenerTodos();

    }
}
