using Microsoft.AspNetCore.Mvc;
using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RT09QT_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TownController : ControllerBase
    {
        ITownLogic logic;

        public TownController(ITownLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<TownController>
        [HttpGet]
        public IEnumerable<Town> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<TownController>/5
        [HttpGet("{id}")]
        public Town Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<TownController>
        [HttpPost]
        public void Create([FromBody] Town value)
        {
            this.logic.Create(value);
        }

        // PUT api/<TownController>/5
        [HttpPut]
        public void Update([FromBody] Town value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<TownController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
