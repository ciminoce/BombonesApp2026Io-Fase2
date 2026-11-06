namespace BombonesApp2026.Entidades
{
    public class Usuario
    {
        private string _userName = null!;
        private string _password = null!;

        public string UserName
        {
            get => _userName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de usuario no puede estar vacío ni ser nulo.", nameof(value));
                }

                string userLimpio = value.Trim();

                if (userLimpio.Length < 3 || userLimpio.Length > 30)
                {
                    throw new ArgumentException("El nombre de usuario debe tener entre 3 y 30 caracteres.", nameof(value));
                }

                _userName = userLimpio;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La contraseña no puede estar vacía ni ser nula.", nameof(value));
                }

                if (value.Length < 6 || value.Length > 100)
                {
                    throw new ArgumentException("La contraseña debe tener entre 6 y 100 caracteres.", nameof(value));
                }

                // Nota: En la contraseña no se aplica Trim() para respetar espacios intencionales si existieran
                _password = value;
            }
        }
    }
}
