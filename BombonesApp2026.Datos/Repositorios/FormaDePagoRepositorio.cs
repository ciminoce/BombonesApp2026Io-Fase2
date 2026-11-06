using BombonesApp2026.Datos.Interfaces;
using BombonesApp2026.Entidades;

namespace BombonesApp2026.Datos.Repositorios
{
    public class FormaDePagoRepositorio : RepositorioGenerico<FormaDePago>, IFormaDePagoRepositorio
    {
        public FormaDePagoRepositorio(BombonesDbContext context) : base(context)
        {
        }

        public bool TieneRegistrosRelacionados(int formaId)
        {
            //luego relacionar con ventas
            return _context.Ventas.Any(v => v.FormaDePagoId == formaId);
        }
        public bool Existe(FormaDePago formaDePago)
        {
            return _context.FormasDePago
                .Any(f => f.Nombre == formaDePago.Nombre &&
                f.FormaDePagoId != formaDePago.FormaDePagoId);
        }

    }
}
