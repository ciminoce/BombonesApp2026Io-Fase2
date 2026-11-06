using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BombonesApp2026.Datos.EntityTypeConfiguration
{
    public class DetalleCajaEntityTypeConfiguration : IEntityTypeConfiguration<DetalleCaja>
    {
        public void Configure(EntityTypeBuilder<DetalleCaja> builder)
        {
            builder.ToTable("DetalleCajas");
            builder.HasKey(d => new
            {
                d.CajaId,
                d.BombonId
            });
            builder.Property(d => d.BombonId).IsRequired();
            builder.Property(d => d.CajaId).IsRequired();
            builder.Property(d => d.Cantidad).IsRequired();

            builder.HasOne(d => d.Bombon)
                .WithMany(b => b.Detalles)
                .HasForeignKey(d => d.BombonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Caja)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.CajaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
