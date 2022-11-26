using Microsoft.AspNetCore.Mvc;
using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RT09QT_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InhabitantController : ControllerBase
    {
        IInhabitantLogic logic;

        public InhabitantController(IInhabitantLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<InhabitantController>
        [HttpGet]
        public IEnumerable<Inhabitant> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<InhabitantController>/5
        [HttpGet("{id}")]
        public Inhabitant Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<InhabitantController>
        [HttpPost]
        public void Create([FromBody] Inhabitant value)
        {
            this.logic.Create(value);
        }

        // PUT api/<InhabitantController>/5
        [HttpPut]
        public void Update([FromBody] Inhabitant value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<InhabitantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
