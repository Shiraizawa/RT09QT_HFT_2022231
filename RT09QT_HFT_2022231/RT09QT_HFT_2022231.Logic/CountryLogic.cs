using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RT09QT_HFT_2022231.Logic
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
            IEnumerable<Country> holder =this.repository
                .ReadAll()
                .Where(t => t.CountryID == countryID);
            int count = 0;
            foreach (Country country in holder)
            {
                foreach(County county in country.Counties)
                {
                    count++;
                }
            }
            IEnumerable<int> result= new List<int>() { count};
            return result;

        }

        public IEnumerable<int> GetCountyCountAllCountry()
        {
            IEnumerable<Country> holder = this.repository
                .ReadAll();
            List<int> counts= new List<int>();
            
            foreach (Country country in holder)
            {
                int count = 0;
                foreach (County county in country.Counties)
                {
                    count++;
                }
                counts.Add(count);
            }
            IEnumerable<int> result = counts;
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
        public IEnumerable<CountryInhabitantStatistics> GetInhabitantStatisticsPerCountry()
        {
            IEnumerable<Country> countries = this.repository.ReadAll();
            List<CountryInhabitantStatistics> result = new List<CountryInhabitantStatistics>();
            foreach (Country country in countries)
            {
                int maleCount = 0;
                int femaleCount = 0;
                int avgAge = 0;
                int count = 0;

                foreach (County county in country.Counties)
                {

                    foreach (Town town in county.Towns)
                    {

                        foreach (Inhabitant inhabitant in town.Inhabitants)
                        {
                            if (inhabitant.Sex == true)
                                maleCount++;
                            else femaleCount++;
                            count++;
                            avgAge += inhabitant.Age;
                        }

                    }

                }
                result.Add(new CountryInhabitantStatistics(maleCount, femaleCount, (avgAge / count), count, country.CountryID));
            }
            return result;
        }
        public IEnumerable<CountryInhabitantStatistics> GetInhabitantStatisticsPerSpecificCountry(int countryID)
        {
            IEnumerable<Country> countries = this.repository.ReadAll().Where(x=>x.CountryID==countryID);
            List<CountryInhabitantStatistics> result = new List<CountryInhabitantStatistics>();
            foreach (Country country in countries)
            {
                int maleCount = 0;
                int femaleCount = 0;
                int avgAge = 0;
                int count = 0;

                foreach (County county in country.Counties)
                {

                    foreach (Town town in county.Towns)
                    {
                        
                        foreach (Inhabitant inhabitant in town.Inhabitants)
                        {
                            if (inhabitant.Sex == true)
                                maleCount++;
                            else femaleCount++;
                            count++;
                            avgAge += inhabitant.Age;
                        }
                        
                    }

                }
                result.Add(new CountryInhabitantStatistics(maleCount, femaleCount, (avgAge / count), count,country.CountryID));
            }
            return result;
        }
        public class CountryInhabitantStatistics
        {
            public int maleCount { get; set; }
            public int femaleCount { get; set; }
            public int averageAge { get; set; }
            public int allInhabitants { get; set; }
            public int countryID;
            public CountryInhabitantStatistics(int maleCount, int femaleCount, int averageAge, int allInhabitants, int countryID)
            {
                this.maleCount = maleCount;
                this.femaleCount = femaleCount;
                this.averageAge = averageAge;
                this.allInhabitants = allInhabitants;
                this.countryID = countryID;
            }
            public CountryInhabitantStatistics()
            {

            }

            public override bool Equals(object obj)
            {
                CountryInhabitantStatistics b = obj as CountryInhabitantStatistics;
                if (b == null) return false;
                else
                {
                    return this.maleCount == b.maleCount && this.femaleCount == b.femaleCount && this.averageAge == b.averageAge && this.allInhabitants == b.allInhabitants && this.countryID == b.countryID; ;
                }

            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.maleCount, this.femaleCount, this.averageAge, this.allInhabitants, this.countryID);
            }
        }
    }
    
}
