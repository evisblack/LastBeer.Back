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
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Score> Scores { get; set; }

    }
}
