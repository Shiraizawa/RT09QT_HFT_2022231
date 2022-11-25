using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RT09QT_HFT_2022231.Test
{
    public class CountryLogic
    {
        ICountryRepository repository;

        public CountryLogic(ICountryRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Country country)
        {
            if (country.CountryName.Length < 4) { throw new ArgumentException("Country name is too short."); }
            else
            {
                this.repository.Create(country);
            }
        }

        public void Delete(int id)
        {
            var Country = this.repository.Read(id);
            if (Country == null)
            {
                throw new ArgumentException("This country does not exist");
            }
                this.repository.Delete(id);
        }

        public Country Read(int id)
        {
            var Country = this.repository.Read(id);
            if(Country == null)
            {
                throw new ArgumentException("This country does not exist");
            }
           return this.repository.Read(id);
        }

        public IEnumerable<Country> ReadAll()
        {
          return this.repository.ReadAll();
        }

       public void Update(Country country)
        {
            this.repository.Update(country);
        }
        public int? GetCountyCountPerCountry(int countryId)
        {
            return this.repository
                .ReadAll()
                .Where(t => t.CountryID == countryId).Count();
        }
    }
}
