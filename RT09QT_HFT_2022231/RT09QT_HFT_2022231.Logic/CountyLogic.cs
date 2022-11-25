using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;

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
            this.repository.Delete(id);
        }

        public County Read(int id)
        {
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
    }
}
