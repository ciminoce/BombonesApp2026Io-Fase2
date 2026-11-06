using System.ComponentModel;

namespace BombonesApp2026.Servicios.DTOs.Producto
{
    public class ProductoListDto
    {
        public int ProductoId { get; set; }
        public string TipoProducto { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        [Browsable(false)]
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

    }
}
