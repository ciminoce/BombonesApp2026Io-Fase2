using BombonesApp2026.Entidades;
using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface ICajaRepositorio:IRepositorioConcurrente<Caja>
    {
        bool Existe(Caja caja);
        bool EstaRelacionado(Caja caja);
        int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Caja, bool>>? filtrarPor);
        Caja? ObtenerCajaConDetalles(int productoId);
        void EliminarDetalle(DetalleCaja itemCaja);
    }
}
