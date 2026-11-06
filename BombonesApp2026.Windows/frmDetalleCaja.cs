using BombonesApp2026.Servicios.DTOs.Caja;

namespace BombonesApp2026.Windows
{
    public partial class frmDetalleCaja : Form
    {
        private CajaDetailDto _cajaDto = null!;
        private BindingSource _bindingSource = new BindingSource();
        public frmDetalleCaja()
        {
            InitializeComponent();
            dgvDatos.DataSource= _bindingSource;
        }

        public void SetCaja(CajaDetailDto cajaDto)
        {
            _cajaDto = cajaDto;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDetalleCaja_Load(object sender, EventArgs e)
        {
            MostraDatos(_cajaDto);
        }

        private void MostraDatos(CajaDetailDto cajaDto)
        {
            txtNombreCaja.Text = cajaDto.NombreCaja;
            txtCantidadBombones.Text = cajaDto.CantidadBombones.ToString();
            txtSurtida.Text = cajaDto.EsSurtida ? "Sí" : "No";
            txtPrecio.Text = cajaDto.Precio.ToString();
            txtStock.Text = cajaDto.Stock.ToString();
            txtDescripcion.Text = cajaDto.Descripcion;
            chkActivo.Checked = cajaDto.Activo;
            _bindingSource.DataSource = cajaDto.Detalles;
        }
    }
}
