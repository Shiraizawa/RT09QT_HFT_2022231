using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

namespace RT09QT_HFT_2022231.Logic.Interfaces
{
    public interface IInhabitantLogic
    {
        void Create(Inhabitant inhabitant);
        void Delete(int id);
        Inhabitant Read(int id);
        IEnumerable<Inhabitant> ReadAll();
        void Update(Inhabitant inhabitant);
    }
}