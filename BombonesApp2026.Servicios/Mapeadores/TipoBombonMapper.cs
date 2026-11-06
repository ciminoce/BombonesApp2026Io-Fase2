using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.DTOs.TipoBombon;

namespace BombonesApp2026.Servicios.Mapeadores
{
    public static class TipoBombonMapper
    {

        public static TipoBombonListDto ToListDto(TipoBombon tipoBombon)
        {
            return new TipoBombonListDto
            {
                TipoBombonId = tipoBombon.TipoBombonId,
                Nombre = tipoBombon.Nombre,
                Descripcion = tipoBombon.Descripcion,
                Activo = tipoBombon.Activo,
            };
        }
        public static TipoBombon ToEntidad(TipoBombonCreateDto tipoBombonDto)
        {
            return new TipoBombon
            {
                Nombre = tipoBombonDto.Nombre,
                Descripcion = tipoBombonDto.Descripcion,
                Activo = true
            };
        }
        public static TipoBombon ToEntidad(TipoBombonUpdateDto tipoBombonDto)
        {
            return new TipoBombon
            {
                TipoBombonId = tipoBombonDto.TipoBombonId,
                Nombre = tipoBombonDto.Nombre,
                Descripcion = tipoBombonDto.Descripcion,
                Activo = tipoBombonDto.Activo,
                RowVersion = tipoBombonDto.RowVersion,
            };
        }

        public static TipoBombonUpdateDto ToUpdateDto(TipoBombon tipoBombon)
        {
            return new TipoBombonUpdateDto
            {
                TipoBombonId = tipoBombon.TipoBombonId,
                Nombre = tipoBombon.Nombre,
                Descripcion = tipoBombon.Descripcion,
                Activo = tipoBombon.Activo,
                RowVersion = tipoBombon.RowVersion,
            };
        }

        public static TipoBombonDeleteDto ToDeleteDto(TipoBombon tipoBombon)
        {
            return new TipoBombonDeleteDto
            {
                TipoBombonId = tipoBombon.TipoBombonId,
                RowVersion = tipoBombon.RowVersion,
            };
        }
    }
}
