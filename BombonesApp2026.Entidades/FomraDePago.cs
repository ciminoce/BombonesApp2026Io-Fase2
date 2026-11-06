namespace BombonesApp2026.Entidades
{
    public class FormaDePago
    {
        private string _nombre = null!;

        public int FormaDePagoId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de la forma de pago no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50) // Ajustar según el tamaño definido en la BD
                {
                    throw new ArgumentException("El nombre de la forma de pago no puede superar los 50 caracteres.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        public bool Activo { get; set; } = true;
        public List<Venta> Ventas { get; set; } = new();
    }
}
