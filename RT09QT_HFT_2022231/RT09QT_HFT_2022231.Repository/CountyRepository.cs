using RT09QT_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Repository
{
    public interface ICountyRepository
    {
        public void Create(County county);
        public void Update(County county);

        public void Delete(int id);
        public County Read(int id);
        public IQueryable<County> ReadAll();

    }
    public class CountyRepository : ICountyRepository
    {
       
        CountryDbContext context;
        public CountyRepository(CountryDbContext context)
        {
            this.context = context;
        }

        public void Create(County county)
        {
            this.context.Counties.Add(county);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.context.Counties.Remove(Read(id));
            this.context.SaveChanges();
        }
        public County Read(int id) { return this.context.Counties.FirstOrDefault(t => t.CountyID == id); }
        public IQueryable<County> ReadAll()
        {
            return this.context.Counties;
        }
        public void Update(County county)
        {
            var oldCounty = Read(county.CountyID);
            oldCounty.CountyName=county.CountyName;
            oldCounty.HomeCountry=county.HomeCountry;
            oldCounty.CountryID=county.CountryID;
            oldCounty.Towns=county.Towns;
            this.context.SaveChanges();
        }
    }
}
