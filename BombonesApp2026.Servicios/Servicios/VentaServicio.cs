using BombonesApp2026.Datos;
using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;
using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.Common;
using BombonesApp2026.Servicios.DTOs.Venta;
using BombonesApp2026.Servicios.Intefaces;
using BombonesApp2026.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;

namespace BombonesApp2026.Servicios.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        public VentaServicio(IVentaRepositorio ventaRepositorio,
            IUnitOfWork unitOfWork)
        {
            _ventaRepositorio = ventaRepositorio;
            _unitOfWork = unitOfWork;
        }
        public Result<int> Agregar(VentaCreateDto ventaDto)
        {
            if(ventaDto is null)
            {
                return Result<int>.Failure("No se puede agregar una venta nula.");
            }
            var errores = new List<string>();
            if (ventaDto.ClienteId < 0)
            {
                errores.Add("El Id del cliente no puede ser negativo.");
            }
            var cliente=_unitOfWork.Clientes.ObtenerPorId(ventaDto.ClienteId);
            if(cliente is null)
            {
                errores.Add("El cliente no existe.");
            }else if (!cliente.Activo)
            {
                errores.Add("El cliente no está activo.");
            }
            if (ventaDto.FormaDePagoId <= 0)
            {
                errores.Add("La forma de pago no puede ser menor o igual a cero.");
            }
            var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(ventaDto.FormaDePagoId);
            if (formaDePago is null)
            {
                errores.Add("Forma de Pago inexistente");
            }else if (!formaDePago.Activo)
            {
                errores.Add("La forma de pago no está activa.");
            }
            if(ventaDto.Detalle is null|| ventaDto.Detalle.Count == 0)
            {
                errores.Add("La venta debe tener al menos un detalle");
            }
            else
            {
                foreach (var itemDetalle in ventaDto.Detalle)
                {
                    if (itemDetalle.ProductoId <= 0)
                    {
                        errores.Add("El Id del producto en el detalle no puede ser menor o igual a cero.");
                    }
                    var producto = _unitOfWork.Productos.ObtenerPorId(itemDetalle.ProductoId);
                    if (producto is null)
                    {
                        errores.Add($"El producto con Id {itemDetalle.ProductoId} no existe.");
                    }
                    else if (!producto.Activo)
                    {
                        errores.Add($"El producto {producto.Nombre} no está activo.");
                    }else if (producto.Stock < itemDetalle.Cantidad)
                    {
                        errores.Add(
                            $"Stock insuficiente de {producto.Nombre}. " +
                            $"Disponible: {producto.Stock}, " +
                            $"solicitado: {itemDetalle.Cantidad}.");
                    }
                    

                    if (itemDetalle.Cantidad <= 0)
                    {
                        errores.Add($"La cantidad del producto {producto?.Nombre ?? itemDetalle.ProductoId.ToString()} debe ser mayor a cero.");
                    }
                }
            }
            if(errores.Count > 0)
            {
                return Result<int>.Failure(errores);
            }
            try
            {
                Venta venta = new Venta(ventaDto.ClienteId, ventaDto.FormaDePagoId);
                foreach (var itemDetalle in ventaDto.Detalle!)     
                {
                    venta.AgregarDetalle(itemDetalle.ProductoId, 
                        itemDetalle.Cantidad, itemDetalle.Precio);
                }
                foreach (var itemDetalle in venta.Detalles)
                {
                    var producto = _unitOfWork.Productos.ObtenerPorId(itemDetalle.ProductoId);
                    if(producto is null)
                    {
                        return Result<int>.Failure($"El producto con Id {itemDetalle.ProductoId} no existe.");
                    }
                    producto.Stock -= itemDetalle.Cantidad;
                }
                _unitOfWork.Ventas.Agregar(venta);
                _unitOfWork.Save();
                return Result<int>.Success(venta.VentaId);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result<int>.Failure(
                    "Otro usuario modificó el stock de uno o más " +
                    "productos. Actualice los datos e intente nuevamente.");
            }
            catch (DbUpdateException ex)
            {
                return Result<int>.Failure(
                    $"No se pudo registrar la venta: {ex.GetBaseException().Message}");
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(
                    $"Error al registrar la venta: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<VentaListDto>> ObtenerPaginado(
            int pagina, int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtro, string? textoBuscar)
        {
            try
            {
                Func<IQueryable<Venta>, IOrderedQueryable<Venta>>? ordenarPor = campoOrdenar switch
                {
                    "VentaId" => q => esAscendente ? q.OrderBy(c => c.VentaId) : q.OrderByDescending(c => c.VentaId),
                    "FechaVenta" => q => esAscendente ? q.OrderBy(c => c.FechaVenta) : q.OrderByDescending(c => c.FechaVenta),
                    _ => q => esAscendente ? q.OrderBy(c => c.FechaVenta) : q.OrderByDescending(c => c.FechaVenta),
                };

                var resultado = _unitOfWork.Ventas.ObtenerPagina(pagina, cantidad, filtro, textoBuscar);
                var listaDto = resultado.lista
                    .Select(b => b.ToListDto()).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<VentaListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.cantidadRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<VentaListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<VentaListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<VentaDetailDto?> ObtenerPorId(int ventaId)
        {
            try
            {
                var venta = _unitOfWork.Ventas.ObtenerPorId(ventaId);
                if (venta == null)
                {
                    return Result<VentaDetailDto?>.Failure($"No se encontró la venta con ID {ventaId}");
                }
                return Result<VentaDetailDto?>.Success(venta.ToDetailDto());
            }
            catch (Exception ex)
            {
                return Result<VentaDetailDto?>.Failure($"Error al intentar obtener la venta: {ex.Message}");
            }
        }

        public Result<List<VentaListDto>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public Result Facturar(int ventaId)
        {
            if (ventaId <= 0)
                return Result.Failure("El ID de venta es inválido.");

            try
            {
                var venta = _ventaRepositorio.ObtenerPorId(ventaId);

                if (venta is null)
                    return Result.Failure(
                        $"No existe la venta ID {ventaId}.");

                if (venta.EstadoVenta != EstadoVenta.Pendiente)
                    return Result.Failure(
                        "Solamente se pueden facturar ventas pendientes.");

                if (!venta.Detalles.Any())
                    return Result.Failure(
                        "La venta no contiene detalles.");

                venta.Facturar();

                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure(
                    "Otro usuario modificó esta venta. " +
                    "Actualice la información e intente nuevamente.");
            }
            catch (DbUpdateException)
            {
                return Result.Failure(
                    "Ocurrió un error al facturar la venta.");
            }
        }

        public Result AnularVenta(int ventaId)
        {
            if (ventaId <= 0)
                return Result.Failure("El ID de venta es inválido.");

            try
            {
                var venta = _ventaRepositorio.ObtenerPorId(ventaId);

                if (venta is null)
                    return Result.Failure(
                        $"No existe la venta ID {ventaId}.");

                if (venta.EstadoVenta != EstadoVenta.Pendiente)
                    return Result.Failure(
                        "Solamente se pueden anular ventas pendientes.");

                if (!venta.Detalles.Any())
                    return Result.Failure(
                        "La venta no contiene detalles.");

                var productos = new List<(Producto Producto, int Cantidad)>();
                var errores = new List<string>();

                // Recuperar y validar todos los productos
                foreach (var detalle in venta.Detalles)
                {
                    var producto = _unitOfWork.Productos
                        .ObtenerPorId(detalle.ProductoId);

                    if (producto is null)
                    {
                        errores.Add(
                            $"No existe el producto ID {detalle.ProductoId}.");
                        continue;
                    }

                    if (detalle.Cantidad <= 0)
                    {
                        errores.Add(
                            $"Cantidad inválida para el producto {producto.Nombre}.");
                        continue;
                    }

                    if (producto.Stock > int.MaxValue - detalle.Cantidad)
                    {
                        errores.Add(
                            $"No se puede restituir el stock de {producto.Nombre}.");
                        continue;
                    }

                    productos.Add((producto, detalle.Cantidad));
                }

                if (errores.Count > 0)
                    return Result.Failure(errores);

                // Restituir stock
                foreach (var item in productos)
                {
                    item.Producto.Stock += item.Cantidad;
                }

                // Cambiar estado
                venta.Anular();

                // Guardar todos los cambios
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure(
                    "Otro usuario modificó la venta o el stock. " +
                    "Actualice los datos e intente nuevamente.");
            }
            catch (DbUpdateException)
            {
                return Result.Failure(
                    "Ocurrió un error al anular la venta.");
            }
        }

    }
}
