using BombonesApp2026.Servicios.DTOs.FormaDePago;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BombonesApp2026.Windows
{
    public partial class frmFormasDePago : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource = new BindingSource();

        //para paginar
        private EstadoNavegacion _estado = new(10);

        //para ordenar
        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        //para filtrar
        private bool? filtroActivo = null;
        private ServicioMensajes _servicioMensajes = new();

        public frmFormasDePago(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            FormaDePagoListDto? formaListDto = _bindingSource
                .ObtenerSeleccionado<FormaDePagoListDto>(_servicioMensajes);
            if (formaListDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                var formaDePagoServicio = scope.ServiceProvider
                        .GetRequiredService<IFormaDePagoServicio>();
                if(!_servicioMensajes.Confirmar($"¿Desea borrar la forma de pago" +
                    $" {formaListDto.Nombre}?"))
                {
                    return;
                }
                try
                {
                    var resultadoEliminacion = formaDePagoServicio
                        .Borrar(formaListDto.FormaDePagoId!);
                    if (resultadoEliminacion.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoEliminacion.Errors);
                        return;

                    }
                    _servicioMensajes.Informacion("Registro eliminado satisfactoriamente");
                    RecargarGrilla();
                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmFormaDePagoAe frm = scope.ServiceProvider
                    .GetRequiredService<frmFormaDePagoAe>())
                {
                    frm.Text = "Nuevo Tipo de Bombón";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        RecargarGrilla();
                    }

                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            FormaDePagoListDto? formaListDto = _bindingSource
                .ObtenerSeleccionado<FormaDePagoListDto>(_servicioMensajes);
            if (formaListDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var formaDePagoServicio = scope.ServiceProvider
                .GetRequiredService<IFormaDePagoServicio>();
                    var resultadoConsulta = formaDePagoServicio
                        .ObtenerParaEditar(formaListDto.FormaDePagoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    var formaEditDto = resultadoConsulta.Value;
                    using (frmFormaDePagoAe frm = scope.ServiceProvider
                        .GetRequiredService<frmFormaDePagoAe>())
                    {
                        frm.Text = "Editar Tipo de Bombón";
                        frm.SetTipo(formaEditDto);
                        frm.ShowDialog();
                        if (frm.DataChanged)//si cambiaron los datos se recarga la grilla
                        {
                            RecargarGrilla();
                        }

                    }

                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message, "Error");
                }
            }
        }
        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var formaDePagoServicio = scope.ServiceProvider
                    .GetRequiredService<IFormaDePagoServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = formaDePagoServicio
                        .ObtenerPaginado(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroActivo);

                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;

                    _estado.Actualizar(resultado.CantidadRegistros);

                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = formaDePagoServicio
                            .ObtenerPaginado(
                                _estado.PaginaActual,
                                _estado.RegistrosPorPagina,
                                campoOrdenar,
                                esAscendente,
                                filtroActivo);

                        if (resultadoConsulta.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoConsulta.Errors);
                            return;
                        }

                        resultado = resultadoConsulta.Value!;

                        _estado.Actualizar(resultado.CantidadRegistros);
                    }

                    _bindingSource.DataSource = resultado.Items;

                    lblCantidad.Text = _estado.TextoRegistros();
                    lblPaginas.Text = _estado.TextoPaginas();

                    btnPrimero.Enabled = _estado.PuedeIrAnterior();
                    btnAnterior.Enabled = _estado.PuedeIrAnterior();
                    btnSiguiente.Enabled = _estado.PuedeIrSiguiente();
                    btnUltimo.Enabled = _estado.PuedeIrSiguiente();
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }
        private void frmFormasDePago_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = Color.Orange;
            RecargarGrilla();


        }


        private void noActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = Color.Orange;
            RecargarGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroActivo = null;
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = SystemColors.Control;
            RecargarGrilla();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            _estado.PrimeraPagina();
            RecargarGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _estado.PaginaAnterior();
            RecargarGrilla();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _estado.PaginaSiguiente();
            RecargarGrilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _estado.UltimaPagina();
            RecargarGrilla();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
