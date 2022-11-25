using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace RT09QT_HFT_2022231.Logic
{
    public class CountyLogic
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
        //Folytköv
        public int? GetTownCountPerCounty(int countyId)
        {
            return this.repository
                .ReadAll()
                .Where(t => t.CountyID == countyId).Count();
        }

        public int? GetInhabitantCountPerCounty()
        {
           
            return from x in this.repository.ReadAll()
        }

        //Folytköv
    }
}
