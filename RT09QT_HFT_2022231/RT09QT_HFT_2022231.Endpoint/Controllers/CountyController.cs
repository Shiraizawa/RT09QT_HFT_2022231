using Microsoft.AspNetCore.Mvc;
using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RT09QT_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        ICountyLogic logic;

        public CountyController(ICountyLogic logic)
        {
            this.logic = logic;
        }
        // GET: api/<CountyController>
        [HttpGet]
        public IEnumerable<County> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<CountyController>/5
        [HttpGet("{id}")]
        public County Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<CountyController>
        [HttpPost]
        public void Create([FromBody] County value)
        {
            this.logic.Create(value);
        }

        // PUT api/<CountyController>/5
        [HttpPut]
        public void Put( [FromBody] County value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<CountyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
