using Microsoft.AspNetCore.Mvc;
using RT09QT_HFT_2022231.Logic.Interfaces;
using System.Collections.Generic;

namespace RT09QT_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryLogic logic;

        public CountryController(ICountryLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
