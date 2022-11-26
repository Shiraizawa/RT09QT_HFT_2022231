using System;
using System.Collections.Generic;
using System.Linq;
using RT09QT_HFT_2022231.Logic;
using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using RT09QT_HFT_2022231.Test;

namespace RT09QT_HFT_2022231
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CountryDbContext ctx = new CountryDbContext(); ;
            var items = ctx.Countries.ToArray();
            CountryLogic aaa =new CountryLogic(new CountryRepository(ctx));
            IEnumerable<int> a= aaa.GetCountyCountPerCountry(0);
            IEnumerable<int> b = aaa.GetCountyCountPerCountry(1);
            IEnumerable<int> c = aaa.GetCountyCountPerCountry(2);
            IEnumerable<int> d = aaa.GetCountyCountPerCountry(3);
            IEnumerable<int> e = aaa.GetCountyCountPerCountry(4);
            IEnumerable<CountryInhabitantStatistics> count = aaa.GetInhabitantCountPerCountry();
            IEnumerable<CountryInhabitantStatistics> count2 = aaa.GetInhabitantCountPerSpecificCountry(1);

            ;
        }
    }
}
