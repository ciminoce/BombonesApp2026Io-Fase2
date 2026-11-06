using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Repositorios
{
    public class CajaRepositorio : RepositorioConcurrente<Caja>, ICajaRepositorio
    {
        public CajaRepositorio(BombonesDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Caja caja)
        {
            return false;
        }

        public bool Existe(Caja caja)
        {
            return _context.Cajas.Any(c=>c.Nombre==caja.Nombre && 
                    c.ProductoId!=caja.ProductoId);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Caja, bool>>? filtrarPor = null)
        {
            var cajaEnDb = ObtenerPorId(seleccionadoId);
            if (cajaEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.Nombre, cajaEnDb.Nombre) <= 0);
        }
        public override List<Caja> ObtenerTodos()
        {
            return _context.Cajas
                .Include(c => c.Detalles)
                .ThenInclude(d => d.Bombon)
                .AsNoTracking()
                .ToList();
        }
        public override Caja? ObtenerPorId(int id)
        {
            return _context.Cajas
                .Include(c => c.Detalles)
                .ThenInclude(d => d.Bombon)
                .AsNoTracking()
                .FirstOrDefault(c => c.ProductoId == id);
                            
        }
        public Caja? ObtenerCajaConDetalles(int id)
        {
            return _context.Cajas
                .Include(c => c.Detalles)
                .ThenInclude(d => d.Bombon)
                .FirstOrDefault(c => c.ProductoId == id);

        }

        public void EliminarDetalle(DetalleCaja itemCaja)
        {
            _context.Set<DetalleCaja>().Remove(itemCaja);
        }
    }
}
