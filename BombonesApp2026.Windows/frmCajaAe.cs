using BombonesApp2026.Servicios.DTOs.Caja;
using BombonesApp2026.Servicios.DTOs.DetalleCaja;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Servicios.Mapeadores;
using BombonesApp2026.Windows.Classes;
using BombonesApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BombonesApp2026.Windows
{
    public partial class frmCajaAe : Form
    {
        private CajaUpdateDto? _cajaDto;
        private EditorCaja _editorCaja = null!;
        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new();
        private readonly ICajaServicio _cajaServicio;
        private readonly IBombonServicio _bombonServicio;
        private readonly IServiceProvider _serviceProvider;
        private bool _esEdicion = false;

        public frmCajaAe(ICajaServicio cajaServicio,
            IBombonServicio bombonServicio,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _cajaServicio = cajaServicio;
            _bombonServicio = bombonServicio;
            _serviceProvider = serviceProvider;
            dgvDatos.DataSource = _bindingSource;

        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//Agregado para informar de conflicto de concurrencia
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_cajaDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
                InicializarEditor();
            }
            else
            {
                txtNombreCaja.Text = _cajaDto.Nombre;
                txtDescripcion.Text = _cajaDto.Descripcion;
                chkActivo.Checked = _cajaDto.Activo;
                nudStock.Value=_cajaDto.Stock;
                _bindingSource.DataSource = _cajaDto.Detalles;
                CalcularYMostrarDatos(_cajaDto.Detalles);
                _esEdicion = true;

            }
        }

        private void CalcularYMostrarDatos(List<DetalleCajaDto> detalles)
        {
            txtCantidadBombones.Text = detalles.Sum(d => d.CantidadBombon).ToString();
            txtSurtida.Text = detalles.Count > 1 ? "Sí" : "No";
            txtPrecio.Text = (Math.Ceiling(detalles.Sum(d => d.Subtotal) * 1.2m / 100) * 100).ToString();
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

                        
                        _cajaDto!.Nombre = txtNombreCaja.Text;
                        _cajaDto.Descripcion = txtDescripcion.Text;
                        _cajaDto.Stock = (int)nudStock.Value;
                        _cajaDto.Detalles = _editorCaja.ObtenerDetalles();

                        CajaCreateDto cajaCreateDto = _cajaDto.ToCreateDto();

                        var resultadoAgregar = _cajaServicio.Agregar(cajaCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        UltimoId = resultadoAgregar.Value;
                        if(_servicioMensajes.Confirmar("Registro agregado\n¿Desea agregar otro?"))
                        {
                            InicializarControles();
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }

                    }
                    else
                    {
                        if (_cajaDto is null)
                        {
                            _cajaDto = new CajaUpdateDto();
                        }
                        _cajaDto.Nombre = txtNombreCaja.Text;
                        _cajaDto.Descripcion = txtDescripcion.Text;
                        _cajaDto.Activo = chkActivo.Checked;
                        _cajaDto.Stock = (int)nudStock.Value;
                        _cajaDto.Detalles = _editorCaja.ObtenerDetalles();

                        var resultadoEditar = _cajaServicio
                            .Editar(_cajaDto);
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
            txtNombreCaja.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            nudStock.Value = 0;
            txtCantidadBombones.Clear();
            txtSurtida.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
            txtNombreCaja.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtNombreCaja.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreCaja, "El nombre es requerido");
            }

            return valido;
        }

        public CajaUpdateDto? GetCaja()
        {
            return _cajaDto;
        }

        internal void SetCaja(CajaUpdateDto cajaDto)
        {
            _cajaDto = cajaDto;
            _editorCaja = new EditorCaja(cajaDto);
        }
        public void InicializarEditor()
        {
            _cajaDto = new CajaUpdateDto();
            _editorCaja = new EditorCaja(_cajaDto);
        }
        private void btnAgregarBombon_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmManejoBombonCajaAe>())
            {
                frm.Text = "Nuevo Detalle";
                if (frm.ShowDialog() == DialogResult.Cancel) return;
                var (bombon, cantidad) = frm.GetDatos();
                if (bombon is null) return;
                try
                {
                    _editorCaja.AgregarBombon(bombon, cantidad);
                    MostrarDatos(_editorCaja.ObtenerResumen());
                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void MostrarDatos((IReadOnlyCollection<DetalleCajaDto> Detalles,
            int Cantidad, decimal Precio, bool EsSurtida) resumen)
        {
            txtPrecio.Text = resumen.Precio.ToString();
            txtCantidadBombones.Text = resumen.Cantidad.ToString();
            txtSurtida.Text = resumen.EsSurtida ? "Si" : "No";
            _bindingSource.DataSource = resumen.Detalles.ToList();
            _bindingSource.ResetBindings(false);

        }

        private void btnEliminarBombon_Click(object sender, EventArgs e)
        {
            var detalleDto = _bindingSource
                .ObtenerSeleccionado<DetalleCajaDto>(_servicioMensajes);
            if (detalleDto is null) return;
            if (_servicioMensajes.Confirmar($"¿Desea borrar el detalle" +
                $" del bombón {detalleDto.NombreBombon}?"))
            {
                try
                {
                    _editorCaja.EliminarBombon(detalleDto.BombonId);
                    MostrarDatos(_editorCaja.ObtenerResumen());
                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }

            }
        }

        private void btnEditarBombon_Click(object sender, EventArgs e)
        {
            var detalleDto = _bindingSource
                .ObtenerSeleccionado<DetalleCajaDto>(_servicioMensajes);
            if (detalleDto is null) return;
            var resultadoConsulta = _bombonServicio
                .ObtenerPorId(detalleDto.BombonId);
            if (resultadoConsulta.IsFailure)
            {
                _servicioMensajes.Errores(resultadoConsulta.Errors);
                return;
            }
            var bombonListDto = resultadoConsulta.Value;
            if(bombonListDto is null) return;
            var bombonComboDto = bombonListDto.ToComboDto();
            using (var frm=_serviceProvider
                .GetRequiredService<frmManejoBombonCajaAe>())
            {
                frm.Text = "Modificar Cantidad del Bombón";
                frm.SetDatos(bombonComboDto, detalleDto.CantidadBombon);
                if (frm.ShowDialog() == DialogResult.Cancel) return;
                var (bombon, cantidad) = frm.GetDatos();
                if (bombon is null) return;
                try
                {
                    _editorCaja.ModificarCantidadBombon(bombon, cantidad);
                    MostrarDatos(_editorCaja.ObtenerResumen());
                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }
        }
    }
}
