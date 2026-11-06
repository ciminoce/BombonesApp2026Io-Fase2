using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades.Interfaces;

namespace BombonesApp2026.Datos.Repositorios
{
    public class RepositorioConcurrente<T> : RepositorioGenerico<T>,
        IRepositorioConcurrente<T> where T : class, IConcurrencyEntity
    {
        public RepositorioConcurrente(BombonesDbContext context) : base(context)
        {
        }
        public override void Borrar(int id)
        {
            throw new NotImplementedException("Debe utilizar la versión de concurrencia");
        }
        public void Borrar(int id, byte[] rowVersion)
        {
            var entidadEnDb = _dbSet.Find(id);
            if (entidadEnDb is null)
            {
                throw new KeyNotFoundException($"No se pudo borrar la entidad ID: {id} de la tabla {typeof(T).Name}");
            }
            
            var entidad = _context.Entry(entidadEnDb);
            entidad.OriginalValues["RowVersion"]=rowVersion;
            _dbSet.Remove(entidadEnDb);
        }

        public void Editar(T entidad, int id, byte[] rowVersion)
        {
            var entidadEnDb = _dbSet.Find(id);

            if (entidadEnDb is null)
            {
                throw new KeyNotFoundException(
                    $"No se encontró la entidad ID:{id}");
            }

            var entry = _context.Entry(entidadEnDb);

            entry.OriginalValues["RowVersion"] = rowVersion;

            entry.CurrentValues.SetValues(entidad);
        }
    }
}
