using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BombonesApp2026.Datos.EntityTypeConfiguration
{
    public class ProductoEntityTypeConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(p => p.ProductoId);
            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Descripcion).HasMaxLength(250);
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.Activo).IsRequired();
            builder.Property(p => p.RowVersion)
                .IsRowVersion();
        }
    }
}
