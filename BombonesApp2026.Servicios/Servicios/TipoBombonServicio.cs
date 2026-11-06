using BombonesApp2026.Datos;
using BombonesApp2026.Entidades;
using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.TipoBombon;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace BombonesApp2026.Servicios.Servicios
{
    public class TipoBombonServicio : ITipoBombonServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<TipoBombonCreateDto> _createValidator;
        private readonly IValidator<TipoBombonUpdateDto> _updateValidator;

        public TipoBombonServicio(
            IUnitOfWork unitOfWork,
            IValidator<TipoBombonCreateDto> createValidator,
            IValidator<TipoBombonUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(TipoBombonCreateDto tipoBombonDto)
        {
            try
            {
                // 1. Validar el DTO antes de mapear
                var validationResult = _createValidator.Validate(tipoBombonDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Mapear a la entidad de dominio
                var tipoBombon = TipoBombonMapper.ToEntidad(tipoBombonDto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.TipoBombones.Existe(tipoBombon))
                {
                    return Result<int>.Failure($"Ya existe un tipo de bombón con el nombre {tipoBombon.Nombre}");
                }

                _unitOfWork.TipoBombones.Agregar(tipoBombon);
                _unitOfWork.Save();

                return Result<int>.Success(tipoBombon.TipoBombonId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar un tipo de bombón: {ex.Message}");
            }
        }

        public Result Editar(TipoBombonUpdateDto dto)
        {
            try
            {
                // 1. Validar el DTO antes de mapear
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Mapear a la entidad de dominio
                var entidad = TipoBombonMapper.ToEntidad(dto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.TipoBombones.Existe(entidad))
                {
                    return Result.Failure($"Ya existe un tipo de bombón con el nombre {entidad.Nombre}");
                }

                _unitOfWork.TipoBombones.Editar(entidad, entidad.TipoBombonId, dto.RowVersion);
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Tipo de bombón con ID {dto.TipoBombonId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar el tipo de bombón: {ex.Message}");
            }
        }

        public Result Borrar(TipoBombonDeleteDto tipoDto)
        {
            try
            {
                _unitOfWork.TipoBombones.Borrar(tipoDto.TipoBombonId, tipoDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Tipo de bombón con ID: {tipoDto.TipoBombonId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar un tipo de bombón: {ex.Message}");
            }
        }

        public Result<List<TipoBombonListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.TipoBombones.ObtenerTodos();
                var listaDto = lista.Select(tb => TipoBombonMapper.ToListDto(tb)).ToList();
                return Result<List<TipoBombonListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<TipoBombonListDto>>.Failure(ex.Message);
            }
        }

        public Result<TipoBombonListDto> ObtenerPorId(int id)
        {
            try
            {
                var tipoBombon = _unitOfWork.TipoBombones.ObtenerPorId(id);
                if (tipoBombon != null)
                {
                    var tipoBombonDto = TipoBombonMapper.ToListDto(tipoBombon);
                    return Result<TipoBombonListDto>.Success(tipoBombonDto);
                }

                return Result<TipoBombonListDto>.Failure("Tipo de bombón no encontrado!!!");
            }
            catch (Exception ex)
            {
                return Result<TipoBombonListDto>.Failure(ex.Message);
            }
        }

        public Result<TipoBombonUpdateDto> ObtenerParaEditar(int id)
        {
            var tipoBombon = _unitOfWork.TipoBombones.ObtenerPorId(id);
            if (tipoBombon != null)
            {
                var tipoBombonDto = TipoBombonMapper.ToUpdateDto(tipoBombon);
                return Result<TipoBombonUpdateDto>.Success(tipoBombonDto);
            }

            return Result<TipoBombonUpdateDto>.Failure("Tipo de bombón no encontrado!!!");
        }

        public Result<TipoBombonDeleteDto> ObtenerParaBorrar(int id)
        {
            var tipoBombon = _unitOfWork.TipoBombones.ObtenerPorId(id);
            if (tipoBombon != null)
            {
                var tipoBombonDto = TipoBombonMapper.ToDeleteDto(tipoBombon);
                return Result<TipoBombonDeleteDto>.Success(tipoBombonDto);
            }

            return Result<TipoBombonDeleteDto>.Failure("Error al intentar obtener el tipo de bombón");
        }

        public Result<List<TipoBombonListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.TipoBombones.Query();
                var lista = query.Where(tb => tb.Activo == activo);
                var listaDto = lista.Select(tb => TipoBombonMapper.ToListDto(tb)).ToList();
                return Result<List<TipoBombonListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<TipoBombonListDto>>.Failure($"Error al intentar filtrar los tipos de Bombones: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<TipoBombonListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<TipoBombon, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));

                Func<IQueryable<TipoBombon>, IOrderedQueryable<TipoBombon>>? ordenarPor = campoOrden switch
                {
                    "TipoBombonId" => q => esAscendente ? q.OrderBy(tb => tb.TipoBombonId) : q.OrderByDescending(tb => tb.TipoBombonId),
                    _ => q => esAscendente ? q.OrderBy(tb => tb.Nombre) : q.OrderByDescending(tb => tb.Nombre),
                };

                var resultado = _unitOfWork.TipoBombones.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(tb => TipoBombonMapper.ToListDto(tb)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<TipoBombonListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<TipoBombonListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<TipoBombonListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<TipoBombon, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));


                var posicion = _unitOfWork.TipoBombones.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<List<TipoBombonListDto>> ObtenerDatosCombo(TipoBombonDefault tipoDefault)
        {
            var lista = _unitOfWork.TipoBombones.ObtenerTodos()
                .Select(tp => TipoBombonMapper.ToListDto(tp)).ToList();
            if (tipoDefault == TipoBombonDefault.Todos)
            {
                var defaultTipo = new TipoBombonListDto
                {
                    TipoBombonId = 0,
                    Nombre = "Todos"
                };
                lista.Insert(0, defaultTipo);

            }
            else
            {
                var defaultTipo = new TipoBombonListDto
                {
                    TipoBombonId = 0,
                    Nombre = "Seleccione"
                };
                lista.Insert(0, defaultTipo);
            }
            return Result<List<TipoBombonListDto>>.Success(lista);
        }


    }
}
