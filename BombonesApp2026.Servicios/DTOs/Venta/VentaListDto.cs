using BombonesApp2026.Entidades.Enums;

namespace BombonesApp2026.Servicios.DTOs.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public DateOnly FechaVenta { get; set; }
        public string Cliente { get; set; } = null!;
        public decimal Total { get; set; }
        public EstadoVenta EstadoVenta { get; set; }
    }
}
