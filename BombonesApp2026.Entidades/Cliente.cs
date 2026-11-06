using BombonesApp2026.Entidades.Interfaces;
using System.Text.RegularExpressions;

namespace BombonesApp2026.Entidades
{
    public class Cliente : IConcurrencyEntity
    {
        private string _nombre = null!;
        private string _apellido = null!;
        private string _documento = null!;
        private string? _telefono;
        private string? _email;
        private string? _calle;
        private string? _numero;
        private string? _localidad;
        private string? _provincia;
        private string? _codigoPostal;

        public int ClienteId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El nombre no puede superar los 50 caracteres.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El apellido no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El apellido no puede superar los 50 caracteres.", nameof(value));
                }

                _apellido = value.Trim();
            }
        }

        public string Documento
        {
            get => _documento;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El documento no puede estar vacío ni ser nulo.", nameof(value));
                }

                string docLimpio = value.Trim();

                if (docLimpio.Length < 7 || docLimpio.Length > 20)
                {
                    throw new ArgumentException("El documento debe tener entre 7 y 20 caracteres.", nameof(value));
                }

                _documento = docLimpio;
            }
        }

        public string? Telefono
        {
            get => _telefono;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _telefono = null;
                    return;
                }

                string tel = value.Trim();

                if (tel.Length > 30)
                {
                    throw new ArgumentException("El teléfono no puede superar los 30 caracteres.", nameof(value));
                }

                _telefono = tel;
            }
        }

        public string? Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _email = null;
                    return;
                }

                string emailLimpio = value.Trim();

                if (emailLimpio.Length > 100)
                {
                    throw new ArgumentException("El email no puede superar los 100 caracteres.", nameof(value));
                }

                // Validar formato básico de email
                if (!Regex.IsMatch(emailLimpio, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new ArgumentException("El formato del email no es válido.", nameof(value));
                }

                _email = emailLimpio;
            }
        }

        public string? Calle
        {
            get => _calle;
            set
            {
                if (value != null && value.Trim().Length > 100)
                {
                    throw new ArgumentException("La calle no puede superar los 100 caracteres.", nameof(value));
                }

                _calle = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public string? Numero
        {
            get => _numero;
            set
            {
                if (value != null && value.Trim().Length > 20)
                {
                    throw new ArgumentException("El número de dirección no puede superar los 20 caracteres.", nameof(value));
                }

                _numero = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public string? Localidad
        {
            get => _localidad;
            set
            {
                if (value != null && value.Trim().Length > 100)
                {
                    throw new ArgumentException("La localidad no puede superar los 100 caracteres.", nameof(value));
                }

                _localidad = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public string? Provincia
        {
            get => _provincia;
            set
            {
                if (value != null && value.Trim().Length > 100)
                {
                    throw new ArgumentException("La provincia no puede superar los 100 caracteres.", nameof(value));
                }

                _provincia = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public string? CodigoPostal
        {
            get => _codigoPostal;
            set
            {
                if (value != null && value.Trim().Length > 10)
                {
                    throw new ArgumentException("El código postal no puede superar los 10 caracteres.", nameof(value));
                }

                _codigoPostal = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;
        public List<Venta> Ventas { get; set; } = new();
    }
}
