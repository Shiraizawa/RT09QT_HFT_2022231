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
                builder
                    .UseInMemoryDatabase("country")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { // create entity builders

            modelBuilder.Entity<Country>()
                .HasMany(x => x.Cities)
                .WithOne(x=>x.HomeCountry)
                .OnDelete(DeleteBehavior.Cascade)
            ;
            modelBuilder.Entity<Country>()
                .HasMany(x => x.Towns)
                .WithOne(x => x.HomeCountry)
                .OnDelete(DeleteBehavior.Cascade)
            ;

            modelBuilder.Entity<City>()
                .HasOne(x=>x.HomeCountry)
                .WithMany(x=>x.Cities)
                .HasForeignKey(x=>x.CountryID)
                .OnDelete(DeleteBehavior.Cascade)
            ;

            modelBuilder.Entity<Town>()
                .HasOne(x => x.HomeCountry)
                .WithMany(x => x.Towns)
                .HasForeignKey(x => x.CountryID)
                .OnDelete(DeleteBehavior.Cascade)
            ;

            modelBuilder.Entity<Country>().HasData(new Country[]{
                new Country(1,"Azerbaijan"),
                new Country(2,"Belgium"),
                new Country(3,"Canada"),
                new Country(4,"Denmark")
            });

            modelBuilder.Entity<Town>().HasData(new Town[]
            {
                new Town(1,"Abadkend",1),
                new Town(2,"Abad",1),
                new Town(3,"Dinant",2),
                new Town(4,"Killarney",3),
                new Town(5,"Ribe",4)

            });

            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City(1,"Baku",1),
                new City(2,"Brussels",2),
                new City(3,"Quebec", 3),
                new City(4,"Aarhus",4)
            });

        }
    }
}
