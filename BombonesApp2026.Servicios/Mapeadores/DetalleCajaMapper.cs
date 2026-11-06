using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.DTOs.DetalleCaja;

namespace BombonesApp2026.Servicios.Mapeadores
{
    public static class DetalleCajaMapper
    {
        public static DetalleCajaDto ToDto(this DetalleCaja detalle)
        {
            return new DetalleCajaDto
            {
                BombonId = detalle.BombonId,
                NombreBombon = detalle.Bombon.Nombre,
                PrecioBombon = detalle.Bombon.Precio,
                CantidadBombon = detalle.Cantidad
            };
        }
    }
}
