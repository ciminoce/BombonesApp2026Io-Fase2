namespace BombonesApp2026.Entidades
{
    public class DetalleVenta
    {
        public int VentaId { get; private set; }
        public Venta Venta { get; private set; } = null!;

        public int ProductoId { get; private set; }
        public Producto Producto { get; private set; } = null!;

        public decimal Precio { get; private set; }
        public int Cantidad { get; private set; }

        public decimal Subtotal => Precio * Cantidad;

        private DetalleVenta() { } // EF Core

        public DetalleVenta(int productoId, int cantidad, decimal precio)
        {
            if (productoId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(productoId));

            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(cantidad));

            if (precio < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(precio));

            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }

    }
}
