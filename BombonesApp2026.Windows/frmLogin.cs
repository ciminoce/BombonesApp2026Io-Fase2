using BombonesApp2026.Entidades;
using BombonesApp2026.Windows.Classes;
using BombonesApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BombonesApp2026.Windows
{
    public partial class frmLogin : Form
    {
        private readonly IServiceProvider _provider;
        private ServicioMensajes _servicioMensajes = new();
        public frmLogin(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //_servicioMensajes.Informacion("Fin de la Aplicación", "Salida",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Usuario? usuario = UsuariosSistema.Usuarios
                    .FirstOrDefault(u => u.UserName == txtUsuario.Text &&
                        u.Password == txtClave.Text);
                if (usuario is null)
                {
                    _servicioMensajes.Advertencia("Usuario inexistente o datos no válidos");
                    txtUsuario.SelectAll();
                    txtUsuario.Select();
                    return;
                }
                Sesion.UsuarioActual=usuario;
                this.Hide();
                frmPrincipal frm=_provider.GetRequiredService<frmPrincipal>();
                frm.ShowDialog();
                InicializarControles();
                this.Show();
            }
        }

        private void InicializarControles()
        {
            txtClave.Clear();
            txtUsuario.Clear();
            txtUsuario.Select();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                valido = false;
                errorProvider1.SetError(txtUsuario, "El usuario es requerido");
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                valido = false;
                errorProvider1.SetError(txtClave, "La clave es requerida");
            }
            return valido;
        }
    }
}
