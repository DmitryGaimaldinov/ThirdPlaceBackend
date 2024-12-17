using Microsoft.EntityFrameworkCore;
using ThirdPlaceBackend.Src.UserEventLib;
using ThirdPlaceBackend.Src.UserLib;

namespace ThirdPlaceBackend.Src
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserEvent> UserEvents { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            // Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEvent>()
                .Navigation(e => e.Creator)
                .AutoInclude();
        }
    }
}
