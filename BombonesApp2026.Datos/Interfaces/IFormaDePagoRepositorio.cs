using BombonesApp2026.Entidades;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface IFormaDePagoRepositorio:IRepositorioGenerico<FormaDePago>
    {
        bool Existe(FormaDePago formaDePago);
        bool EstaRelacionado(FormaDePago formaDePago);
    }
}
