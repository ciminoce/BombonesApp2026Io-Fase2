using BombonesApp2026.Servicios.DTOs.DetalleVenta;
using BombonesApp2026.Servicios.DTOs.Venta;

namespace BombonesApp2026.Windows.Classes
{
    public class EditorVenta
    {
        private VentaCreateDto _ventaDto = null!;
        public EditorVenta(VentaCreateDto ventaDto)
        {
            _ventaDto = ventaDto;
        }
        public void AgregarProducto(DetalleVentaDto detalleDto)
        {
            if (detalleDto is null) throw new ArgumentNullException(nameof(detalleDto),
                "El detalle no puede ser nulo");
            var detalleEnVenta = _ventaDto.Detalle
                .FirstOrDefault(dv => dv.ProductoId == detalleDto.ProductoId);
            if (detalleEnVenta is null)
            {
                _ventaDto.Detalle.Add(detalleDto);
                return;
            }
            detalleEnVenta.Cantidad += detalleDto.Cantidad;
        }
        public void EliminarProducto(int productoId)
        {
            if (_ventaDto.Detalle.Count == 1)
            {
                throw new InvalidOperationException("La venta debe tener al menos 1 item");
            }
            if (productoId <= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor a cero");
            }
            var detalleEnVenta = _ventaDto.Detalle
                .FirstOrDefault(dv => dv.ProductoId == productoId);
            if (detalleEnVenta is null)
            {
                throw new InvalidOperationException($"El producto ID {productoId}" +
                    $" no se encuentra en el detalle");
            }
            _ventaDto.Detalle.Remove(detalleEnVenta);
        }
        public void ModificarCantidadDetalle(int productoId, int cantidad)
        {
            if (productoId <= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor a cero");
            }
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero");
            }
            var detalleEnVenta = _ventaDto.Detalle
    .FirstOrDefault(dv => dv.ProductoId == productoId);
            if (detalleEnVenta is null)
            {
                throw new InvalidOperationException($"El producto ID {productoId}" +
                    $" no se encuentra en el detalle");
            }
            detalleEnVenta.Cantidad = cantidad;
        }

        internal List<DetalleVentaDto> ObtenerDetalles()
        {
            return _ventaDto.Detalle;
        }

        internal (IReadOnlyCollection<DetalleVentaDto> Detalles,
             decimal Total) ObtenerResumen()
        {
            var detalles = _ventaDto.Detalle;
            var total = _ventaDto.Detalle.Sum(d => d.Subtotal);
            return (detalles, total);
        }
    }
}
