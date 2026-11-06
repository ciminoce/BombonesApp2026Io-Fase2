using BombonesApp2026.Datos;
using BombonesApp2026.Entidades;
using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.FormaDePago;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Servicios.Mapeadores;
using FluentValidation;
using System.Linq.Expressions;

namespace BombonesApp2026.Servicios.Servicios
{
    public class FormaDePagoServicio : IFormaDePagoServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<FormaDePagoCreateDto> _createValidator;
        private readonly IValidator<FormaDePagoUpdateDto> _updateValidator;

        public FormaDePagoServicio(
            IUnitOfWork unitOfWork,
            IValidator<FormaDePagoCreateDto> createValidator,
            IValidator<FormaDePagoUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result Agregar(FormaDePagoCreateDto formaDePagoDto)
        {
            // 1. Validar DTO antes del mapeo
            var result = _createValidator.Validate(formaDePagoDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Mapear a Entidad
            var formaDePago = FormaDePagoMapper.ToEntidad(formaDePagoDto);

            // 3. Regla de negocio: Duplicados
            if (_unitOfWork.FormasDePago.Existe(formaDePago))
            {
                return Result.Failure($"Ya existe una forma de pago con el nombre {formaDePago.Nombre}.");
            }

            try
            {
                _unitOfWork.FormasDePago.Agregar(formaDePago);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar agregar la forma de pago: {ex.Message}");
            }
        }

        public Result Editar(FormaDePagoUpdateDto formaDePagoDto)
        {
            // 1. Validar DTO antes de tocar la BD o mapear
            var result = _updateValidator.Validate(formaDePagoDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Obtener entidad existente
            var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(formaDePagoDto.FormaDePagoId);
            if (formaDePago == null)
            {
                return Result.Failure("Forma de pago no encontrada.");
            }

            // 3. Modificar propiedades
            formaDePago.Nombre = formaDePagoDto.Nombre;
            formaDePago.Activo = formaDePagoDto.Activo;

            // 4. Regla de negocio: Duplicados (excluyendo el propio registro en el repositorio/método Existe)
            if (_unitOfWork.FormasDePago.Existe(formaDePago))
            {
                return Result.Failure($"Ya existe otra forma de pago con el nombre {formaDePago.Nombre}.");
            }

            try
            {
                _unitOfWork.FormasDePago.Editar(formaDePago, formaDePago.FormaDePagoId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar la forma de pago: {ex.Message}");
            }
        }

        public Result Borrar(int id)
        {
            var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(id);
            if (formaDePago == null)
            {
                return Result.Failure("Forma de pago no encontrada.");
            }

            try
            {
                _unitOfWork.FormasDePago.Borrar(formaDePago.FormaDePagoId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar la forma de pago: {ex.Message}");
            }
        }

        public Result<List<FormaDePagoListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.FormasDePago.ObtenerTodos();
                var listaDto = lista.Select(FormaDePagoMapper.ToListDto).ToList();
                return Result<List<FormaDePagoListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<FormaDePagoListDto>>.Failure(ex.Message);
            }
        }

        public Result<FormaDePagoListDto> ObtenerPorId(int id)
        {
            try
            {
                var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(id);
                if (formaDePago == null)
                {
                    return Result<FormaDePagoListDto>.Failure("Forma de pago no encontrada.");
                }

                var formaDePagoDto = FormaDePagoMapper.ToListDto(formaDePago);
                return Result<FormaDePagoListDto>.Success(formaDePagoDto);
            }
            catch (Exception ex)
            {
                return Result<FormaDePagoListDto>.Failure(ex.Message);
            }
        }

        public Result<FormaDePagoUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(id);
                if (formaDePago != null)
                {
                    var formaDePagoDto = FormaDePagoMapper.ToUpdateDto(formaDePago);
                    return Result<FormaDePagoUpdateDto>.Success(formaDePagoDto);
                }

                return Result<FormaDePagoUpdateDto>.Failure("Forma de pago no encontrada.");
            }
            catch (Exception ex)
            {
                return Result<FormaDePagoUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<List<FormaDePagoListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.FormasDePago.Query();
                var lista = query.Where(fp => fp.Activo == activo);
                var listaDto = lista.Select(FormaDePagoMapper.ToListDto).ToList();
                return Result<List<FormaDePagoListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<FormaDePagoListDto>>.Failure($"Error al intentar filtrar las formas de pago: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<FormaDePagoListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<FormaDePago, bool>>? filtro = fp =>
                        (!filtroActivo.HasValue || fp.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || fp.Nombre.Contains(textoBuscar));

                Func<IQueryable<FormaDePago>, IOrderedQueryable<FormaDePago>>? ordenarPor = campoOrden switch
                {
                    "FormaDePagoId" => q => esAscendente ? q.OrderBy(fp => fp.FormaDePagoId) : q.OrderByDescending(fp => fp.FormaDePagoId),
                    _ => q => esAscendente ? q.OrderBy(fp => fp.Nombre) : q.OrderByDescending(fp => fp.Nombre)
                };

                var resultado = _unitOfWork.FormasDePago.ObtenerPagina(pagina, registros, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(FormaDePagoMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<FormaDePagoListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<FormaDePagoListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<FormaDePagoListDto>>.Failure(ex.Message);
            }
        }


        public Result<List<FormaDePagoListDto>> ObtenerDatosCombo(FormaDePagoDefault formaDefault)
        {
            try
            {
                var lista = _unitOfWork.FormasDePago.ObtenerTodos()
                    .Where(c => c.Activo) // Filtrar solo las formas de pago activas
                .Select(b => b.ToListDto()).ToList();
                if (formaDefault == FormaDePagoDefault.Todos)
                {
                    var formaDePagoDefault = new FormaDePagoListDto
                    {
                        FormaDePagoId = 0,
                        Nombre = "Todos"
                    };
                    lista.Insert(0, formaDePagoDefault);

                }
                else
                {
                    var formaDePagoDefault = new FormaDePagoListDto
                    {
                        FormaDePagoId = 0,
                        Nombre = "Todos"
                    };
                    lista.Insert(0, formaDePagoDefault);
                }
                return Result<List<FormaDePagoListDto>>.Success(lista);

            }
            catch (Exception ex)
            {
                return Result<List<FormaDePagoListDto>>
                    .Failure($"Error al poblar los datos del combo de formas de pago: {ex.Message}");
            }
        }

    }
}
