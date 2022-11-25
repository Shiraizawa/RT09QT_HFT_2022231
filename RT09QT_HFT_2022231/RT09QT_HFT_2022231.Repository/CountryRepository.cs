using RT09QT_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Repository
{
    public interface ICountryRepository
    {
        public void Create(Country country);
        public void Update(Country country);

        public void Delete(int id);
        public Country Read(int id);
        public IQueryable<Country> ReadAll();
    }

    public class CountryRepository : ICountryRepository
    {
        CountryDbContext context;
        public CountryRepository(CountryDbContext context)
        {
            this.context = context;
        }

        public void Create(Country country)
        {
            this.context.Countries.Add(country);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.context.Countries.Remove(Read(id));
            this.context.SaveChanges();
        }
        public Country Read(int id) { return this.context.Countries.FirstOrDefault(t => t.CountryID == id); }
        public IQueryable<Country> ReadAll()
        {
            return this.context.Countries;
        }
        public void Update(Country country)
        {
            var oldCountry = Read(country.CountryID);
            oldCountry.CountryName = country.CountryName;
            oldCountry.Counties = country.Counties; 
            this.context.SaveChanges();
        }
    }
}
