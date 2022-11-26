using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

namespace RT09QT_HFT_2022231.Test
{
    public interface ICountryLogic
    {
        void Create(Country country);
        void Delete(int id);
        IEnumerable<int> GetCountyCountPerCountry(int countryID);
        IEnumerable<int> GetInhabitantCountPerCountry(int countryID);
        IEnumerable<int> GetTownCountPerCountry(int countryID);
        Country Read(int id);
        IEnumerable<Country> ReadAll();
        void Update(Country country);
    }
}