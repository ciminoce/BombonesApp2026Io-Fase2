using BombonesApp2026.Datos;
using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Caja;
using BombonesApp2026.Servicios.DTOs.DetalleCaja;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BombonesApp2026.Servicios.Servicios
{
    public class CajaServicio : ICajaServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CajaCreateDto> _createValidator;
        private readonly IValidator<CajaUpdateDto> _updateValidator;

        public CajaServicio(
            IUnitOfWork unitOfWork,
            IValidator<CajaCreateDto> createValidator,
            IValidator<CajaUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(CajaCreateDto cajaDto)
        {
            // 1. Validar el DTO directamente
            var validationResult = _createValidator.Validate(cajaDto);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<int>.Failure(errores);
            }
            //var listaErrores=new List<string>();
            //foreach (var itemDetalle in cajaDto.Detalles)
            //{
            //    if (itemDetalle.CantidadBombon <= 0)
            //    {
            //        listaErrores.Add($"La cantidad del bombón {itemDetalle.NombreBombon} es menor a cero");
            //    }
            //}
            //foreach (var itemDetalle in cajaDto.Detalles)
            //{
            //    var bombon = _unitOfWork.Bombones
            //        .ObtenerPorId(itemDetalle.BombonId);
            //    if(bombon is null)
            //    {
            //        listaErrores.Add($"El bombón con ID {itemDetalle.BombonId} no existe");
            //    }
            //    if (!bombon.Activo)
            //    {
            //        listaErrores.Add($"El bombón con ID {itemDetalle.BombonId} no se encuentra activo");
            //    }
            //}
            //if (listaErrores.Any())
            //{
            //    return Result<int>.Failure(listaErrores);
            //}

            // 2. Crear la entidad
            Caja caja = new Caja
            {
                Nombre = cajaDto.Nombre,
                Descripcion = cajaDto.Descripcion,
                Stock = cajaDto.Stock,
                Activo = true
            };
            //3. Agregar Detalles a la caja
            try
            {
                foreach (var item in cajaDto.Detalles)
                {
                    caja.AgregarBombon(item.BombonId, item.CantidadBombon);
                }

            }
            catch (Exception ex)
            {

                return Result<int>.Failure(ex.Message);
            }
            // 4. Regla de negocio
            if (_unitOfWork.Cajas.Existe(caja))
            {
                return Result<int>.Failure("El Caja ya existe.");
            }

            try
            {
                _unitOfWork.Cajas.Agregar(caja);
                _unitOfWork.Save();
                return Result<int>.Success(caja.ProductoId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar el Caja: {ex.Message}");
            }
        }

        public Result Editar(CajaUpdateDto cajaDto)
        {
            // 1. Validar el DTO de actualización
            var validationResult = _updateValidator.Validate(cajaDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Failure(errors);
            }

            // 2. Obtener la entidad persistida
            var caja = _unitOfWork.Cajas.ObtenerCajaConDetalles(cajaDto.ProductoId);
            if (caja == null)
            {
                return Result.Failure("Caja no encontrada.");
            }

            // 3. Actualizar valores
            caja.Nombre = cajaDto.Nombre;
            caja.Descripcion = cajaDto.Descripcion;
            caja.Stock = cajaDto.Stock;
            caja.Activo = cajaDto.Activo;
            caja.RowVersion = cajaDto.RowVersion;

            // 4. Regla de negocio para duplicados en edición
            if (_unitOfWork.Cajas.Existe(caja))
            {
                return Result.Failure("Ya existe otra caja registrada con los mismos datos.");
            }
            ActualizarDetalles(caja, cajaDto.Detalles);
            try
            {
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar el Caja: {ex.Message}");
            }
        }

        private void ActualizarDetalles(Caja caja, List<DetalleCajaDto> detalles)
        {
            //1.Borrar los que no están
            foreach (var itemCaja in caja.Detalles.ToList())
            {
                var existe = detalles.Any(d => d.BombonId == itemCaja.BombonId);
                if (!existe)
                {
                    _unitOfWork.Cajas.EliminarDetalle(itemCaja);
                    caja.EliminarBombon(itemCaja.BombonId);
                }
            }
            //2.Actualizar los que haya que actualizar
            foreach (var itemDto in detalles)
            {
                var detalleEnCaja = caja.Detalles.FirstOrDefault(
                    d => d.BombonId == itemDto.BombonId);
                if (detalleEnCaja is null) continue;
                caja.ModificarCantidadBombon(itemDto.BombonId,
                    itemDto.CantidadBombon);
            }
            //3.Agregar los que hay que agregar
            foreach (var itemDto in detalles)
            {
                var detalleEnCaja = caja.Detalles.FirstOrDefault(
                    d => d.BombonId == itemDto.BombonId);
                if (detalleEnCaja is not null) continue;
                caja.AgregarBombon(itemDto.BombonId, itemDto.CantidadBombon);

            }
        }

        public Result Borrar(int id)
        {
            var caja = _unitOfWork.Cajas.ObtenerPorId(id);
            if (caja == null)
            {
                return Result.Failure("Caja no encontrado.");
            }

            try
            {
                _unitOfWork.Cajas.Borrar(caja.ProductoId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar el Caja: {ex.Message}");
            }
        }

        public Result<List<CajaListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Cajas.ObtenerTodos();
                var listaDto = lista.Select(b => b.ToListDto()).ToList();

                return Result<List<CajaListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<CajaListDto>>.Failure(ex.Message);
            }
        }

        public Result<CajaListDto> ObtenerPorId(int id)
        {
            try
            {
                var caja = _unitOfWork.Cajas.ObtenerPorId(id);
                if (caja == null)
                {
                    return Result<CajaListDto>.Failure("Caja no encontrado.");
                }

                var CajaDto = caja.ToListDto();

                return Result<CajaListDto>.Success(CajaDto);
            }
            catch (Exception ex)
            {
                return Result<CajaListDto>.Failure(ex.Message);
            }
        }

        public Result<CajaUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var caja = _unitOfWork.Cajas.ObtenerPorId(id);
                if (caja == null)
                {
                    return Result<CajaUpdateDto>.Failure("Caja no encontrado.");
                }

                var cajaDto = caja.ToUpdateDto();
                return Result<CajaUpdateDto>.Success(cajaDto);
            }
            catch (Exception ex)
            {
                return Result<CajaUpdateDto>.Failure(ex.Message);
            }
        }
        public Result<ResultadoPaginacionDto<CajaListDto>> ObtenerPaginado(
                int pagina,
                int cantidad,
                string campoOrden,
                bool esAscendente,
                bool? filtroActivo = null,
                string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Caja, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));
                Func<IQueryable<Caja>, IOrderedQueryable<Caja>>? ordenarPor = campoOrden switch
                {
                    "ProductoId" => q => esAscendente ? q.OrderBy(c => c.ProductoId) : q.OrderByDescending(c => c.ProductoId),
                    "Nombre" => q => esAscendente ? q.OrderBy(c => c.Nombre) : q.OrderByDescending(c => c.Nombre),
                    _ => q => esAscendente ? q.OrderBy(c => c.Nombre) : q.OrderByDescending(c => c.Nombre),
                };
                Func<IQueryable<Caja>, IQueryable<Caja>> incluir = q => q.Include(c => c.Detalles)
                                .ThenInclude(d => d.Bombon);
                var resultado = _unitOfWork.Cajas.ObtenerPagina(pagina, cantidad, ordenarPor, filtro, incluir);
                var listaDto = resultado.lista
                    .Select(b => b.ToListDto()).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<CajaListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<CajaListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<CajaListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }
        public Result<CajaDeleteDto> ObtenerParaBorrar(int id)
        {
            var caja = _unitOfWork.Cajas.ObtenerPorId(id);
            if (caja != null)
            {
                var CajaDto = CajaMapper.ToDeleteDto(caja);
                return Result<CajaDeleteDto>.Success(CajaDto);
            }

            return Result<CajaDeleteDto>.Failure("Error al intentar obtener el bombón");
        }
        public Result Borrar(CajaDeleteDto CajaDto)
        {
            try
            {
                _unitOfWork.Cajas.Borrar(CajaDto.ProductoId, CajaDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Bombón con ID: {CajaDto.ProductoId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar un bombón: {ex.Message}");
            }
        }


        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar=null)
        {
            try
            {
                Expression<Func<Caja, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));

                var posicion = _unitOfWork.Cajas.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<CajaDetailDto> ObtenerCajaConDetalle(int cajaId)
        {
            try
            {
                Caja? caja = _unitOfWork.Cajas.ObtenerPorId(cajaId);
                if(caja is null)
                {
                    return Result<CajaDetailDto>.Failure($"No se encontró" +
                        $" la caja con ID {cajaId}");
                }
                CajaDetailDto cajaDto = caja.ToDetailDto();
                return Result<CajaDetailDto>.Success(cajaDto);
            }
            catch (Exception ex)
            {

                return Result<CajaDetailDto>.Failure($"Se produjo un error " +
                    $"al intentar obtener la caja {ex.Message}");
            }
        }
    }
}
