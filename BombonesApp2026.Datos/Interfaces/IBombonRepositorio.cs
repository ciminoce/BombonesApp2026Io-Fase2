using BombonesApp2026.Entidades;
using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface IBombonRepositorio : IRepositorioConcurrente<Bombon>
    {
        bool Existe(Bombon bombon);
        bool EstaRelacionado(Bombon bombon);
        int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Bombon, bool>>? filtrarPor);
    }
}
