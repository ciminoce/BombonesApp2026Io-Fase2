using BombonesApp2026.Entidades.Interfaces;

namespace BombonesApp2026.Entidades
{
    public class TipoBombon : IConcurrencyEntity
    {
        private string _nombre = null!;
        private string? _descripcion;

        public int TipoBombonId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del tipo de bombón no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50) // Ajustar el límite de caracteres según la BD
                {
                    throw new ArgumentException("El nombre del tipo de bombón no puede superar los 50 caracteres.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        public string? Descripcion
        {
            get => _descripcion;
            set
            {
                if (value != null && value.Trim().Length > 150) // Ajustar el límite de caracteres según la BD
                {
                    throw new ArgumentException("La descripción no puede superar los 150 caracteres.", nameof(value));
                }

                _descripcion = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;
    }
}
