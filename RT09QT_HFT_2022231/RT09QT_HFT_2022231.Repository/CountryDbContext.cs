using System;
using Microsoft.EntityFrameworkCore;
using RT09QT_HFT_2022231.Models;

namespace RT09QT_HFT_2022231.Repository
{
    public class CountryDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Inhabitant> Inhabitants { get; set; }
        public DbSet<Town> Towns { get; set; }

        public CountryDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\country.mdf;Integrated Security=True;MultipleActiveResultSets= true";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { // create entity builders
            modelBuilder.Entity<City>(city => city
            .HasOne(city => city.CityName)
            .HasForeignKey(city => city.CountryID)
            .OnDelete(DeletBehavior.Cascade));

            modelBuilder.Entity<Country>()
                .HasOne(x => x.CountryName)
            
        }
    }
}
