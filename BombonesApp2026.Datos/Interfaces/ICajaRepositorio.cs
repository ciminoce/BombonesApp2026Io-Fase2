using BombonesApp2026.Entidades;
using System.Linq.Expressions;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface ICajaRepositorio:IRepositorioConcurrente<Caja>
    {
        bool Existe(Caja caja);
        bool TieneRegistrosRelacionados(int cajaId);
        int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Caja, bool>>? filtrarPor);
        Caja? ObtenerPorId(int productoId, bool tracked=false);
        void EliminarDetalle(DetalleCaja itemCaja);
    }
}
