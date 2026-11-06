using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BombonesApp2026.Datos.EntityTypeConfiguration
{
    public class FormaDePagoEntityTypeConfiguration : IEntityTypeConfiguration<FormaDePago>
    {
        public void Configure(EntityTypeBuilder<FormaDePago> builder)
        {
            builder.ToTable("FormasDePago");
            builder.HasKey(f => f.FormaDePagoId);
            builder.Property(f=>f.Nombre).IsRequired().HasMaxLength(50);
            builder.HasIndex(f => f.Nombre, "IX_FormasDePago_Nombre").IsUnique();
        }
    }

}
