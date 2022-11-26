using RT09QT_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Repository
{
    public interface IinhabitantRepository
    {
        public void Create(Inhabitant inhabitant);
        public void Update(Inhabitant inhabitant);

        public void Delete(int id);
        public Inhabitant Read(int id);
        public IQueryable<Inhabitant> ReadAll();
    }
    internal class InhabitantRepository : IinhabitantRepository
    {
        CountryDbContext context;
        public InhabitantRepository(CountryDbContext context)
        {
            this.context = context;
        }

        public void Create(Inhabitant  inhabitant)
        {
            this.context.Inhabitants.Add(inhabitant);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.context.Inhabitants.Remove(Read(id));
            this.context.SaveChanges();
        }

        public Inhabitant Read(int id) { return this.context.Inhabitants.FirstOrDefault(t => t.InhabitantID == id); }


        public IQueryable<Inhabitant> ReadAll()
        {
            return this.context.Inhabitants;
        }

        public void Update(Inhabitant inhabitant)
        {
            var oldInhabitant = Read(inhabitant.InhabitantID);
            oldInhabitant.Name= inhabitant.Name;
            oldInhabitant.Sex= inhabitant.Sex;
            oldInhabitant.Age= inhabitant.Age;
            oldInhabitant.LocationID= inhabitant.LocationID;
        }
    }
}
