namespace BombonesApp2026.Servicios.DTOs.TipoBombon
{
    public class TipoBombonCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
