using BombonesApp2026.Servicios.DTOs.DetalleVenta;
using BombonesApp2026.Servicios.DTOs.Producto;

namespace BombonesApp2026.Windows
{
    public partial class frmAgregarProductoDetalle : Form
    {
        private List<ProductoListDto>? _listaProductos;
        private BindingSource _bindingSource = new BindingSource();
        private ProductoListDto? _productoSeleccionado;
        private DetalleVentaDto? _detalleVenta;
        public frmAgregarProductoDetalle()
        {
            InitializeComponent();
            dgvDatos.DataSource = _bindingSource;
        }

        internal void SetDatos(List<ProductoListDto>? productosParaVentas)
        {
            _listaProductos = productosParaVentas;
            if (_listaProductos is not null && _listaProductos.Count > 0)
            {
                _bindingSource.DataSource = _listaProductos;
            }
        }


        private void MostrarDatos(ProductoListDto productoDto)
        {
            txtProducto.Text = productoDto.Nombre;
            txtPrecioUnitario.Text = productoDto.Precio.ToString();
            txtPrecioTotal.Text = "0";
            nudCantidad.Maximum = productoDto.Stock;
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (_productoSeleccionado is null) return;
            txtPrecioTotal.Text = (_productoSeleccionado.Precio * nudCantidad.Value).ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                _detalleVenta = new DetalleVentaDto
                {
                    ProductoId = _productoSeleccionado!.ProductoId,
                    Producto = _productoSeleccionado.Nombre,
                    Precio = _productoSeleccionado.Precio,
                    Cantidad = (int)nudCantidad.Value,
                    Stock = _productoSeleccionado.Stock
                };
                DialogResult = DialogResult.OK;
            }
        }
        public DetalleVentaDto? GetDetalleVenta()
        {
            return _detalleVenta;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (_productoSeleccionado is null)
            {
                valido = false;
                errorProvider1.SetError(txtProducto, "Debe seleccionar un producto de la grilla");

            }
            if (decimal.Parse(txtPrecioTotal.Text) <= 0)
            {
                valido = false;
                errorProvider1.SetError(nudCantidad, "Debe comprar al menos 1");
            }
            return valido;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                _productoSeleccionado = null;
                return;
            }
            _productoSeleccionado = _bindingSource[e.RowIndex] as ProductoListDto;
            if (_productoSeleccionado is null) return;
            MostrarDatos(_productoSeleccionado);

        }

    }
}
