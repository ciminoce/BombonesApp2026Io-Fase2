namespace BombonesApp2026.Servicios.DTOs.Caja
{
    public class CajaDeleteDto
    {
        public int ProductoId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
