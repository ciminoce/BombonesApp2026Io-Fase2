namespace BombonesApp2026.Entidades
{
    public class Caja : Producto
    {
        private List<DetalleCaja> _detalles = new();
        public int CantidadBombones => _detalles.Sum(d => d.Cantidad);
        public bool EsSurtida => _detalles.Count() > 1;
        public decimal Precio => Math
            .Ceiling(_detalles.Sum(d => d.Subtotal) * 1.2m / 100) * 100;
        public IReadOnlyCollection<DetalleCaja> Detalles => _detalles;
        public Caja()
        {

        }
        public Caja(
            string nombre,
            int stock,
            string? descripcion) : base(nombre, stock, descripcion)
        {

        }

        public override string MostrarDatos()
        {
            string tipoCaja = EsSurtida ? "Surtida" : "Especial";
            return $"Caja ({tipoCaja}): {Nombre} - Precio: {Precio:C2} - Cant. Bombones: {CantidadBombones} unidades";
        }
        public void AgregarBombon(int bombonId, int cantidad)
        {
            if (bombonId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bombonId),
                    "El ID del bombón tiene que ser positivo");
            }
            if (cantidad <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cantidad),
                    "La cantidad de bombones debe ser mayor a cero");
            }
            var detalle = _detalles.FirstOrDefault(d => d.BombonId == bombonId);
            if (detalle is null)
            {
                _detalles.Add(new DetalleCaja
                {
                    BombonId = bombonId,
                    Cantidad = cantidad
                });
                return;
            }
            detalle.Cantidad += cantidad;
        }

        public void EliminarBombon(int bombonId)
        {
            if (_detalles.Count == 1)
            {
                throw new InvalidOperationException("Baja denegada por ser el único detalle");
            }
            if (bombonId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bombonId),
                    "El ID del bombón tiene que ser positivo");
            }
            var detalle = _detalles.FirstOrDefault(d => d.BombonId == bombonId);
            if (detalle is null)
            {
                throw new InvalidOperationException($"El bombon ID {bombonId}" +
                    " no forma parte del detalle");
            }
            _detalles.Remove(detalle);
        }

        public void ModificarCantidadBombon(int bombonId, int cantidadBombon)
        {
            if (bombonId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bombonId),
                    "El ID del bombón tiene que ser positivo");
            }
            if (cantidadBombon <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cantidadBombon),
                    "La cantidad de bombones debe ser mayor a cero");
            }
            var detalle = _detalles.FirstOrDefault(d => d.BombonId == bombonId);
            if (detalle is null)
            {
                throw new InvalidOperationException($"El bombon ID {bombonId}" +
                    " no forma parte del detalle");

            }
            detalle.Cantidad = cantidadBombon;
        }
    }
}
