using BombonesApp2026.Entidades.Interfaces;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface IRepositorioConcurrente<T>:IRepositorioGenerico<T> where T : class,IConcurrencyEntity 
    {
        void Borrar(int id, byte[] rowVersion);
        void Editar(T entidad, int id, byte[] rowVersion);
    }
}
