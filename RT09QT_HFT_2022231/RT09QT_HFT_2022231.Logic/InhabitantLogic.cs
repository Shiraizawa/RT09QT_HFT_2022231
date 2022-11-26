using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Logic
{
    public class InhabitantLogic : IInhabitantLogic
    {
        IinhabitantRepository repository;
        public InhabitantLogic(IinhabitantRepository repository)
        {

            this.repository = repository;
        }
        public void Create(Inhabitant inhabitant)
        {
            if (inhabitant.Age < 0)
            {
                throw new ArgumentException("Age cannot be lower than zero.");
            }
            else if (inhabitant.Name == null)
            {
                throw new ArgumentException("Name cannot be null.");
            }
            else if (inhabitant.Sex == null)
            {
                throw new ArgumentException("There are only two genders. You must choose to belong to one.");
            }
            this.repository.Create(inhabitant);
        }
        public void Delete(int id)
        {
            var inhabitant = this.repository.Read(id);
            if (inhabitant == null)
            {
                throw new ArgumentException("This inhabitant does not exist");
            }
            this.repository.Delete(id);
        }
        public Inhabitant Read(int id)
        {
            var inhabitant = this.repository.Read(id);
            if (inhabitant == null)
            {
                throw new ArgumentException("This inhabitant does not exist");
            }
            return this.repository.Read(id);
        }
        public IEnumerable<Inhabitant> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Inhabitant inhabitant)
        {
            this.repository.Update(inhabitant);
        }
    }
}
