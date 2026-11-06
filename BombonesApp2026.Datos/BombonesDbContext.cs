using BombonesApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BombonesApp2026.Datos
{
    public class BombonesDbContext : DbContext
    {
        public DbSet<TipoBombon> TipoBombones { get; set; }
        public DbSet<FormaDePago> FormasDePago { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Bombon> Bombones  { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<DetalleCaja> DetalleCajas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BombonesIo2026Fase2;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().UseTptMappingStrategy();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BombonesDbContext).Assembly);
        }
    }
}
