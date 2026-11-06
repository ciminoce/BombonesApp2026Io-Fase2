using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.TipoBombon;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BombonesApp2026.Windows
{
    public partial class frmTiposDeBombones : Form
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

        public frmTiposDeBombones(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTiposDeBombones_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var tipoBombonesServicio = scope.ServiceProvider
                    .GetRequiredService<ITipoBombonServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = tipoBombonesServicio
                        .ObtenerPagina(
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
                        resultadoConsulta = tipoBombonesServicio
                            .ObtenerPagina(
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
        private void ActualizarVista(ResultadoPaginacionDto<TipoBombonListDto> resultado)
        {
            _estado.Actualizar(resultado.CantidadRegistros);
            MostrarEnGrilla(resultado);
            ActualizarNavegacion();

        }
        private void ActualizarNavegacion()
        {
            lblCantidad.Text = _estado.TextoRegistros();
            lblPaginas.Text = _estado.TextoPaginas();

            btnPrimero.Enabled = _estado.PuedeIrAnterior();
            btnAnterior.Enabled = _estado.PuedeIrAnterior();
            btnSiguiente.Enabled = _estado.PuedeIrSiguiente();
            btnUltimo.Enabled = _estado.PuedeIrSiguiente();

        }
        private void MostrarEnGrilla(ResultadoPaginacionDto<TipoBombonListDto> resultado)
        {
            _bindingSource.DataSource = resultado.Items;
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            tsbFiltrar.BackColor = Color.Orange;
            ActualizarInformacion();

        }


        private void noActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
            tsbFiltrar.BackColor = Color.Orange;
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
            tsbFiltrar.BackColor = SystemColors.Control;
            ActualizarInformacion();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            
            TipoBombonListDto? tipoListDto = _bindingSource
                .ObtenerSeleccionado<TipoBombonListDto>(_servicioMensajes);
            if (tipoListDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                var tipoBombonServicio = scope.ServiceProvider
                        .GetRequiredService<ITipoBombonServicio>();
                var resultadoConsulta = tipoBombonServicio.ObtenerParaBorrar(tipoListDto.TipoBombonId);
                if (resultadoConsulta.IsFailure)
                {
                    _servicioMensajes.Errores(resultadoConsulta.Errors);
                    return;

                }
                var tipoDeleteDto = resultadoConsulta.Value;
                if (!_servicioMensajes.Confirmar($"¿Desea borrar el tipo {tipoListDto.Nombre}?")) return;
                try
                {
                    var resultadoEliminacion = tipoBombonServicio
                        .Borrar(tipoDeleteDto!);
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
                using (frmTipoDeBombonesAe frm = scope.ServiceProvider.GetRequiredService<frmTipoDeBombonesAe>())
                {
                    frm.Text = "Nuevo Tipo de Bombón";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;
                        bool sePuedeVer = filtroActivo is null || filtroActivo == true;
                        if (sePuedeVer)
                        {
                            var tipoServicio = scope.ServiceProvider
                                .GetRequiredService<ITipoBombonServicio>();
                            var resultado = tipoServicio.ObtenerPaginaRegistro(nuevoId, _estado.RegistrosPorPagina);
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
                                .Cast<TipoBombonListDto>()
                                .FirstOrDefault(tp => tp.TipoBombonId == nuevoId);
                            if (nuevoTipo is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(nuevoTipo);

                        }
                        else
                        {
                            _servicioMensajes.Advertencia("Los registros agregados no se pueden mostrar\npor condición de filtro o búsqueda");
                        }
                    }

                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            TipoBombonListDto? tipoListDto = _bindingSource
                .ObtenerSeleccionado<TipoBombonListDto>(_servicioMensajes);
            if (tipoListDto is null) return;
            var seleccionadoId = tipoListDto.TipoBombonId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var tipoBombonesServicio = scope.ServiceProvider
                .GetRequiredService<ITipoBombonServicio>();
                    var resultadoConsulta = tipoBombonesServicio
                        .ObtenerParaEditar(tipoListDto.TipoBombonId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    var tipoEditDto = resultadoConsulta.Value;
                    using (frmTipoDeBombonesAe frm = scope.ServiceProvider
                        .GetRequiredService<frmTipoDeBombonesAe>())
                    {
                        frm.Text = "Editar Tipo de Bombón";
                        frm.SetTipo(tipoEditDto);
                        frm.ShowDialog();
                        var tipoEditado = frm.GetTipo();
                        if (tipoEditado is null) return;
                        bool sePuedeVer = filtroActivo is null ||
                            filtroActivo == tipoEditado.Activo;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = tipoBombonesServicio
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
                                .Cast<TipoBombonListDto>()
                                .FirstOrDefault(tb => tb.TipoBombonId == seleccionadoId);
                            if (registroEditado is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(registroEditado);

                        }
                        else
                        {
                            _servicioMensajes.Advertencia("El registro editado no se puede mostrar\npor condición de filtro o búsqueda");
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

        }
    }
}
