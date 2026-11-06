using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BombonesApp2026.Datos.EntityTypeConfiguration
{
    public class DetalleVentaEntityTypeConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVentas");

            // Clave primaria compuesta
            builder.HasKey(d => new
            {
                d.VentaId,
                d.ProductoId
            });

            builder.Property(d => d.Precio)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(d => d.Cantidad)
                .IsRequired();

            // Subtotal es una propiedad calculada
            builder.Ignore(d => d.Subtotal);

            // Relación con Producto
            builder.HasOne(d => d.Producto)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            // La relación con Venta ya está
            // configurada en VentaEntityTypeConfiguration.
        }
    }
}
