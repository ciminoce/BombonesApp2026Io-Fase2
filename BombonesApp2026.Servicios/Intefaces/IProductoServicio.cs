using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Producto;

namespace BombonesApp2026.Servicios.Intefaces
{
    public interface IProductoServicio
    {
        Result<List<ProductoListDto>> ObtenerTodos();

    }
}
