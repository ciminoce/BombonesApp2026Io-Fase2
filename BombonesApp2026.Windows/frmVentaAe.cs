using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.DTOs.Cliente;
using BombonesApp2026.Servicios.DTOs.DetalleVenta;
using BombonesApp2026.Servicios.DTOs.FormaDePago;
using BombonesApp2026.Servicios.DTOs.Producto;
using BombonesApp2026.Servicios.DTOs.Venta;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Classes;
using BombonesApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BombonesApp2026.Windows
{
    public partial class frmVentaAe : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProductoServicio _productoServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IFormaDePagoServicio _formaDePagoServicio;
        private ServicioMensajes _servicioMensajes = new();
        private VentaCreateDto? _ventaDto;
        private EditorVenta _editorVenta = null!;
        private List<ProductoListDto>? _productosParaVentas;
        private BindingSource _bindingSource = new BindingSource();

        public bool DataChanged { get; private set; }

        public frmVentaAe(IServiceProvider serviceProvider,
            IProductoServicio productoServicio,
            IClienteServicio clienteServicio,
            IFormaDePagoServicio formaDePagoServicio)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _productoServicio = productoServicio;
            _clienteServicio = clienteServicio;
            _formaDePagoServicio = formaDePagoServicio;
            dgvDatos.DataSource = _bindingSource;
        }

        internal VentaCreateDto? GetVenta()
        {
            return _ventaDto;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            using (frmAgregarProductoDetalle frm = _serviceProvider
                .GetRequiredService<frmAgregarProductoDetalle>())
            {
                frm.Text = "Agregar Producto";
                frm.SetDatos(_productosParaVentas);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                DetalleVentaDto? detalleDto = frm.GetDetalleVenta();
                if (detalleDto is null) return;
                try
                {
                    _editorVenta.AgregarProducto(detalleDto);
                    MostrarDetalles(_editorVenta.ObtenerResumen());
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void MostrarDetalles((IReadOnlyCollection<DetalleVentaDto> Detalles,
            decimal Total) resumen)
        {
            _bindingSource.DataSource = resumen.Detalles.ToList();
            _bindingSource.ResetBindings(false);
            txtTotal.Text = resumen.Total.ToString();
        }

        private void frmVentaAe_Load(object sender, EventArgs e)
        {
            try
            {
                _ventaDto = new VentaCreateDto();
                _editorVenta = new EditorVenta(_ventaDto);

                var resultadoConsulta = _productoServicio.ObtenerTodos();
                if (resultadoConsulta.IsFailure)
                {
                    _servicioMensajes.Errores(resultadoConsulta.Errors);
                    Close();
                }
                _productosParaVentas = resultadoConsulta.Value;
                CargarComboClientes(cboClientes);
                CargarComboFormasDePago(cboFormasDePago);
                txtFechaVta.Text = DateTime.Today.ToShortDateString();
                txtEstado.Text = EstadoVenta.Pendiente.ToString();

            }
            catch (Exception ex)
            {

                _servicioMensajes.Error(ex.Message);
            }
        }

        private void CargarComboFormasDePago(ComboBox cbo)
        {
            var resultado = _formaDePagoServicio
                .ObtenerDatosCombo(FormaDePagoDefault.Seleccione);
            if (resultado.IsFailure)
            {
                _servicioMensajes.Errores(resultado.Errors);
                return;

            }
            cbo.DataSource = resultado.Value;
            cbo.DisplayMember = "Nombre";
            cbo.ValueMember = "FormaDePagoId";
            cbo.SelectedIndex = 0;
        }

        private void CargarComboClientes(ComboBox cbo)
        {
            var resultado = _clienteServicio
                .ObtenerDatosCombo(ClienteDefault.Seleccione);
            if (resultado.IsFailure)
            {
                _servicioMensajes.Errores(resultado.Errors);
                return;
            }
            cbo.DataSource = resultado.Value;
            cbo.DisplayMember = "NombreCompleto";
            cbo.ValueMember = "ClienteId";
            cbo.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                _ventaDto!.ClienteId = ((ClienteListDto)cboClientes.SelectedItem!).ClienteId;
                _ventaDto.FormaDePagoId = ((FormaDePagoListDto)cboFormasDePago.SelectedItem!).FormaDePagoId;
                _ventaDto.Detalle = _editorVenta.ObtenerDetalles();
                _ventaDto.Total = _editorVenta.ObtenerResumen().Total;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboClientes.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboClientes, "Debe seleccionar un cliente");
                valido = false;
            }
            if (cboFormasDePago.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboFormasDePago, "Debe seleccionar una forma de pago");
                valido = false;
            }
            if (dgvDatos.Rows.Count == 0)
            {
                errorProvider1.SetError(dgvDatos, "Debe agregar al menos un producto");
                valido = false;
            }
            return valido;
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex > 0)
            {
                var clienteSeleccionado = (ClienteListDto)cboClientes.SelectedItem!;
                MostrarDatosCliente(clienteSeleccionado);
            }
        }

        private void MostrarDatosCliente(ClienteListDto clienteSeleccionado)
        {
            txtDireccion.Text = clienteSeleccionado.Direccion;
            txtCiudad.Text = clienteSeleccionado.Localidad;
            txtProvincia.Text = clienteSeleccionado.Provincia;
        }

        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            var detalleDto = _bindingSource.ObtenerSeleccionado<DetalleVentaDto>(_servicioMensajes);
            if (detalleDto is null) return;
            if (!_servicioMensajes
                    .Confirmar($"¿Desea eliminar el detalle de {detalleDto.Producto}?")) return;
            try
            {
                _editorVenta.EliminarProducto(detalleDto.ProductoId);
                MostrarDetalles(_editorVenta.ObtenerResumen());
            }
            catch (Exception ex)
            {

                _servicioMensajes.Error(ex.Message);
            }
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            // 1. Obtener el detalle seleccionado de la grilla
            var detalleDto = _bindingSource.ObtenerSeleccionado<DetalleVentaDto>(_servicioMensajes);
            if (detalleDto is null) return;
            // 2. Mostrar el InputBox de Visual Basic
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Ingrese la nueva cantidad para el producto '{detalleDto.Producto}':\n(Stock disponible: {detalleDto.Stock})",
                "Modificar Cantidad",
                detalleDto.Cantidad.ToString() // Valor por defecto (la cantidad actual en el carrito)
            );

            // Si el usuario canceló o dejó el cuadro vacío, no hacemos nada
            if (string.IsNullOrWhiteSpace(input)) return;

            // 3. Validar que sea un número entero válido
            if (!int.TryParse(input, out int nuevaCantidad))
            {
                _servicioMensajes.Error("Debe ingresar un número entero válido.", "Error de formato");
                return;
            }

            // 4. Validar cantidad mayor a 0 
            if (nuevaCantidad <= 0)
            {
                _servicioMensajes.Error("La cantidad debe ser mayor a cero.",
                    "Validación");
                return;
            }
            //Validar cantidad menor o igual al stock disponible
            if (nuevaCantidad > detalleDto.Stock)
            {
                _servicioMensajes.Advertencia($"La cantidad ingresada supera el stock disponible ({detalleDto.Stock}).", "Stock Insuficiente");
                return;
            }

            // 5. Actualizar en el editor de ventas y refrescar la grilla
            try
            {
                _editorVenta.ModificarCantidadDetalle(detalleDto.ProductoId, nuevaCantidad);
                MostrarDetalles(_editorVenta.ObtenerResumen());
            }
            catch (Exception ex)
            {
                _servicioMensajes.Error(ex.Message, "Error al actualizar");
            }

        }
    }
}
