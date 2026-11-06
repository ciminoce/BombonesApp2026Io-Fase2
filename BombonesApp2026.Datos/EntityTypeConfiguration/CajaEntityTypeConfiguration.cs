using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BombonesApp2026.Datos.EntityTypeConfiguration
{
    public class CajaEntityTypeConfiguration : IEntityTypeConfiguration<Caja>
    {
        public void Configure(EntityTypeBuilder<Caja> builder)
        {
            builder.ToTable("Cajas");

        }
    }
}
