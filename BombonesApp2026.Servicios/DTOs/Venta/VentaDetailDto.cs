using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.DTOs.DetalleVenta;

namespace BombonesApp2026.Servicios.DTOs.Venta
{
    public class VentaDetailDto
    {
        public int VentaId { get; set; }
        public DateOnly FechaVenta { get; set; }
        public string Cliente { get; set; } = null!;
        public decimal Total { get; set; }
        public string FormaDePago { get; set; } = null!;
        public EstadoVenta EstadoVenta { get; set; }

        public List<DetalleVentaDto> DetalleVentas { get; set; } = new();
    }
}
