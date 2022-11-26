﻿using Microsoft.AspNetCore.Mvc;
using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Models;
using System.Collections.Generic;

namespace RT09QT_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
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
        public IEnumerable<Country> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public Country Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Create([FromBody] Country value)
        {
            this.logic.Create(value);
        }

        // PUT api/<CountryController>/5
        [HttpPut]
        public void Update([FromBody] Country value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
