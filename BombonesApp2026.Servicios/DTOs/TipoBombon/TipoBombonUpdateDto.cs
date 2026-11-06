namespace BombonesApp2026.Servicios.DTOs.TipoBombon
{
    //TODO: Agregar clase TipoBombonDeleteDto para manejar los casos de eliminación y evitar problemas de concurrencia
    public class TipoBombonUpdateDto
    {
        public int TipoBombonId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
