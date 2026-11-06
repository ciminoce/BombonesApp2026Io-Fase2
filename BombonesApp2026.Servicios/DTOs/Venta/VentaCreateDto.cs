using BombonesApp2026.Servicios.DTOs.DetalleVenta;

namespace BombonesApp2026.Servicios.DTOs.Venta
{
    public class VentaCreateDto
    {
        public int ClienteId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int FormaDePagoId { get; set; }
        public decimal Total { get; set; }
        public List<DetalleVentaDto> Detalle { get; set; } = new();

    }
}
