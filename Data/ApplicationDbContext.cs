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

    // Asegurar que una mascota solo tenga una adopción
    modelBuilder.Entity<Adopcion>()
        .HasIndex(a => a.MascotaId)
        .IsUnique();

    // Relación 1:1 desde Adopcion hacia Mascota
    modelBuilder.Entity<Adopcion>()
        .HasOne(a => a.Mascota)
        .WithMany()
        .HasForeignKey(a => a.MascotaId)
        .OnDelete(DeleteBehavior.Cascade);

    // Relación 1:N desde Adoptante hacia Adopciones
    modelBuilder.Entity<Adopcion>()
        .HasOne(a => a.Adoptante)
        .WithMany(ad => ad.Adopciones)
        .HasForeignKey(a => a.AdoptanteId);
}

    }
}
