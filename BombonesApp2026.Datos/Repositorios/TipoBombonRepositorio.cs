using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Repositorios
{
    public class TipoBombonRepositorio : RepositorioConcurrente<TipoBombon>, ITipoBombonRepositorio
    {
        public TipoBombonRepositorio(BombonesDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(TipoBombon tipoBombon)
        {
            return false;
        }

        public bool Existe(TipoBombon tipoBombon)
        {
            return _context.TipoBombones
                .Any(tb => tb.Nombre == tipoBombon.Nombre &&
                tb.TipoBombonId != tipoBombon.TipoBombonId);
        }
        public override TipoBombon? ObtenerPorId(int id)
        {
            return _context.TipoBombones
                .AsNoTracking()
                .FirstOrDefault(tp => tp.TipoBombonId == id);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<TipoBombon, bool>>? filtrarPor=null)
        {
            var tipoEnDb = ObtenerPorId(seleccionadoId);
            if (tipoEnDb is null) return 0;
            var query = Query();
            if(filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.Nombre, tipoEnDb.Nombre) <= 0);
        }
    }
}
