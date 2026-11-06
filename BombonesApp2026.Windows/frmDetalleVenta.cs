using BombonesApp2026.Servicios.DTOs.Venta;

namespace BombonesApp2026.Windows
{
    public partial class frmDetalleVenta : Form
    {
        private VentaDetailDto _ventaDto = null!;
        private BindingSource _bindingSource = new BindingSource();
        public frmDetalleVenta()
        {
            InitializeComponent();
            dgvDatos.DataSource = _bindingSource;
        }

        internal void SetVenta(VentaDetailDto ventaDetailDto)
        {
            _ventaDto = ventaDetailDto;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            txtVentaId.Text = _ventaDto.VentaId.ToString();
            txtCliente.Text = _ventaDto.Cliente;
            txtEstado.Text = _ventaDto.EstadoVenta.ToString();
            txtFechaVta.Text = _ventaDto.FechaVenta.ToShortDateString();
            txtFormaDePago.Text = _ventaDto.FormaDePago;
            txtPrecio.Text = _ventaDto.Total.ToString();
            _bindingSource.DataSource = _ventaDto.DetalleVentas;

        }
    }
}
