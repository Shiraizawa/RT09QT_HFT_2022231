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
            this.repository.Create(country);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Country Read(int id)
        {
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
    }
}
