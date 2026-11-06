using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface IRepositorioGenerico<T> where T : class
    {
        List<T> ObtenerTodos();
        IQueryable<T> Query();
        T? ObtenerPorId(int id);
        void Agregar(T entidad);
        void Editar(T entidad, int id);
        void Borrar(int id);
        (List<T> lista, int totalRegistros) ObtenerPagina(int pagina,
            int cantidad,
            Func<IQueryable<T>, IOrderedQueryable<T>> ordenarPor,
            Expression<Func<T, bool>>? filtrarPor=null,
            Func<IQueryable<T>, IQueryable<T>>? incluir = null);
    }
}
