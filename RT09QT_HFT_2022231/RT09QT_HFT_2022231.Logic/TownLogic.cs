﻿using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Logic
{
    internal class TownLogic : ITownLogic
    {
        ITownRepository repository;

        public TownLogic(ITownRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Town town)
        {
            this.repository.Create(town);
        }

        public void Delete(int id)
        {
            var town = this.repository.Read(id);
            if (town == null)
            {
                throw new ArgumentException("This town does not exist");
            }
            this.repository.Delete(id);
        }

        public Town Read(int id)
        {
            var town = this.repository.Read(id);
            if (town == null)
            {
                throw new ArgumentException("This town does not exist");
            }
            return this.repository.Read(id);
        }

        public IEnumerable<Town> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Town town)
        {
            this.repository.Update(town);
        }
    }
}