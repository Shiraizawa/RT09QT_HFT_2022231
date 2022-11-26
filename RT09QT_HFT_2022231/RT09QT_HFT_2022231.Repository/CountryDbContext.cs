using System;
using Microsoft.EntityFrameworkCore;
using RT09QT_HFT_2022231.Models;

namespace RT09QT_HFT_2022231.Repository
{
    public class CountryDbContext : DbContext
    {
        public DbSet<County> Counties { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Inhabitant> Inhabitants { get; set; }

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
        { 

            modelBuilder.Entity<Country>()
                .HasMany(x => x.Counties)
                .WithOne(x=>x.HomeCountry)
                .HasForeignKey(x=>x.CountryID)
                .OnDelete(DeleteBehavior.Cascade)
            ;


            modelBuilder.Entity<County>()
                .HasMany(x=> x.Towns)
                .WithOne(x=> x.HomeCounty)
                .HasForeignKey(x=>x.CountyID)
                .OnDelete(DeleteBehavior.Cascade)
            ;

            modelBuilder.Entity<Town>()
                .HasOne(x => x.HomeCounty)
                .WithMany(x => x.Towns)
                .HasForeignKey(x => x.CountyID)
                .OnDelete(DeleteBehavior.Cascade)
            ;
            modelBuilder.Entity<Inhabitant>()
                .HasOne(x => x.Location)
                .WithMany(x => x.Inhabitants)
                .OnDelete(DeleteBehavior.Cascade)
            ;
            modelBuilder.Entity<Country>().HasData(new Country[]{
                new Country("1#Azerbaijan"),
                new Country("2#Belgium"),
                new Country("3#Canada"),
                new Country("4#Denmark")
            });

            modelBuilder.Entity<County>().HasData(new County[]
            {
                new County("1#Salyan District#1"),
                new County("2#Namur#2"),
                new County("3#Ontario#3"),
                new County("4#Ribe County#4")
            });

            modelBuilder.Entity<Town>().HasData(new Town[]
            {
                new Town("1#Abadkend#1"),
                new Town("2#Abad#1"),
                new Town("3#Dinant#2"),
                new Town("4#Killarney#3"),
                new Town("5#Ribe#4")

            });

            modelBuilder.Entity<Inhabitant>().HasData(new Inhabitant[]
            {

            });


        }
    }
}
