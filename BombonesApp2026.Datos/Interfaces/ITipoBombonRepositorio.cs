using BombonesApp2026.Entidades;
using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface ITipoBombonRepositorio:IRepositorioConcurrente<TipoBombon>
    {
        bool Existe(TipoBombon tipoBombon);
        bool EstaRelacionado(TipoBombon tipoBombon);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<TipoBombon, bool>>? filtrarPor=null);
    }
}
