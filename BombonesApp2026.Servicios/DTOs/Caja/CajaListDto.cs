using System.ComponentModel;

namespace BombonesApp2026.Servicios.DTOs.Caja
{
    public class CajaListDto
    {
        public int ProductoId { get; set; }
        public string NombreCaja { get; set; } = null!;
        public decimal Precio { get; set; }
        public int CantidadBombones { get; set; }
        public int Stock { get; set; }
        [Browsable(false)]
        public bool EsSurtida { get; set; }
        public string EsSurtidaTexto => EsSurtida ? "Sí" : "No";
        public bool Activo { get; set; }
    }
}
