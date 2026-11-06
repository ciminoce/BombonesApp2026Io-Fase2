using BombonesApp2026.Servicios.DTOs.DetalleCaja;

namespace BombonesApp2026.Servicios.DTOs.Caja
{
    public class CajaCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public List<DetalleCajaDto> Detalles { get; set; } = new();
    }
}
