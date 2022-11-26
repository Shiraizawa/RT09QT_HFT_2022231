using RT09QT_HFT_2022231.Logic;
using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RT09QT_HFT_2022231.Test
{
    public class CountryLogic : ICountryLogic
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
            if (Country == null)
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
        public IEnumerable<int> GetCountyCountPerCountry(int countryID)
        {
            IEnumerable<int> result = new int[] {this.repository
                .ReadAll()
                .Where(t => t.CountryID == countryID).Count()};
            return result;

        }
        public IEnumerable<int> GetTownCountPerCountry(int countryID)
        {
            Country country = (Country)this.repository.ReadAll().Where(x => x.CountryID == countryID).ToList()[0];
            int count = 0;
            foreach (County county in country.Counties)
            {
                count += county.Towns.Count();
            }
            IEnumerable<int> result = new int[] { count };
            return result;
        }
        public IEnumerable<CountryInhabitantStatistics> GetInhabitantCountPerCountry()
        {
            IEnumerable<Country> countries = this.repository.ReadAll();
            List<CountryInhabitantStatistics> result= new List<CountryInhabitantStatistics>();
            foreach (Country country in countries)
            {
                List<InhabitantStatistics> statistics = new List<InhabitantStatistics>();
                foreach (County county in country.Counties)
                {
                    
                    foreach (Town town in county.Towns)
                    {
                        int maleCount = 0;
                        int femaleCount = 0;
                        int avgAge = 0;
                        int count = 0;
                        foreach (Inhabitant inhabitant in town.Inhabitants)
                        {
                            if (inhabitant.Sex == true)
                                maleCount++;
                            else femaleCount++;
                            count++;
                            avgAge += inhabitant.Age;
                        }
                        statistics.Add(new InhabitantStatistics(maleCount, femaleCount, (avgAge / count), count));
                    }
                    
                }
                result.Add(new CountryInhabitantStatistics(statistics, country.CountryID));
            }
            return result;
        }
        public IEnumerable<CountryInhabitantStatistics> GetInhabitantCountPerSpecificCountry(int countryID)
        {
            IEnumerable<Country> countries = this.repository.ReadAll().Where(x=>x.CountryID==countryID);
            List<CountryInhabitantStatistics> result = new List<CountryInhabitantStatistics>();
            foreach (Country country in countries)
            {
                List<InhabitantStatistics> statistics = new List<InhabitantStatistics>();
                foreach (County county in country.Counties)
                {

                    foreach (Town town in county.Towns)
                    {
                        int maleCount = 0;
                        int femaleCount = 0;
                        double avgAge = 0;
                        int count = 0;
                        foreach (Inhabitant inhabitant in town.Inhabitants)
                        {
                            if (inhabitant.Sex == true)
                                maleCount++;
                            else femaleCount++;
                            count++;
                            avgAge += inhabitant.Age;
                        }
                        statistics.Add(new InhabitantStatistics(maleCount, femaleCount, (avgAge / count), count));
                    }

                }
                result.Add(new CountryInhabitantStatistics(statistics, country.CountryID));
            }
            return result;
        }
    }
    public class CountryInhabitantStatistics
    {
        IEnumerable<InhabitantStatistics> inhabitantStatistics { get; set;}
        public int countryID;
        public CountryInhabitantStatistics(IEnumerable<InhabitantStatistics> inhabitantStatistics, int country)
        {
            this.inhabitantStatistics = inhabitantStatistics;
            this.countryID = country;
        }
    }
}
