using Microsoft.AspNetCore.Mvc;
using RT09QT_HFT_2022231.Logic.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RT09QT_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICountryLogic logic;

        public StatController(ICountryLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet("{countryId}")]
        public IEnumerable<int> GetCountyCountPerCountry(int countryId)
        {
            return this.logic.GetCountyCountPerCountry(countryId);
        }
        [HttpGet]
        public IEnumerable<int> GetCountyCountAllCountry()
        {
            return this.logic.GetCountyCountAllCountry();
        }
        [HttpGet("{countryId}")]
        public IEnumerable<int> GetTownCountPerCountry(int countryId)
        {
            return this.logic.GetTownCountPerCountry(countryId);
        }
        [HttpGet]
        public IEnumerable<Logic.CountryLogic.CountryInhabitantStatistics> GetInhabitantStatisticsPerCountry()
        {
            return this.logic.GetInhabitantStatisticsPerCountry();
        }
        [HttpGet("{countryId}")]
        public IEnumerable<Logic.CountryLogic.CountryInhabitantStatistics> GetInhabitantStatisticsPerSpecificCountry(int countryId)
        {
            return this.logic.GetInhabitantStatisticsPerSpecificCountry(countryId);
        }
    }
}
