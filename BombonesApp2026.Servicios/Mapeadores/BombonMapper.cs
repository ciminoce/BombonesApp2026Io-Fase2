using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.DTOs.Bombon;

namespace BombonesApp2026.Servicios.Mapeadores
{
    public static class BombonMapper
    {
        public static BombonComboDto ToComboDto(this BombonListDto bombonDto)
        {
            return new BombonComboDto
            {
                BombonId = bombonDto.ProductoId,
                NombreBombon = bombonDto.NombreBombon,
                PrecioBombon = bombonDto.Precio,
            };
        }
        public static BombonComboDto ToComboDto(this Bombon bombon)
        {
            return new BombonComboDto
            {
                BombonId = bombon.ProductoId,
                NombreBombon = bombon.Nombre,
                PrecioBombon = bombon.Precio
            };
        }
        public static BombonListDto ToListDto(this Bombon bombon)
        {
            return new BombonListDto
            {
                ProductoId = bombon.ProductoId,
                NombreBombon = bombon.Nombre,
                TipoBombon = bombon.TipoBombon.Nombre,
                Precio = bombon.Precio,
                Stock = bombon.Stock,
                TieneAzucar = bombon.TieneAzucar,
                Activo = bombon.Activo
            };
        }

        public static Bombon ToEntidad(this BombonCreateDto dto)
        {
            return new Bombon
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                TipoBombonId = dto.TipoBombonId,
                Precio = dto.Precio,
                Stock = dto.Stock,
                TieneAzucar = dto.TieneAzucar,
                PesoEnGramos = dto.PesoEnGramos
            };
        }
        public static BombonUpdateDto ToUpdateDto(this Bombon bombon)
        {
            return new BombonUpdateDto
            {
                ProductoId = bombon.ProductoId,
                Nombre = bombon.Nombre,
                Descripcion = bombon.Descripcion,
                TipoBombonId = bombon.TipoBombonId,
                Precio = bombon.Precio,
                Stock = bombon.Stock,
                TieneAzucar = bombon.TieneAzucar,
                PesoEnGramos = bombon.PesoEnGramos,
                Activo = bombon.Activo,
                RowVersion = bombon.RowVersion
            };
        }
        public static BombonDeleteDto ToDeleteDto(this Bombon bombon)
        {
            return new BombonDeleteDto
            {
                ProductoId = bombon.ProductoId,
                RowVersion = bombon.RowVersion,
            };
        }

    }
}
