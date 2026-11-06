using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.DTOs.Bombon;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Helpers;

namespace BombonesApp2026.Windows
{
    public partial class frmBombonAe : Form
    {
        private BombonUpdateDto? _bombonDto;
        private readonly IBombonServicio _bombonServicio;
        private readonly ITipoBombonServicio _tipoServicio;
        private ServicioMensajes _servicioMensajes = new();
        private bool _esEdicion = false;
        public frmBombonAe(IBombonServicio bombonServicio, ITipoBombonServicio tipoServicio)
        {
            InitializeComponent();
            _bombonServicio = bombonServicio;
            _tipoServicio = tipoServicio;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//Agregado para informar de conflicto de concurrencia
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboTipoBombones(cboTipoBombon);
            if (_bombonDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtNombreBombon.Text = _bombonDto.Nombre;
                cboTipoBombon.SelectedValue = _bombonDto.TipoBombonId;
                txtDescripcion.Text = _bombonDto.Descripcion;
                txtPrecio.Text = _bombonDto.Precio.ToString();
                nudPesoEnGramos.Value = _bombonDto.PesoEnGramos;
                nudStock.Value = _bombonDto.Stock;
                chkTieneAzucar.Checked = _bombonDto.TieneAzucar;
                chkActivo.Checked = _bombonDto.Activo;
                _esEdicion = true;

            }
        }

        private void CargarDatosComboTipoBombones(ComboBox cboTipoBombon)
        {
            var resultadoConsulta = _tipoServicio
                .ObtenerDatosCombo(TipoBombonDefault.Seleccione);
            cboTipoBombon.DataSource = resultadoConsulta.Value;
            cboTipoBombon.DisplayMember = "Nombre";
            cboTipoBombon.ValueMember = "TipoBombonId";
            cboTipoBombon.SelectedIndex = 0;
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

                        var bombonCreateDto = new BombonCreateDto();
                        bombonCreateDto.Nombre = txtNombreBombon.Text;
                        bombonCreateDto.Descripcion = txtDescripcion.Text;
                        bombonCreateDto.Precio = decimal.Parse(txtPrecio.Text);
                        bombonCreateDto.TipoBombonId = (int)cboTipoBombon.SelectedValue!;
                        bombonCreateDto.PesoEnGramos = (int)nudPesoEnGramos.Value;
                        bombonCreateDto.Stock = (int)nudStock.Value;
                        bombonCreateDto.TieneAzucar = chkTieneAzucar.Checked;

                        var resultadoAgregar = _bombonServicio.Agregar(bombonCreateDto);
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
                        if (_bombonDto is null)
                        {
                            _bombonDto = new BombonUpdateDto();
                        }
                        _bombonDto.Nombre = txtNombreBombon.Text;
                        _bombonDto.Descripcion = txtDescripcion.Text;
                        _bombonDto.Precio = decimal.Parse(txtPrecio.Text);
                        _bombonDto.TipoBombonId = (int)cboTipoBombon.SelectedValue!;
                        _bombonDto.PesoEnGramos = (int)nudPesoEnGramos.Value;
                        _bombonDto.Stock = (int)nudStock.Value;
                        _bombonDto.TieneAzucar = chkTieneAzucar.Checked;
                        _bombonDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _bombonServicio
                            .Editar(_bombonDto);
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
            txtNombreBombon.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            nudPesoEnGramos.Value = 0;
            nudStock.Value = 0;
            chkTieneAzucar.Checked = false;
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
            cboTipoBombon.SelectedIndex = 0;
            txtNombreBombon.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtNombreBombon.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreBombon, "El nombre es requerido");
            }
            else if (txtNombreBombon.Text.Length > 100)
            {
                valido = false;
                errorProvider1.SetError(txtNombreBombon, "El nombre debe tener no más de 100 caracteres");
            }
            if (txtDescripcion.Text.Length > 250)
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "La descripción no puede tener más de 250 caracteres");
            }
            if (cboTipoBombon.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoBombon, "Debe seleccionar un tipo de bombón");
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtPrecio, "Precio no válido o fuera de rango");
            }
            return valido;
        }

        public void SetBombon(BombonUpdateDto? bombonDto)
        {
            _bombonDto = bombonDto;
        }
        public BombonUpdateDto? GetBombon()
        {
            return _bombonDto;
        }

    }
}
