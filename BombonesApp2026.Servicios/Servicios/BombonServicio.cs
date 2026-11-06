using BombonesApp2026.Datos;
using BombonesApp2026.Entidades;
using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Bombon;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BombonesApp2026.Servicios.Servicios
{
    public class BombonServicio : IBombonServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<BombonCreateDto> _createValidator;
        private readonly IValidator<BombonUpdateDto> _updateValidator;

        public BombonServicio(
            IUnitOfWork unitOfWork,
            IValidator<BombonCreateDto> createValidator,
            IValidator<BombonUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(BombonCreateDto bombonDto)
        {
            // 1. Validar el DTO directamente
            var validationResult = _createValidator.Validate(bombonDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<int>.Failure(errors);
            }

            // 2. Mapear a entidad
            var Bombon = BombonMapper.ToEntidad(bombonDto);

            // 3. Regla de negocio
            if (_unitOfWork.Bombones.Existe(Bombon))
            {
                return Result<int>.Failure("El Bombon ya existe.");
            }

            try
            {
                _unitOfWork.Bombones.Agregar(Bombon);
                _unitOfWork.Save();
                return Result<int>.Success(Bombon.ProductoId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar el Bombon: {ex.Message}");
            }
        }

        public Result Editar(BombonUpdateDto bombonDto)
        {
            // 1. Validar el DTO de actualización
            var validationResult = _updateValidator.Validate(bombonDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Failure(errors);
            }

            // 2. Obtener la entidad persistida
            var bombon = _unitOfWork.Bombones.ObtenerPorId(bombonDto.ProductoId);
            if (bombon == null)
            {
                return Result.Failure("Bombon no encontrado.");
            }

            // 3. Actualizar valores
            bombon.Nombre = bombonDto.Nombre;
            bombon.Descripcion = bombonDto.Descripcion;
            bombon.Precio = bombonDto.Precio;
            bombon.TieneAzucar = bombonDto.TieneAzucar;
            bombon.PesoEnGramos = bombonDto.PesoEnGramos;
            bombon.Stock = bombonDto.Stock;

            bombon.Activo = bombonDto.Activo;
            bombon.RowVersion = bombonDto.RowVersion;

            // 4. Regla de negocio para duplicados en edición
            if (_unitOfWork.Bombones.Existe(bombon))
            {
                return Result.Failure("Ya existe otro Bombon registrado con los mismos datos.");
            }

            try
            {
                _unitOfWork.Bombones.Editar(bombon, bombon.ProductoId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar el Bombon: {ex.Message}");
            }
        }

        public Result Borrar(int id)
        {
            var Bombon = _unitOfWork.Bombones.ObtenerPorId(id);
            if (Bombon == null)
            {
                return Result.Failure("Bombon no encontrado.");
            }

            try
            {
                _unitOfWork.Bombones.Borrar(Bombon.ProductoId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar el Bombon: {ex.Message}");
            }
        }

        public Result<List<BombonListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Bombones.ObtenerTodos();
                var listaDto = lista.Select(b => b.ToListDto()).ToList();

                return Result<List<BombonListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<BombonListDto>>.Failure(ex.Message);
            }
        }

        public Result<BombonListDto> ObtenerPorId(int id)
        {
            try
            {
                var bombon = _unitOfWork.Bombones.ObtenerPorId(id);
                if (bombon == null)
                {
                    return Result<BombonListDto>.Failure("Bombon no encontrado.");
                }

                var bombonDto = bombon.ToListDto();

                return Result<BombonListDto>.Success(bombonDto);
            }
            catch (Exception ex)
            {
                return Result<BombonListDto>.Failure(ex.Message);
            }
        }

        public Result<BombonUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var bombon = _unitOfWork.Bombones.ObtenerPorId(id);
                if (bombon == null)
                {
                    return Result<BombonUpdateDto>.Failure("Bombon no encontrado.");
                }

                var bombonDto = bombon.ToUpdateDto();
                return Result<BombonUpdateDto>.Success(bombonDto);
            }
            catch (Exception ex)
            {
                return Result<BombonUpdateDto>.Failure(ex.Message);
            }
        }
        public Result<ResultadoPaginacionDto<BombonListDto>> ObtenerPaginado(
                int pagina,
                int cantidad,
                string campoOrden,
                bool esAscendente,
                bool? filtroActivo = null,
                string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Bombon, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));
                Func<IQueryable<Bombon>, IOrderedQueryable<Bombon>>? ordenarPor = campoOrden switch
                {
                    "TipoBombonId" => q => esAscendente ? q.OrderBy(c => c.ProductoId) : q.OrderByDescending(c => c.ProductoId),
                    "Nombre" => q => esAscendente ? q.OrderBy(c => c.Nombre) : q.OrderByDescending(c => c.Nombre),
                    _ => q => esAscendente ? q.OrderBy(c => c.Nombre) : q.OrderByDescending(c => c.Nombre),
                };
                
                Func<IQueryable<Bombon>,IQueryable<Bombon>>? incluir = q => q.Include(c => c.TipoBombon);
                var resultado = _unitOfWork.Bombones.ObtenerPagina(pagina, cantidad, ordenarPor, filtro, incluir);
                var listaDto = resultado.lista
                    .Select(b => b.ToListDto()).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<BombonListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<BombonListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<BombonListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }
        public Result<BombonDeleteDto> ObtenerParaBorrar(int id)
        {
            var bombon = _unitOfWork.Bombones.ObtenerPorId(id);
            if (bombon != null)
            {
                var bombonDto = BombonMapper.ToDeleteDto(bombon);
                return Result<BombonDeleteDto>.Success(bombonDto);
            }

            return Result<BombonDeleteDto>.Failure("Error al intentar obtener el bombón");
        }
        public Result Borrar(BombonDeleteDto bombonDto)
        {
            try
            {
                _unitOfWork.Bombones.Borrar(bombonDto.ProductoId, bombonDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Bombón con ID: {bombonDto.ProductoId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar un bombón: {ex.Message}");
            }
        }


        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<Bombon, bool>>? filtrarPor = null;
                if (filtroActivo is not null)
                {
                    filtrarPor = b => b.Activo == filtroActivo;
                }

                var posicion = _unitOfWork.Bombones.ObtenerPosicionRegistro(seleccionadoId, filtrarPor);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<List<BombonComboDto>> ObtenerDatosCombo(BombonDefault defaultBombon, bool activos)
        {
            try
            {
                var query = _unitOfWork.Bombones.Query();
                if (activos)
                {
                    query = query.Where(b => b.Activo == true);
                }
                var lista = query.OrderBy(b=>b.Nombre).ToList();
                var listaDto = lista.Select(b => b.ToComboDto()).ToList();
                if (defaultBombon == BombonDefault.Seleccione)
                {
                    var dto = new BombonComboDto
                    {
                        BombonId = 0,
                        NombreBombon = "Seleccione"
                    };
                    listaDto.Insert(0, dto);
                }
                else
                {
                    var dto = new BombonComboDto
                    {
                        BombonId = 0,
                        NombreBombon = "Todos"
                    };
                    listaDto.Insert(0, dto);
                }
                return Result<List<BombonComboDto>>
                    .Success(listaDto);

            }
            catch (Exception ex)
            {

                return Result<List<BombonComboDto>>.Failure($"Error al intentar obtener" +
                    $" la lista para combo de bombones: {ex.Message}");
            }
        }
    }
}
