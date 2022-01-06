using DeleteMe.Models;
using Microsoft.EntityFrameworkCore;

namespace DeleteMe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(new DbContextOptions<AppDbContext>())
        {
            
        }
        
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DBC.db");
        }
    }
}