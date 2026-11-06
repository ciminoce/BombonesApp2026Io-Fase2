using BombonesApp2026.Entidades;
using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface IBombonRepositorio : IRepositorioConcurrente<Bombon>
    {
        bool Existe(Bombon bombon);
        bool TieneRegistrosRelacionados(int bombonId);
        int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Bombon, bool>>? filtrarPor);
    }
}
