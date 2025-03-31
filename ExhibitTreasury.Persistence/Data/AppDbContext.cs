using Microsoft.EntityFrameworkCore;

namespace ExhibitTreasury.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        // Таблица залов музея
        public DbSet<Hall> Halls { get; set; } = default!;
        // Таблица экспонатов
        public DbSet<Exhibit> Exhibits { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация отношения "один-ко-многим" 
            modelBuilder.Entity<Hall>()
                .HasMany(h => h.Exhibits)
                .WithOne(e => e.Hall)
                .HasForeignKey(e => e.HallId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
