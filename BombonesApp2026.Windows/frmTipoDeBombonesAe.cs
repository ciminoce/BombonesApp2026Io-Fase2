using BombonesApp2026.Servicios.DTOs.TipoBombon;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Helpers;

namespace BombonesApp2026.Windows
{
    public partial class frmTipoDeBombonesAe : Form
    {
        private TipoBombonUpdateDto? _tipoUpdateDto;
        private readonly ITipoBombonServicio _tipoBombonServicio;
        private bool _esEdicion = false;
        private ServicioMensajes _servicioMensajes = new();
        public frmTipoDeBombonesAe(ITipoBombonServicio tipoBombonServicio)
        {
            InitializeComponent();
            _tipoBombonServicio = tipoBombonServicio;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//Agregado para informar de conflicto de concurrencia
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_tipoUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;

            }
            else
            {
                txtTipoBombon.Text = _tipoUpdateDto.Nombre;
                txtDescripcion.Text = _tipoUpdateDto.Descripcion;
                chkActivo.Checked = _tipoUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {

                        var _tipoCreateDto = new TipoBombonCreateDto();
                        _tipoCreateDto.Nombre = txtTipoBombon.Text;
                        _tipoCreateDto.Descripcion = txtDescripcion.Text;
                        var resultadoAgregar = _tipoBombonServicio.Agregar(_tipoCreateDto);
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
                        if (_tipoUpdateDto is null)
                        {
                            _tipoUpdateDto = new TipoBombonUpdateDto();
                        }
                        _tipoUpdateDto.Nombre = txtTipoBombon.Text;
                        _tipoUpdateDto.Descripcion = txtDescripcion.Text;
                        _tipoUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _tipoBombonServicio
                            .Editar(_tipoUpdateDto);
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
            txtTipoBombon.Clear();
            txtDescripcion.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
            txtTipoBombon.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoBombon.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTipoBombon, "El nombre es requerido");

            }
            return valido;
        }

        public void SetTipo(TipoBombonUpdateDto? tipoEditDto)
        {
            _tipoUpdateDto = tipoEditDto;
        }
        public TipoBombonUpdateDto? GetTipo()
        {
            return _tipoUpdateDto;
        }

        private void frmTipoDeBombonesAe_Load(object sender, EventArgs e)
        {

        }
    }
}
