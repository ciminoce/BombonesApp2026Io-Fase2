using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Repositorios
{
    public class BombonRepositorio : RepositorioConcurrente<Bombon>, IBombonRepositorio
    {
        public BombonRepositorio(BombonesDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Bombon bombon)
        {
            return false;
        }

        public bool Existe(Bombon bombon)
        {
            return _context.Bombones
                .Any(b => b.Nombre == bombon.Nombre &&
                b.ProductoId != bombon.ProductoId);
        }
        public override List<Bombon> ObtenerTodos()
        {
            return _context.Bombones
                .Include(b => b.TipoBombon)
                .ToList();
        }
        public int ObtenerPosicionRegistro(int seleccionadoId, 
            Expression<Func<Bombon, bool>>? filtrarPor = null)
        {
            var bombonEnDb = ObtenerPorId(seleccionadoId);
            if (bombonEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.Nombre, bombonEnDb.Nombre) <= 0);
        }
        public override Bombon? ObtenerPorId(int id)
        {
            return _context.Bombones
                .Include(b => b.TipoBombon)
                .FirstOrDefault(b => b.ProductoId == id);
        }
    }
}
