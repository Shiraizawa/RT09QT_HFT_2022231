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
            this.repository.Update(county);
        }
        public IEnumerable<int> GetTownCountPerCounty(int countyId)
        {
            IEnumerable<int> result = new int[] {this.repository
                .ReadAll()
                .Where(t => t.CountyID == countyId).Count()};
            return result;
        }

        public IEnumerable<InhabitantStatistics> GetInhabitantStatisticsPerCounty( int CountyID)
        {

             County county = (County)this.repository.ReadAll().Where(x => x.CountyID == CountyID);
             List<InhabitantStatistics> statistics= new List<InhabitantStatistics>();
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
                statistics.Add(new InhabitantStatistics(maleCount,femaleCount,(avgAge/count),count));
             }
            IEnumerable<InhabitantStatistics> result = statistics;
            return result;

        }


    }
    public class InhabitantStatistics
    {
        public int maleCount { get; set; }
        public int femaleCount { get; set; }
        public double? averageAge { get; set; }
        public int allInhabitants { get; set; }
        public InhabitantStatistics(int maleCount,  int femaleCount, double averageAge, int allInhabitants)
        {
            this.maleCount= maleCount;
            this.femaleCount= femaleCount;
            this.averageAge= averageAge;
            this.allInhabitants= allInhabitants;
        }
    }
}