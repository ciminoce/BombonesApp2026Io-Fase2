using BombonesApp2026.Servicios.DTOs.Cliente;
using BombonesApp2026.Servicios.DTOs.TipoBombon;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Helpers;

namespace BombonesApp2026.Windows
{
    public partial class frmClienteAe : Form
    {
        private readonly IClienteServicio _clienteServicio;
        private ServicioMensajes _servicioMensajes = new();
        private ClienteUpdateDto? _clienteUpdateDto;
        public frmClienteAe(IClienteServicio clienteServicio)
        {
            InitializeComponent();
            _clienteServicio = clienteServicio;
        }


        public void SetTipo(ClienteUpdateDto? clienteEditDto)
        {
            _clienteUpdateDto = clienteEditDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool _esEdicion = false;
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//Agregado para informar de conflicto de concurrencia
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_clienteUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;

            }
            else
            {
                txtNombre.Text = _clienteUpdateDto.Nombre;
                txtApellido.Text = _clienteUpdateDto.Apellido;
                txtDocumento.Text = _clienteUpdateDto.Documento;
                txtEmail.Text = _clienteUpdateDto.Email;
                txtLocalidad.Text = _clienteUpdateDto.Localidad;
                txtProvincia.Text = _clienteUpdateDto.Provincia;
                chkActivo.Checked = _clienteUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {

                        var _clienteCreateDto = new ClienteCreateDto();
                        _clienteCreateDto.Nombre = txtNombre.Text;
                        _clienteCreateDto.Apellido = txtApellido.Text;
                        var resultadoAgregar = _clienteServicio.Agregar(_clienteCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        UltimoId = resultadoAgregar.Value;
                        if(!_servicioMensajes.Confirmar("Registro agregado\n¿Desea agregar otro?"))
                        { 
                            DialogResult = DialogResult.OK;
                        }
                        InicializarControles();

                    }
                    else
                    {
                        if (_clienteUpdateDto is null)
                        {
                            _clienteUpdateDto = new ClienteUpdateDto();
                        }
                        _clienteUpdateDto.Nombre = txtNombre.Text;
                        _clienteUpdateDto.Apellido = txtApellido.Text;
                        _clienteUpdateDto.Documento = txtDocumento.Text;
                        _clienteUpdateDto.Calle = txtCalle.Text;
                        _clienteUpdateDto.Numero = txtNumero.Text;
                        _clienteUpdateDto.Localidad = txtLocalidad.Text;
                        _clienteUpdateDto.Provincia = txtProvincia.Text;
                        _clienteUpdateDto.Telefono = txtTelefono.Text;
                        _clienteUpdateDto.Email = txtEmail.Text;
                        _clienteUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _clienteServicio
                            .Editar(_clienteUpdateDto);
                        if (resultadoEditar.IsConcurrencyConflict)
                        {
                            _servicioMensajes.Errores(resultadoEditar.Errors);

                            ConcurrencyConflict = true;
                            DialogResult = DialogResult.Cancel;

                            Close();
                            return;
                        }
                        if (resultadoEditar.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoEditar.Errors);
                            return;
                        }
                        DataChanged = true;
                        _servicioMensajes.Informacion("Registro editado satisfactoriamente");
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void InicializarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtLocalidad.Clear();
            txtProvincia.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "El nombre es requerido");

            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "El apellido es requerido");

            }

            if (string.IsNullOrEmpty(txtDocumento.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDocumento, "El documento es requerido");

            }

            return valido;
        }

    }
}
