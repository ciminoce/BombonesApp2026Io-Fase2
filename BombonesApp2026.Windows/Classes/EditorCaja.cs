using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.DTOs.Bombon;
using BombonesApp2026.Servicios.DTOs.Caja;
using BombonesApp2026.Servicios.DTOs.DetalleCaja;

namespace BombonesApp2026.Windows.Classes
{
    public class EditorCaja
    {
        private CajaUpdateDto _cajaDto;

        public EditorCaja(CajaUpdateDto cajaDto)
        {
            _cajaDto = cajaDto;
        }
        public void AgregarBombon(BombonComboDto bombon, int cantidad)
        {
            if(bombon is null)
            {
                throw new ArgumentNullException(nameof(bombon),"" +
                    "El bombón no puede ser nullo");
            }
            if (cantidad <= 0) throw
                    new ArgumentOutOfRangeException("La cantidad no puede ser nula");
            var detalleEnCaja = _cajaDto.Detalles
                .FirstOrDefault(d => d.BombonId == bombon.BombonId);
            if (detalleEnCaja == null)
            {
                _cajaDto.Detalles.Add(new DetalleCajaDto
                {
                    BombonId = bombon.BombonId,
                    NombreBombon=bombon.NombreBombon,
                    PrecioBombon=bombon.PrecioBombon,
                    CantidadBombon = cantidad
                });
                return;
            }
            detalleEnCaja.CantidadBombon += cantidad;

        }
        public (IReadOnlyCollection<DetalleCajaDto> Detalles,
            int Cantidad, decimal Precio, bool EsSurtida) ObtenerResumen()
        {
            var detalles = _cajaDto.Detalles.AsReadOnly();
            var cantidad = _cajaDto.Detalles.Sum(d => d.CantidadBombon);
            var precio = Math.Ceiling(_cajaDto.Detalles.Sum(d => d.Subtotal) * 1.2m / 100) * 100;
            var esSurtida = _cajaDto.Detalles.Count() > 1;
            return (detalles, cantidad, precio, esSurtida);
        }

        internal void EliminarBombon(int bombonId)
        {
            if (_cajaDto.Detalles.Count == 1)
            {
                throw new InvalidOperationException("Debe haber al menos un detalle\nEliminación Denegada");
            }
            if (bombonId <= 0) throw
                new ArgumentOutOfRangeException(
                "El ID del bombón no puede ser nulo");
            var detalleEnCaja = _cajaDto.Detalles
                .FirstOrDefault(d => d.BombonId == bombonId);
            if(detalleEnCaja is null)
            {
                throw new InvalidOperationException($"El bombón con ID {bombonId} no se encuentra en el detalle");
            }
            _cajaDto.Detalles.Remove(detalleEnCaja);
        }

        internal void ModificarCantidadBombon(BombonComboDto bombon, int cantidad)
        {
            if(bombon is null)
            {
                throw new ArgumentNullException("El bombón no puede ser nulo");

            }
            if (cantidad <= 0) throw
        new ArgumentOutOfRangeException("La cantidad no puede ser nula");
            var detalleEnCaja = _cajaDto.Detalles
                .FirstOrDefault(d => d.BombonId == bombon.BombonId);
            if(detalleEnCaja is null)
            {
                throw new InvalidOperationException($"El bombón con ID" +
                    $" {bombon.BombonId} no se encuentra en el detalle");

            }
            detalleEnCaja.CantidadBombon = cantidad;
        }

        internal List<DetalleCajaDto> ObtenerDetalles()
        {
            return _cajaDto.Detalles;
        }
    }
}
