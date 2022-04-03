using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data.Entities;

namespace SistemaVentas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Country> countries { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<City> cities { get; set; }

        public DbSet<State> states { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryID").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateID").IsUnique();
        }
    }
}
