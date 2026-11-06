using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BombonesApp2026.Datos.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly BombonesDbContext _context;

        public ProductoRepositorio(BombonesDbContext context)
        {
            _context = context;
        }

        public Producto? ObtenerPorId(int productoId, bool tracked=false)
        {
            IQueryable<Producto> query = _context.Productos
                .Include(p => ((Caja)p).Detalles)
                .ThenInclude(d => d.Bombon);
            if (tracked)
            {
                return query.FirstOrDefault(p => p.ProductoId == productoId);
            }
            
            return query.AsNoTracking()
                    .FirstOrDefault(p => p.ProductoId == productoId);
        }

        public List<Producto> ObtenerTodos()
        {
            return _context.Productos
                .Include(p=>((Caja)p).Detalles)
                .ThenInclude(d=>d.Bombon)
                .ToList();
        }
    }
}
