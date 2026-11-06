using BombonesApp2026.Servicios.DTOs.Caja;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace BombonesApp2026.Windows
{
    public partial class frmCajas : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();
        //para paginar
        private EstadoNavegacion _estado = new(10);
        //para ordenar
        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        //para filtrar
        private bool? filtroActivo = null;
        private string? textoBuscar = null;
        public frmCajas(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.DataSource = _bindingSource;

        }


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCajas_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var cajaServicio = scope.ServiceProvider
                    .GetRequiredService<ICajaServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = cajaServicio
                        .ObtenerPaginado(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroActivo,
                            textoBuscar);

                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;

                    _estado.Actualizar(resultado.CantidadRegistros);

                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = cajaServicio
                            .ObtenerPaginado(
                                _estado.PaginaActual,
                                _estado.RegistrosPorPagina,
                                campoOrdenar,
                                esAscendente,
                                filtroActivo,
                                textoBuscar);

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

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            ActualizarInformacion();

        }


        private void noActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
            ActualizarInformacion();

        }

        private void ActualizarInformacion()
        {
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroActivo = null;
            textoBuscar = null;
            tsbBuscar.BackColor = SystemColors.Control;

            ActualizarInformacion();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            CajaListDto? cajaListDto = _bindingSource
                .ObtenerSeleccionado<CajaListDto>(_servicioMensajes);
            if (cajaListDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                var cajaServicio = scope.ServiceProvider
                        .GetRequiredService<ICajaServicio>();
                var resultadoConsulta = cajaServicio.ObtenerParaBorrar(cajaListDto.ProductoId);
                if (resultadoConsulta.IsFailure)
                {
                    _servicioMensajes.Errores(resultadoConsulta.Errors);
                    return;

                }
                var cajaDeleteDto = resultadoConsulta.Value;
                if (!_servicioMensajes.Confirmar($"¿Desea borrar el bombón" +
                    $" {cajaListDto.NombreCaja}?")) return;
                if (cajaDeleteDto is null) return;
                try
                {
                    var resultadoEliminacion = cajaServicio
                        .Borrar(cajaDeleteDto);
                    if (resultadoEliminacion.IsConcurrencyConflict)
                    {
                        _servicioMensajes.Errores(resultadoEliminacion.Errors);
                        RecargarGrilla();
                        return;

                    }
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
                using (frmCajaAe frm = scope.ServiceProvider.GetRequiredService<frmCajaAe>())
                {
                    frm.Text = "Nueva Caja";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;
                        bool sePuedeVer = filtroActivo is null || filtroActivo == true;
                        if (sePuedeVer)
                        {
                            var tipoServicio = scope.ServiceProvider
                                .GetRequiredService<ICajaServicio>();
                            var resultado = tipoServicio
                                .ObtenerPaginaRegistro(nuevoId, _estado.RegistrosPorPagina);
                            if (resultado.IsFailure)
                            {
                                _servicioMensajes.Errores(resultado.Errors);
                                return;
                            }
                            _estado.PaginaActual = resultado.Value;
                        }
                        RecargarGrilla();
                        if (sePuedeVer)
                        {
                            var nuevoTipo = _bindingSource.List
                                .Cast<CajaListDto>()
                                .FirstOrDefault(b => b.ProductoId == nuevoId);
                            if (nuevoTipo is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(nuevoTipo);

                        }
                        else
                        {
                            _servicioMensajes.Advertencia("Los registros agregados no se" +
                                " pueden mostrar\npor condición de filtro o búsqueda");
                        }
                    }

                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            CajaListDto? cajaListDto = _bindingSource
                .ObtenerSeleccionado<CajaListDto>(_servicioMensajes);
            if (cajaListDto is null) return;
            var seleccionadoId = cajaListDto.ProductoId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var cajaServicio = scope.ServiceProvider
                .GetRequiredService<ICajaServicio>();
                    var resultadoConsulta = cajaServicio
                        .ObtenerParaEditar(cajaListDto.ProductoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    var cajaEditDto = resultadoConsulta.Value;
                    if (cajaEditDto is null) return;
                    using (frmCajaAe frm = scope.ServiceProvider
                        .GetRequiredService<frmCajaAe>())
                    {
                        frm.Text = "Editar Caja";
                        frm.SetCaja(cajaEditDto);
                        frm.ShowDialog();
                        var cajaEditado = frm.GetCaja();
                        if (cajaEditado is null) return;
                        bool sePuedeVer = filtroActivo is null ||
                            filtroActivo == cajaEditado.Activo;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = cajaServicio
                                .ObtenerPaginaRegistro(seleccionadoId, _estado.RegistrosPorPagina,
                                filtroActivo);
                            if (resultadoConsulta.IsFailure)
                            {
                                _servicioMensajes.Errores(resultadoPagina.Errors);
                                return;
                            }
                            _estado.PaginaActual = resultadoPagina.Value;
                        }

                        if (frm.ConcurrencyConflict)//si hubo concurrencia se recarga la grilla
                        {
                            RecargarGrilla();
                        }
                        if (frm.DataChanged)//si cambiaron los datos se recarga la grilla
                        {
                            RecargarGrilla();
                        }
                        if (sePuedeVer)
                        {
                            var registroEditado = _bindingSource.List
                                .Cast<CajaListDto>()
                                .FirstOrDefault(tb => tb.ProductoId == seleccionadoId);
                            if (registroEditado is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(registroEditado);

                        }
                        else
                        {
                            _servicioMensajes.Advertencia("El registro editado no se puede mostrar" +
                                "\npor condición de filtro o búsqueda");

                        }
                    }

                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }
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
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                _servicioMensajes.Advertencia("Debe poner un texto para efectuar la búsqueda");
            }
            textoBuscar = txtBuscar.Text;
            tsbBuscar.BackColor = Color.Orange;
            _estado.PaginaActual = 1;
            RecargarGrilla();

        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            var cajaListDto = _bindingSource.ObtenerSeleccionado<CajaListDto>(_servicioMensajes);
            if (cajaListDto is null) return;
            var seleccionadoId = cajaListDto.ProductoId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var cajaServicio = scope.ServiceProvider
                .GetRequiredService<ICajaServicio>();
                    var resultadoConsulta = cajaServicio
                        .ObtenerCajaConDetalle(cajaListDto.ProductoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    var cajaDto = resultadoConsulta.Value;
                    if (cajaDto is null) return;
                    using (frmDetalleCaja frm = scope.ServiceProvider
                        .GetRequiredService<frmDetalleCaja>())
                    {
                        frm.Text = "Detalle de la Caja";
                        frm.SetCaja(cajaDto);
                        frm.ShowDialog();
                    }

                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message); 
                }
            }

        }
    }

}
