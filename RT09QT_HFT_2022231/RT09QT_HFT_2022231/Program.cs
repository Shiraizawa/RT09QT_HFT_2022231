using System;
using System.Linq;
using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;

namespace RT09QT_HFT_2022231
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CountryDbContext ctx = new CountryDbContext(); ;
            var items = ctx.Countries.ToArray();
            ;
        }
    }
}
