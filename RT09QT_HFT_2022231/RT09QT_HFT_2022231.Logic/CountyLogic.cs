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

        public IEnumerable<int> GetInhabitantCountPerCounty(int CountyID)
        {

            County county = (County)this.repository.ReadAll().Where(x => x.CountyID == CountyID);
            int count = 0;
            foreach (Town town in county.Towns)
            {
                count += town.InhabitantCount;
            }
            IEnumerable<int> result = new int[count];
            return result;
        }


    }
}
