using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

namespace RT09QT_HFT_2022231.Logic.Interfaces
{
    public interface ICountyLogic
    {
        void Create(County county);
        void Delete(int id);
        IEnumerable<InhabitantStatistics> GetInhabitantStatisticsPerCounty(int CountyID);
        IEnumerable<int> GetTownCountPerCounty(int countyId);
        County Read(int id);
        IEnumerable<County> ReadAll();
        void Update(County county);
    }
}