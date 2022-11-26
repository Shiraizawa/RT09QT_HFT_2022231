using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace RT09QT_HFT_2022231.Logic
{
    public class CountyLogic : ICountyLogic
    {
        ICountyRepository repository;

        public CountyLogic(ICountyRepository repository)
        {
            this.repository = repository;
        }

        public void Create(County county)
        {
            if(county.CountyName== null) { throw new ArgumentException("County name cannot be null."); }
            else if(county.CountryID==null || county.CountryID==0) { throw new ArgumentException("Country ID cannot be null or zero."); }

            this.repository.Create(county);
        }

        public void Delete(int id)
        {
            var County = this.repository.Read(id);
            if (County == null)
            {
                throw new ArgumentException("This county does not exist");
            }
            this.repository.Delete(id);
        }

        public County Read(int id)
        {
            var County = this.repository.Read(id);
            if (County == null)
            {
                throw new ArgumentException("This county does not exist");
            }
            return this.repository.Read(id);
        }

        public IEnumerable<County> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(County county)
        {
            if (county.CountyName == null) { throw new ArgumentException("County name cannot be null."); }
            else if (county.CountryID == null || county.CountryID == 0) { throw new ArgumentException("Country ID cannot be null or zero."); }
            this.repository.Update(county);
        }


    }
    public class InhabitantStatistics
    {
        public int maleCount { get; set; }
        public int femaleCount { get; set; }
        public int averageAge { get; set; }
        public int allInhabitants { get; set; }
        public InhabitantStatistics(int maleCount,  int femaleCount, int averageAge, int allInhabitants)
        {
            this.maleCount= maleCount;
            this.femaleCount= femaleCount;
            this.averageAge= averageAge;
            this.allInhabitants= allInhabitants;
        }
        public override bool Equals(object obj)
        {
            InhabitantStatistics b= obj  as InhabitantStatistics;
            if (b==null) return false;
            else
            {
                return this.maleCount==b.maleCount && this.femaleCount==b.femaleCount && this.averageAge == b.averageAge && this.allInhabitants==b.allInhabitants;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.maleCount,this.femaleCount,this.averageAge,this.allInhabitants);
        }
    }
}