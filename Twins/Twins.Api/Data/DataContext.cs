using Microsoft.EntityFrameworkCore;
using Twins.Shared.Entities;

namespace Twins.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
                
        }
        public DbSet<Day> Days { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonWeek> PersonWeeks { get; set; }
        public DbSet<State> Statements { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<WeekWorked> WeekWorkeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId","Name").IsUnique();
            modelBuilder.Entity<Person>().HasIndex("Id", "Email").IsUnique();
            modelBuilder.Entity<PersonWeek>().HasIndex("PersonId", "WeekWorkedId").IsUnique();
            modelBuilder.Entity<State>().HasIndex("CountryId","Name").IsUnique();
            modelBuilder.Entity<Street>().HasIndex("CityId","Name").IsUnique();
            modelBuilder.Entity<Day>().HasIndex("Id", "WeekWorkedId").IsUnique();

        }
    }
}
