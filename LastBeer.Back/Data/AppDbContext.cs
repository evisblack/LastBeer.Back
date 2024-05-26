using LastBeer.Back.Models;
using Microsoft.EntityFrameworkCore;

namespace LastBeer.Back.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavouriteBar> FavouriteBars { get; set; }
        public DbSet<VisitedBar> VisitedBars { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índice único para PlaceId en la tabla Bar
            modelBuilder.Entity<Bar>()
                .HasIndex(b => b.PlaceId)
                .IsUnique();

            // Índice único compuesto para UserId y BarId en la tabla FavouriteBar
            modelBuilder.Entity<FavouriteBar>()
                .HasIndex(fb => new { fb.UserId, fb.BarId })
                .IsUnique();
        }

    }
}
