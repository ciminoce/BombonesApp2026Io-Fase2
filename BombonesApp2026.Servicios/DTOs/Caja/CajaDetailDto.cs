using BombonesApp2026.Servicios.DTOs.DetalleCaja;
using System.ComponentModel;

namespace BombonesApp2026.Servicios.DTOs.Caja
{
    public class CajaDetailDto
    {
        public int ProductoId { get; set; }
        public string NombreCaja { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CantidadBombones { get; set; }
        public int Stock { get; set; }
        public bool EsSurtida { get; set; }
        public bool Activo { get; set; }
        public List<DetalleCajaDto> Detalles { get; set; } = new();
    }
}
