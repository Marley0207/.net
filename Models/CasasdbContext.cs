using Microsoft.EntityFrameworkCore;

namespace Test1.Models {
    public class CasasdbContext : DbContext {

        public CasasdbContext(DbContextOptions<CasasdbContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Venta_Casas>(entity => entity.ToTable("venta_casas_tb"));
        }

        public DbSet<Venta_Casas>Venta_Casas_tb { get; set; }
        public DbSet<Venta_Moto>Venta_Motos { get; set; }
        public DbSet<Venta_Carro>Venta_Carros { get; set; }
        public DbSet<Usuario>Usuarios { get; set; }
        public DbSet<Duenio>Duenios { get; set; }
        public DbSet<Casas_duenio>Casas_Duenios { get; set; }

        public DbSet<Carros_duenio>Carros_Duenios  {get; set; }
    }
}