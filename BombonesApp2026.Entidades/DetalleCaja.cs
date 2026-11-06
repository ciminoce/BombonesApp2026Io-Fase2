namespace BombonesApp2026.Entidades
{
    public class DetalleCaja
    {
        public int CajaId { get; set; }
        public Caja Caja { get; set; } = null!;
        public int BombonId { get; set; }
        public Bombon Bombon { get; set; } = null!;
        public int Cantidad
        {
            get => _cantidad; set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Cantidad),
                        "La cantidad debe ser mayor a cero");
                }
                _cantidad = value;
            }
        }

        private int _cantidad;
        public decimal Subtotal => Bombon?.Precio??0m* Cantidad;
        public DetalleCaja()
        {
            
        }
        public DetalleCaja(int cajaId, int bombonId, int cantidad)
        {
            CajaId= cajaId;
            BombonId= bombonId;
            Cantidad = cantidad;
        }
    }
}
