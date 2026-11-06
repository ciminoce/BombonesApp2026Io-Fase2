using System.ComponentModel;

namespace BombonesApp2026.Servicios.DTOs.Bombon
{
    public class BombonListDto
    {
        public int ProductoId { get; set; }
        public string NombreBombon { get; set; } = null!;
        public string TipoBombon { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        [Browsable(false)]
        public bool TieneAzucar { get; set; }
        public string TieneAzucarTexto => TieneAzucar ? "Sí" : "No";
        public bool Activo { get; set; }
    }
}
