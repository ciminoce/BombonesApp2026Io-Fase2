using BombonesApp2026.Entidades.Enums;

namespace BombonesApp2026.Entidades
{
    public class Venta
    {
        private readonly List<DetalleVenta> _detalles = new();

        public int VentaId { get; private set; }

        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; } = null!;

        public DateTime FechaVenta { get; private set; }
        public int FormaDePagoId { get; private set; }
        public FormaDePago FormaDePago { get; set; } = null!;

        public EstadoVenta EstadoVenta { get; private set; }
        public byte[] RowVersion { get; set; }

        public decimal TotalVenta { get; private set; }

        public IReadOnlyCollection<DetalleVenta> Detalles =>
            _detalles.AsReadOnly();

        private Venta() { } // EF Core
        public Venta(int clienteId, int formaDePagoId)
        {
            if (clienteId < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(clienteId));
            if (formaDePagoId < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(formaDePagoId));



            ClienteId = clienteId;
            FormaDePagoId = formaDePagoId;
            FechaVenta = DateTime.Now;
            EstadoVenta = EstadoVenta.Pendiente;
        }

        public void AgregarDetalle(int productoId, int cantidad, decimal precio)
        {
            if (_detalles.Any(d => d.ProductoId == productoId))
                throw new InvalidOperationException(
                    $"El producto con ID {productoId} ya está incluido en la venta.");
            var detalle = new DetalleVenta(
                productoId, cantidad, precio);

            _detalles.Add(detalle);

            TotalVenta = _detalles.Sum(d => d.Subtotal);
        }
        public void Facturar()
        {
            if (EstadoVenta != EstadoVenta.Pendiente)
                throw new InvalidOperationException(
                    "Solamente se pueden facturar ventas pendientes.");

            if (!_detalles.Any())
                throw new InvalidOperationException(
                    "No se puede facturar una venta sin detalles.");

            EstadoVenta = EstadoVenta.Facturada;
        }

        public void Anular()
        {
            if (EstadoVenta != EstadoVenta.Pendiente)
                throw new InvalidOperationException(
                    "Solamente se pueden anular ventas pendientes.");

            EstadoVenta = EstadoVenta.Anulada;
        }
    }

}
