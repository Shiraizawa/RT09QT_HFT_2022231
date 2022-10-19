﻿using System;
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
    }
}
