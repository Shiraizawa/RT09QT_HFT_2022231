using RT09QT_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Repository
{
    public class TownRepository
    {
        CountryDbContext context;
        public TownRepository(CountryDbContext context)
        {
            this.context = context;
        }

        public void Create(Town town)
        {
            this.context.Towns.Add(town);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.context.Towns.Remove(Read(id));
            this.context.SaveChanges();
        }
        public Town Read(int id) { return this.context.Towns.FirstOrDefault(t => t.TownID == id); }
        public IQueryable<Town> ReadAll()
        {
            return this.context.Towns;
        }
        public void Update(Town town)
        {
            var oldTown = Read(town.TownID);
            oldTown.TownName = town.TownName;
            oldTown.CountyID = town.CountyID; 
            oldTown.HomeCounty = town.HomeCounty;
            this.context.SaveChanges();
        }
    }
}
