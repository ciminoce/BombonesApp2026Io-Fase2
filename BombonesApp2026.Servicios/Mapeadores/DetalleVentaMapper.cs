using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.DTOs.DetalleVenta;

namespace BombonesApp2026.Servicios.Mapeadores
{
    public static class DetalleVentaMapper
    {
        public static DetalleVentaDto ToDto(this DetalleVenta detalleVenta)
        {
            return new DetalleVentaDto
            {
                ProductoId = detalleVenta.ProductoId,
                Producto = detalleVenta.Producto.Nombre,
                Precio = detalleVenta.Precio,
                Cantidad = detalleVenta.Cantidad,
                Stock = detalleVenta.Producto.Stock
            };
        }

    }
}
