using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data.Entities;

namespace SistemaVentas.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Country> countries { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<City> cities { get; set; }

        public DbSet<Products> products { get; set; }

        public DbSet<ProductCategory> productCategories { get; set; }

        public DbSet<ProductImage> productImage { get; set; }

        public DbSet<State> states { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryID").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateID").IsUnique();
            modelBuilder.Entity<Products>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<ProductCategory>().HasIndex("ProductId", "CategoryID").IsUnique();
        }
    }
}
