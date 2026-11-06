using BombonesApp2026.Entidades;
using BombonesApp2026.Entidades.Enums;
using BombonesApp2026.Servicios.DTOs.Venta;
using System;
using System.Collections.Generic;
using System.Text;

namespace BombonesApp2026.Servicios.Mapeadores
{
    public static class VentaMapper
    {
        public static VentaListDto ToListDto(this Venta venta)
        {
            return new VentaListDto
            {
                VentaId = venta.VentaId,
                FechaVenta = DateOnly.FromDateTime(venta.FechaVenta),
                Cliente = $"{venta.Cliente.Nombre} {venta.Cliente.Apellido}",
                Total = venta.TotalVenta,
                EstadoVenta = (EstadoVenta)venta.EstadoVenta
            };
        }
        public static VentaDetailDto ToDetailDto(this Venta venta)
        {
            return new VentaDetailDto
            {
                VentaId = venta.VentaId,
                FechaVenta = DateOnly.FromDateTime(venta.FechaVenta),
                Cliente = $"{venta.Cliente.Nombre} {venta.Cliente.Apellido}",
                Total = venta.TotalVenta,
                EstadoVenta = (EstadoVenta)venta.EstadoVenta,
                FormaDePago = venta.FormaDePago.Nombre,
                DetalleVentas = venta.Detalles
                                .Select(d => d.ToDto()).ToList()
            };
        }
    }
}
