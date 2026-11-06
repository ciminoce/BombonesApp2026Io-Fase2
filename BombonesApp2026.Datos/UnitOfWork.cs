using BombonesApp2026.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BombonesApp2026.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BombonesDbContext _context;
        public ITipoBombonRepositorio TipoBombones { get; }

        public IClienteRepositorio Clientes { get; }

        public IFormaDePagoRepositorio FormasDePago { get; }
        public IBombonRepositorio Bombones { get; set; }
        public ICajaRepositorio Cajas { get; set; }
        public IVentaRepositorio Ventas { get; set; }
        public IProductoRepositorio Productos { get; set; }
        public UnitOfWork(IFormaDePagoRepositorio formaDePagoRepositorio,
            IClienteRepositorio clienteRepositorio, 
            ITipoBombonRepositorio tipoBombonRepositorio,
            IBombonRepositorio bombonRepositorio,
            ICajaRepositorio cajaRepositorio,
            IVentaRepositorio ventaRepositorio,
            IProductoRepositorio productoRepositorio,
            BombonesDbContext context)
        {
            FormasDePago = formaDePagoRepositorio;
            Clientes = clienteRepositorio;
            TipoBombones = tipoBombonRepositorio;
            Bombones = bombonRepositorio;
            Cajas= cajaRepositorio;
            Ventas = ventaRepositorio;
            Productos = productoRepositorio;
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
