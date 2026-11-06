namespace BombonesApp2026.Servicios.DTOs.TipoBombon
{
    public class TipoBombonListDto
    {
        public int TipoBombonId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
