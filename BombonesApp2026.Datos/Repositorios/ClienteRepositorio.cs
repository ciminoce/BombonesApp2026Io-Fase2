using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;

namespace BombonesApp2026.Datos.Repositorios
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(BombonesDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            //Luego relacionar con Ventas
            return false;
        }

        public bool Existe(Cliente cliente)
        {
            return _context.Clientes
                .Any(c => c.Documento == cliente.Documento &&
                c.ClienteId != cliente.ClienteId);
        }

    }
}
