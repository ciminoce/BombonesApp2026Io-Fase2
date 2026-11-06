using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Bombon;
using BombonesApp2026.Servicios.DTOs.Cliente;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace BombonesApp2026.Windows
{
    public partial class frmBombones : Form
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

        public frmBombones(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.DataSource = _bindingSource;

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBombones_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var bombonServicio = scope.ServiceProvider
                    .GetRequiredService<IBombonServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = bombonServicio
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
                        resultadoConsulta = bombonServicio
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
        private void ActualizarVista(ResultadoPaginacionDto<BombonListDto> resultado)
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
        private void MostrarEnGrilla(ResultadoPaginacionDto<BombonListDto> resultado)
        {
            _bindingSource.DataSource = resultado.Items;
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
            BombonListDto? bombonListDto = _bindingSource
                .ObtenerSeleccionado<BombonListDto>(_servicioMensajes);
            if (bombonListDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                var bombonServicio = scope.ServiceProvider
                        .GetRequiredService<IBombonServicio>();
                var resultadoConsulta = bombonServicio.ObtenerParaBorrar(bombonListDto.ProductoId);
                if (resultadoConsulta.IsFailure)
                {
                    _servicioMensajes.Errores(resultadoConsulta.Errors);
                    return;

                }
                var bombonDeleteDto = resultadoConsulta.Value;
                if (!_servicioMensajes.Confirmar($"¿Desea borrar el bombón {bombonListDto.NombreBombon}?")) return;
                if (bombonDeleteDto is null) return;
                try
                {
                    var resultadoEliminacion = bombonServicio
                        .Borrar(bombonDeleteDto);
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
                using (frmBombonAe frm = scope.ServiceProvider.GetRequiredService<frmBombonAe>())
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
                                .GetRequiredService<IBombonServicio>();
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
                                .Cast<BombonListDto>()
                                .FirstOrDefault(b => b.ProductoId == nuevoId);
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
            var bombonListDto = _bindingSource
                .ObtenerSeleccionado<BombonListDto>(_servicioMensajes);
            if (bombonListDto is null) return;
            var seleccionadoId = bombonListDto.ProductoId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var bombonServicio = scope.ServiceProvider
                .GetRequiredService<IBombonServicio>();
                    var resultadoConsulta = bombonServicio
                        .ObtenerParaEditar(bombonListDto.ProductoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    var bombonEditDto = resultadoConsulta.Value;
                    using (frmBombonAe frm = scope.ServiceProvider
                        .GetRequiredService<frmBombonAe>())
                    {
                        frm.Text = "Editar Bombón";
                        frm.SetBombon(bombonEditDto);
                        frm.ShowDialog();
                        var bombonEditado = frm.GetBombon();
                        if (bombonEditado is null) return;
                        bool sePuedeVer = filtroActivo is null ||
                            filtroActivo == bombonEditado.Activo;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = bombonServicio
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
                                .Cast<BombonListDto>()
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
    }
}
