using BombonesApp2026.Entidades.Interfaces;

namespace BombonesApp2026.Entidades
{
    public abstract class Producto:IConcurrencyEntity
    {
        private string _nombre = null!;
        private string? _descripcion;
        private int _stock;

        public int ProductoId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del producto no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 100)
                {
                    throw new ArgumentException("El nombre del producto no puede superar los 100 caracteres.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        public string? Descripcion
        {
            get => _descripcion;
            set
            {
                if (value != null && value.Trim().Length > 250)
                {
                    throw new ArgumentException("La descripción no puede superar los 250 caracteres.", nameof(value));
                }

                _descripcion = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }


        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El stock no puede ser negativo.");
                }

                _stock = value;
            }
        }

        public bool Activo { get; set; } = true;
        public byte[] RowVersion { get; set; } = null!;
        protected Producto()
        {
            
        }
        protected Producto(string nombre, int stock,string? descripcion)
        {
            // Las asignaciones invocan los 'setters' correspondientes y sus validaciones
            Nombre = nombre;
            Stock = stock;
            Descripcion = descripcion;
        }

        public abstract string MostrarDatos();
        public List<DetalleVenta> DetalleVentas { get; set; } = new();
    }
}
