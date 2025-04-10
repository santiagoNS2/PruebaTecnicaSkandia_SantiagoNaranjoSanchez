using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ACMEModeladoDatos.Modelos;

namespace ACMEModeladoDatos
{
    public class AppDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<RolPersona> RolesPersona { get; set; }
        public DbSet<CuentaAhorro> CuentasAhorro { get; set; }
        public DbSet<CuentaAhorroTitular> CuentasTitulares { get; set; }
        public DbSet<MovimientoCuenta> MovimientosCuenta { get; set; }
        public DbSet<TarjetaCredito> TarjetasCredito { get; set; }
        public DbSet<MovimientoTarjeta> MovimientosTarjeta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ACMEDB;Trusted_Connection=True;TrustServerCertificate=True;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación muchos a muchos entre CuentaAhorro y Persona
            modelBuilder.Entity<CuentaAhorroTitular>()
                .HasKey(ct => new { ct.CuentaAhorroId, ct.PersonaId });

            modelBuilder.Entity<CuentaAhorroTitular>()
                .HasOne(ct => ct.CuentaAhorro)
                .WithMany(c => c.Titulares)
                .HasForeignKey(ct => ct.CuentaAhorroId);

            modelBuilder.Entity<CuentaAhorroTitular>()
                .HasOne(ct => ct.Persona)
                .WithMany(p => p.Cuentas)
                .HasForeignKey(ct => ct.PersonaId);

            // ✅ Configurar precisión de decimales para evitar truncamiento

            modelBuilder.Entity<CuentaAhorro>(entity =>
            {
                entity.Property(e => e.SaldoTotal).HasPrecision(18, 2);
                entity.Property(e => e.SaldoCanje).HasPrecision(18, 2);
                entity.Property(e => e.SaldoDisponible).HasPrecision(18, 2);
            });

            modelBuilder.Entity<MovimientoCuenta>(entity =>
            {
                entity.Property(e => e.Monto).HasPrecision(18, 2);
            });

            modelBuilder.Entity<TarjetaCredito>(entity =>
            {
                entity.Property(e => e.CupoAprobado).HasPrecision(18, 2);
                entity.Property(e => e.CupoDisponible).HasPrecision(18, 2);
            });

            modelBuilder.Entity<MovimientoTarjeta>(entity =>
            {
                entity.Property(e => e.Monto).HasPrecision(18, 2);
            });
        }
    }
}
