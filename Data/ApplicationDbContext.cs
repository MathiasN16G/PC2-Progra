using Microsoft.EntityFrameworkCore;
using AdopcionMascotas.Modelos;

namespace AdopcionMascotas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Adoptante> Adoptantes { get; set; }
        public DbSet<Adopcion> Adopciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Una mascota solo puede tener una adopción
            modelBuilder.Entity<Adopcion>()
                .HasIndex(a => a.MascotaId)
                .IsUnique();

            // Relaciones
            modelBuilder.Entity<Adopcion>()
                .HasOne(a => a.Mascota)
                .WithOne(m => m.Adopcion)
                .HasForeignKey<Adopcion>(a => a.MascotaId);

            modelBuilder.Entity<Adopcion>()
                .HasOne(a => a.Adoptante)
                .WithMany(ad => ad.Adopciones)
                .HasForeignKey(a => a.AdoptanteId);
        }
    }
}
