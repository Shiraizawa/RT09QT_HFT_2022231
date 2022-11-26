﻿using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

namespace RT09QT_HFT_2022231.Logic
{
    public interface ICountyLogic
    {
        void Create(County county);
        void Delete(int id);
        IEnumerable<int> GetInhabitantCountPerCounty(int CountyID);
        IEnumerable<int> GetTownCountPerCounty(int countyId);
        County Read(int id);
        IEnumerable<County> ReadAll();
        void Update(County county);
    }
}