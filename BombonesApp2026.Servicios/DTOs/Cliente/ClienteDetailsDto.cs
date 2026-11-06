using System;
using System.Collections.Generic;
using System.Text;

namespace BombonesApp2026.Servicios.DTOs.Cliente
{
    public class ClienteDetailsDto
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
