using BombonesApp2026.Datos;
using BombonesApp2026.Entidades;
using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Cliente;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Servicios.Mapeadores;
using FluentValidation;
using System.Linq.Expressions;

namespace BombonesApp2026.Servicios.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ClienteCreateDto> _createValidator;
        private readonly IValidator<ClienteUpdateDto> _updateValidator;

        public ClienteServicio(
            IUnitOfWork unitOfWork,
            IValidator<ClienteCreateDto> createValidator,
            IValidator<ClienteUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(ClienteCreateDto clienteDto)
        {
            // 1. Validar el DTO directamente
            var validationResult = _createValidator.Validate(clienteDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<int>.Failure(errors);
            }

            // 2. Mapear a entidad
            var cliente = clienteDto.ToEntidad();

            // 3. Regla de negocio
            if (_unitOfWork.Clientes.Existe(cliente))
            {
                return Result<int>.Failure("El cliente ya existe.");
            }

            try
            {
                _unitOfWork.Clientes.Agregar(cliente);
                _unitOfWork.Save();
                return Result<int>.Success(cliente.ClienteId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar el cliente: {ex.Message}");
            }
        }

        public Result Editar(ClienteUpdateDto clienteDto)
        {
            // 1. Validar el DTO de actualización
            var validationResult = _updateValidator.Validate(clienteDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Failure(errors);
            }

            // 2. Obtener la entidad persistida
            var cliente = _unitOfWork.Clientes.ObtenerPorId(clienteDto.ClienteId);
            if (cliente == null)
            {
                return Result.Failure("Cliente no encontrado.");
            }

            // 3. Actualizar valores
            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;
            cliente.Documento = clienteDto.Documento;
            cliente.Telefono = clienteDto.Telefono;
            cliente.Email = clienteDto.Email;
            cliente.Calle = clienteDto.Calle;
            cliente.Numero = clienteDto.Numero;
            cliente.Localidad = clienteDto.Localidad;
            cliente.Provincia = clienteDto.Provincia;
            cliente.CodigoPostal = clienteDto.CodigoPostal;
            cliente.Activo = clienteDto.Activo;
            cliente.RowVersion = clienteDto.RowVersion;

            // 4. Regla de negocio para duplicados en edición
            if (_unitOfWork.Clientes.Existe(cliente))
            {
                return Result.Failure("Ya existe otro cliente registrado con los mismos datos.");
            }

            try
            {
                _unitOfWork.Clientes.Editar(cliente, cliente.ClienteId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar el cliente: {ex.Message}");
            }
        }

        public Result Borrar(int id)
        {
            var cliente = _unitOfWork.Clientes.ObtenerPorId(id);
            if (cliente == null)
            {
                return Result.Failure("Cliente no encontrado.");
            }

            try
            {
                _unitOfWork.Clientes.Borrar(cliente.ClienteId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar el cliente: {ex.Message}");
            }
        }

        public Result<List<ClienteListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Clientes.ObtenerTodos();
                var listaDto = lista.Select(c => new ClienteListDto
                {
                    ClienteId = c.ClienteId,
                    NombreCompleto = $"{c.Nombre} {c.Apellido}",
                    Telefono = c.Telefono,
                    Email = c.Email,
                    Activo = c.Activo
                }).ToList();

                return Result<List<ClienteListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<ClienteListDto>>.Failure(ex.Message);
            }
        }

        public Result<ClienteListDto> ObtenerPorId(int id)
        {
            try
            {
                var cliente = _unitOfWork.Clientes.ObtenerPorId(id);
                if (cliente == null)
                {
                    return Result<ClienteListDto>.Failure("Cliente no encontrado.");
                }

                var clienteDto = new ClienteListDto
                {
                    ClienteId = cliente.ClienteId,
                    NombreCompleto = $"{cliente.Nombre} {cliente.Apellido}",
                    Telefono = cliente.Telefono,
                    Email = cliente.Email,
                    Activo = cliente.Activo
                };

                return Result<ClienteListDto>.Success(clienteDto);
            }
            catch (Exception ex)
            {
                return Result<ClienteListDto>.Failure(ex.Message);
            }
        }

        public Result<ClienteUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var cliente = _unitOfWork.Clientes.ObtenerPorId(id);
                if (cliente == null)
                {
                    return Result<ClienteUpdateDto>.Failure("Cliente no encontrado.");
                }

                var clienteDto = new ClienteUpdateDto
                {
                    ClienteId = cliente.ClienteId,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Documento = cliente.Documento,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email,
                    Calle = cliente.Calle,
                    Numero = cliente.Numero,
                    Localidad = cliente.Localidad,
                    Provincia = cliente.Provincia,
                    CodigoPostal = cliente.CodigoPostal,
                    Activo = cliente.Activo,
                    RowVersion = cliente.RowVersion
                };

                return Result<ClienteUpdateDto>.Success(clienteDto);
            }
            catch (Exception ex)
            {
                return Result<ClienteUpdateDto>.Failure(ex.Message);
            }
        }
        public Result<ResultadoPaginacionDto<ClienteListDto>> ObtenerPaginado(
                int pagina,
                int cantidad,
                string campoOrden,
                bool esAscendente,
                bool? filtroActivo = null,
                string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Cliente, bool>>? filtro = c =>
                        (!filtroActivo.HasValue || c.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || c.Nombre.Contains(textoBuscar));


                Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>>? ordenarPor = campoOrden switch
                {
                    "TipoBombonId" => q => esAscendente ? q.OrderBy(c => c.ClienteId) : q.OrderByDescending(c => c.ClienteId),
                    _ => q => esAscendente ? q.OrderBy(c => c.Nombre) : q.OrderByDescending(c => c.Nombre),
                };

                var resultado = _unitOfWork.Clientes.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista
                    .Select(c => ClienteMapper.ToListDto(c)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<ClienteListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<ClienteListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<ClienteListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<List<ClienteListDto>> ObtenerDatosCombo(ClienteDefault defaultCliente)
        {
            try
            {
                var lista = _unitOfWork.Clientes.ObtenerTodos()
                    .Where(c => c.Activo) // Filtrar solo los clientes activos
                .Select(c => c.ToListDto()).ToList();
                if (defaultCliente == ClienteDefault.Todos)
                {
                    var clienteDefault = new ClienteListDto
                    {
                        ClienteId = 0,
                        NombreCompleto = "Todos"
                    };
                    lista.Insert(0, clienteDefault);

                }
                else
                {
                    var clienteDefault = new ClienteListDto
                    {
                        ClienteId = 0,
                        NombreCompleto = "Seleccione"
                    };
                    lista.Insert(0, clienteDefault);
                }
                return Result<List<ClienteListDto>>.Success(lista);

            }
            catch (Exception ex)
            {
                return Result<List<ClienteListDto>>
                    .Failure($"Error al poblar los datos del combo de clientes: {ex.Message}");
            }
        }
    }
}
