using BombonesApp2026.Windows.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace BombonesApp2026.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"{Sesion.UsuarioActual!.UserName}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTiposBombones_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmTiposDeBombones>())
            {
                frm.Text = "Lista de Tipos de Bombones";
                frm.ShowDialog();
            }
        }

        private void btnFormasDePago_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmFormasDePago>())
            {
                frm.Text = "Lista de Formas de Pago";
                frm.ShowDialog();
            }

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmClientes>())
            {
                frm.Text = "Lista de Clientes";
                frm.ShowDialog();
            }

        }

        private void btnBombones_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmBombones>())
            {
                frm.Text = "Listado de Bombones";
                frm.ShowDialog();
            }
        }

        private void btnCajas_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmCajas>())
            {
                frm.Text = "Listado de Cajas";
                frm.ShowDialog();
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmVentas>())
            {
                frm.Text = "Listado de Ventas";
                frm.ShowDialog();
            }

        }
    }
}
