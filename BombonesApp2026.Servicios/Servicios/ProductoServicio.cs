using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Producto;
using BombonesApp2026.Servicios.Intefaces;

namespace BombonesApp2026.Servicios.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;
        public ProductoServicio(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }
        //TODO:OJO : Implementar el método ObtenerTodos() para obtener todos los productos y mapearlos a ProductoListDto
        public Result<List<ProductoListDto>> ObtenerTodos()
        {
            try
            {
                var productos = _productoRepositorio.ObtenerTodos();
                return Result<List<ProductoListDto>>.Success(productos
                    .Select(p =>
                    {
                        decimal precio = 0m;
                        string tipoProducto = "Producto";
                        if (p is Bombon b)
                        {
                            precio = b.Precio;
                            tipoProducto = "Bombón";
                        }
                        else if (p is Caja c)
                        {
                            precio = c.Precio;
                            tipoProducto = "Caja";
                        }
                        return new ProductoListDto
                        {
                            ProductoId = p.ProductoId,
                            Nombre = p.Nombre,
                            Precio = precio,
                            TipoProducto = tipoProducto,
                            Descripcion = p.Descripcion,
                            Stock = p.Stock
                        };
                    }).ToList());

            }
            catch (Exception ex)
            {

                return Result<List<ProductoListDto>>
                    .Failure(new List<string> { ex.Message });
            }
        }
    }
}
