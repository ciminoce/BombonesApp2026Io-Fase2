using System.ComponentModel;

namespace BombonesApp2026.Servicios.DTOs.Cliente
{
    public class ClienteListDto
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        [Browsable(false)]
        public string? Direccion { get; set; }
        [Browsable(false)]

        public string? Localidad { get; set; }
        [Browsable(false)]

        public string? Provincia { get; set; }
        public bool Activo { get; set; }

    }
}
