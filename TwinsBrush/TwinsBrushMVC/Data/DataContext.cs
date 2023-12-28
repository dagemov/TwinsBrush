using Microsoft.EntityFrameworkCore;
using TwinsBrushMVC.Data.Entities;

namespace TwinsBrushMVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
            
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Street> Streets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c=>c.Id);
            modelBuilder.Entity<City>().HasIndex("Id","StateId");
            modelBuilder.Entity<State>().HasIndex("Id","CountryId");
            modelBuilder.Entity<Street>().HasIndex("Id", "CityId");
        }
    }
}
