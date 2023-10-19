using Microsoft.EntityFrameworkCore;

namespace DoktormandenDk.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }  
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Læge A", Role = Role.PHYSICIAN },
                new User { Id = 2, Name = "Læge B", Role = Role.PHYSICIAN },
                new User { Id = 3, Name = "Patienten", Role = Role.PATIENT });
        }
    }
}
