using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BombonesApp2026.Datos.EntityTypeConfiguration
{
    public class TipoBombonEntityTypeConfiguration : IEntityTypeConfiguration<TipoBombon>
    {
        public void Configure(EntityTypeBuilder<TipoBombon> builder)
        {
            builder.ToTable("TipoBombones");
            builder.HasKey(tb => tb.TipoBombonId);
            builder.Property(tb => tb.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(tb => tb.Descripcion).HasMaxLength(150);
            builder.HasIndex(tb => tb.Nombre, "IX_TipoBombones_Nombre").IsUnique();
            builder.Property(tb => tb.RowVersion).IsRowVersion();
            //TODO: Luego relacionar con Bombones
        }
    }
}
