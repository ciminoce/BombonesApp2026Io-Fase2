using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BombonesApp2026.Datos.EntityTypeConfiguration
{
    public class VentaEntityTypeConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Ventas");

            builder.HasKey(v => v.VentaId);

            builder.Property(v => v.VentaId)
                .ValueGeneratedOnAdd();

            builder.Property(v => v.FechaVenta)
                .IsRequired();

            builder.Property(v => v.ClienteId)
                .IsRequired();
            builder.Property(v => v.FormaDePagoId)
                .IsRequired();


            builder.Property(v => v.TotalVenta)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(v => v.EstadoVenta)
                .IsRequired();
            builder.Property(p => p.RowVersion)
    .IsRowVersion();


            // Relación Venta - Cliente
            builder.HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relación Venta - FormaDePago
            builder.HasOne(v => v.FormaDePago)
                .WithMany(f => f.Ventas)
                .HasForeignKey(v => v.FormaDePagoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Venta - DetalleVenta
            builder.HasMany(v => v.Detalles)
                .WithOne(d => d.Venta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Acceso directo a la colección privada
            builder.Navigation(v => v.Detalles)
                .HasField("_detalles")
                .UsePropertyAccessMode(
                    PropertyAccessMode.Field);
        }
    }
}
