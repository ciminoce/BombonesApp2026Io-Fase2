using BombonesApp2026.Datos.Interfaces;

namespace BombonesApp2026.Datos
{
    public interface IUnitOfWork:IDisposable
    {
        ITipoBombonRepositorio TipoBombones { get; }
        IClienteRepositorio Clientes { get; }
        IFormaDePagoRepositorio FormasDePago{ get; }
        IBombonRepositorio Bombones { get; }
        ICajaRepositorio Cajas { get; }
        IVentaRepositorio Ventas { get; }
        IProductoRepositorio Productos { get; }
        void Save();
    }
}
