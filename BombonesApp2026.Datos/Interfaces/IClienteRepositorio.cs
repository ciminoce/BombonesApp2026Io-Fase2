using BombonesApp2026.Entidades;

namespace BombonesApp2026.Datos.Interfaces
{
    public interface IClienteRepositorio:IRepositorioGenerico<Cliente>
    {
        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);

    }
}
