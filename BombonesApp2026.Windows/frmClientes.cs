using BombonesApp2026.Servicios.DTOs.Cliente;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BombonesApp2026.Windows
{
    public partial class frmClientes : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new();

        //para paginar
        private EstadoNavegacion _estado = new(10);

        //para ordenar
        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        //para filtrar
        private bool? filtroActivo = null;


        public frmClientes(IServiceProvider serviceProvider)
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
            ClienteListDto? clienteListDto = _bindingSource
                .ObtenerSeleccionado<ClienteListDto>(_servicioMensajes);
            if (clienteListDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                var clienteServicio = scope.ServiceProvider
                        .GetRequiredService<IClienteServicio>();
                if(!_servicioMensajes.Confirmar($"¿Desea borrar el cliente {clienteListDto.NombreCompleto}?"))
                {
                    return;
                }
                try
                {
                    var resultadoEliminacion = clienteServicio
                        .Borrar(clienteListDto.ClienteId!);
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
                using (frmClienteAe frm = scope.ServiceProvider
                    .GetRequiredService<frmClienteAe>())
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
            ClienteListDto? clienteListDto = _bindingSource
                .ObtenerSeleccionado<ClienteListDto>(_servicioMensajes);
            if (clienteListDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var clienteServicio = scope.ServiceProvider
                .GetRequiredService<IClienteServicio>();
                    var resultadoConsulta = clienteServicio
                        .ObtenerParaEditar(clienteListDto.ClienteId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    var clienteEditDto = resultadoConsulta.Value;
                    using (frmClienteAe frm = scope.ServiceProvider
                        .GetRequiredService<frmClienteAe>())
                    {
                        frm.Text = "Editar Tipo de Bombón";
                        frm.SetTipo(clienteEditDto);
                        frm.ShowDialog();
                        if (frm.DataChanged)//si cambiaron los datos se recarga la grilla
                        {
                            RecargarGrilla();
                        }

                    }

                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }
        }
        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var clienteServicio = scope.ServiceProvider
                    .GetRequiredService<IClienteServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = clienteServicio
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

                    // Actualizamos cantidad y páginas.
                    _estado.Actualizar(resultado.CantidadRegistros);

                    // Si la página solicitada ya no existe,
                    // Actualizar() habrá corregido PaginaActual.
                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = clienteServicio
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

                        // Actualizamos nuevamente por seguridad.
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

        private void frmClientes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
