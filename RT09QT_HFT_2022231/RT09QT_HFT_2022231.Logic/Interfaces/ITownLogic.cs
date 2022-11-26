using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

namespace RT09QT_HFT_2022231.Logic.Interfaces
{
    public interface ITownLogic
    {
        void Create(Town town);
        void Delete(int id);
        Town Read(int id);
        IEnumerable<Town> ReadAll();
        void Update(Town town);
    }
}