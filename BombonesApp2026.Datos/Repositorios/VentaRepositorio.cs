using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BombonesApp2026.Datos.Repositorios
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly BombonesDbContext _context;
        public VentaRepositorio(BombonesDbContext context)
        {
            _context = context;
        }
        public void Agregar(Venta venta)
        {
            _context.Ventas.Add(venta);
        }

        public (List<Venta> lista, int cantidadRegistros) ObtenerPagina(int paginaActual, int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            IQueryable<Venta> query = _context
                .Ventas
                .Include(v => v.Cliente)
                .AsNoTracking();
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                query = query.Where(v => v.Cliente.Nombre.Contains(textoBuscar));
            }
            var cantidad = query.Count();
            var lista = query
                .OrderBy(v => v.FechaVenta)
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina)
                .ToList();
            return (lista, cantidad);
        }

        public Venta? ObtenerPorId(int ventaId)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.FormaDePago)
                .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
                .FirstOrDefault(v => v.VentaId == ventaId);
        }

        public List<Venta> ObtenerTodos()
        {
            return _context.Ventas.AsNoTracking().ToList();
        }
    }
}
