using System.ComponentModel;

namespace BombonesApp2026.Servicios.DTOs.DetalleVenta
{
    public class DetalleVentaDto
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        [Browsable(false)]
        public int Stock { get; set; }//Agregado para el control cuando se modifica la cantidad
        public decimal Subtotal => Precio * Cantidad;

    }
}
