using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTools;

using RT09QT_HFT_2022231.Models;


namespace RT09QT_HFT_2022231.Client
{
    class Program
    {
        static RestService rest;
        static void Main(string[] args)
        {

            rest = new RestService("http://localhost:53486/", "country");

            static void Update(string v)
            {
                try
                {
                    if (v == "Country")
                    {
                        Country item = new Country();
                        Console.Write("Country ID=");
                        item.CountryID = int.Parse(Console.ReadLine());
                        Country old = rest.Get<Country>(item.CountryID, "country");
                        Console.Write($"Country Name [old: {old.CountryName}]=");
                        item.CountryName = Console.ReadLine();
                        rest.Put(item, "country");
                    }
                    else if (v == "County")
                    {
                        County item = new County();
                        Console.Write("County ID=");
                        item.CountyID = int.Parse(Console.ReadLine());
                        County old = rest.Get<County>(item.CountyID, "county");
                        Console.Write($"County Name [old: {old.CountyName}]=");
                        item.CountyName = Console.ReadLine();
                        Console.Write($"Country ID [old: {old.CountryID}]=");
                        item.CountryID = int.Parse(Console.ReadLine());
                        rest.Put(item, "county");
                    }
                    else if (v == "Town")
                    {
                        Town item = new Town();
                        Console.Write("Town ID=");
                        item.TownID = int.Parse(Console.ReadLine());
                        Town old = rest.Get<Town>(item.TownID, "town");
                        Console.Write($"Town Name [old: {old.TownID}]=");
                        item.TownName = Console.ReadLine();
                        Console.Write($"County ID [old: {old.TownName}]=");
                        item.CountyID = int.Parse(Console.ReadLine());
                        rest.Put(item, "town");
                    }
                    else if (v == "Inhabitant")
                    {
                        Inhabitant item = new Inhabitant();
                        Console.Write("Inhabitant ID=");
                        item.InhabitantID = int.Parse(Console.ReadLine());
                        Inhabitant old = rest.Get<Inhabitant>(item.InhabitantID, "inhabitant");
                        Console.Write($"Name [old: {old.Name}]= ");
                        item.Name = Console.ReadLine();
                        Console.Write($"Age [old: {old.Age}]=");
                        item.Age = int.Parse(Console.ReadLine());
                        Console.Write($"Sex (true=male/false=female) [old: {old.Sex} =");
                        item.Sex = bool.Parse(Console.ReadLine());
                        Console.Write($"Location ID [old: {old.LocationID}]=");
                        item.LocationID = int.Parse(Console.ReadLine());
                        rest.Put(item, "inhabitant");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }

            static void Delete(string v)
            {
                try
                {
                    if (v == "Country")
                    {
                        List(v);
                        Console.WriteLine("Format: \n ID");
                        rest.Delete(int.Parse(Console.ReadLine()), "country");
                    }
                    else if (v == "County")
                    {
                        List(v);
                        Console.WriteLine("Format: \n ID");
                        rest.Delete(int.Parse(Console.ReadLine()), "county");
                    }
                    else if (v == "Town")
                    {
                        List(v);
                        Console.WriteLine("Format: \n ID");
                        rest.Delete(int.Parse(Console.ReadLine()), "town");
                    }
                    else if (v == "Inhabitant")
                    {
                        List(v);
                        Console.WriteLine("Format: \n ID");
                        rest.Delete(int.Parse(Console.ReadLine()), "inhabitant");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
            static void Create(string v)
            {
                try
                {
                    if (v == "Country") { Console.WriteLine("Format: \n ID#NAME"); Country item = new Country(Console.ReadLine()); rest.Post(item, "country"); }
                    else if (v == "County") { Console.WriteLine("Format: \n ID#NAME#COUNTRYID"); County item = new County(Console.ReadLine()); rest.Post(item, "county"); }
                    else if (v == "Town") { Console.WriteLine("Format: \n ID#NAME#COUNTYID"); Town item = new Town(Console.ReadLine()); rest.Post(item, "town"); }
                    else if (v == "Inhabitant") { Console.WriteLine("Format: \n ID#NAME#AGE#SEX#LOCATIONID"); Inhabitant item = new Inhabitant(Console.ReadLine()); rest.Post(item, "inhabitant"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
            static void List(string v)
            {
                try
                {
                    if (v == "Country")
                    {
                        List<Country> items = rest.Get<Country>("country");
                        Console.WriteLine("ID" + "\t" + "Name");
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.CountryID + "\t" + item.CountryName);
                        }
                    }
                    else if (v == "County")
                    {
                        List<County> items = rest.Get<County>("county");
                        Console.WriteLine("ID" + "\t" + "Name" + "\t" + "CountryID");
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.CountyID + "\t" + item.CountyName + "\t" + item.CountryID);
                        }
                    }
                    else if (v == "Town")
                    {
                        List<Town> items = rest.Get<Town>("town");
                        Console.WriteLine("ID" + "\t" + "Name" + "\t" + "CountyID");
                        foreach (var item in items)
                        {
                            Console.WriteLine(item.TownID + "\t" + item.TownName + "\t" + item.CountyID);
                        }
                    }
                    else if (v == "Inhabitant")
                    {
                        List<Inhabitant> items = rest.Get<Inhabitant>("inhabitant");
                        Console.WriteLine("ID" + "\t" + "Name" + "\t" + "Age" + "\t" + "Sex" + "\t" + "LocationID");
                        foreach (var item in items)
                        {
                            string sex; ;
                            if (item.Sex == true) sex = "male";
                            else sex = "female";
                            Console.WriteLine(item.InhabitantID + "\t" + item.Name + "\t" + item.Age + "\t" + sex + "\t" + item.LocationID);
                        }
                    }
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }


            var countrySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Country"))
                .Add("Create", () => Create("Country"))
                .Add("Delete", () => Delete("Country"))
                .Add("Update", () => Update("Country"))
                .Add("GetCountyCountPerCountry", () => GetCountyCountPerCountry())
                .Add("GetCountyCountAllCountry", () => GetCountyCountAllCountry())
                .Add("GetTownCountPerCountry", () => GetTownCountPerCountry())
                .Add("GetInhabitantStatisticsPerCountry", () => GetInhabitantStatisticsPerCountry())
                .Add("GetInhabitantStatisticsPerSpecificCountry", () => GetInhabitantStatisticsPerSpecificCountry())
                .Add("Exit", ConsoleMenu.Close);

            var countySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("County"))
                .Add("Create", () => Create("County"))
                .Add("Delete", () => Delete("County"))
                .Add("Update", () => Update("County"))
                .Add("Exit", ConsoleMenu.Close);

            var townSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Town"))
                .Add("Create", () => Create("Town"))
                .Add("Delete", () => Delete("Town"))
                .Add("Update", () => Update("Town"))
                .Add("Exit", ConsoleMenu.Close);

            var inhabitantSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Inhabitant"))
                .Add("Create", () => Create("Inhabitant"))
                .Add("Delete", () => Delete("Inhabitant"))
                .Add("Update", () => Update("Inhabitant"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Countries", () => countrySubMenu.Show())
                .Add("Counties", () => countySubMenu.Show())
                .Add("Towns", () => townSubMenu.Show())
                .Add("Inhabitants", () => inhabitantSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }

        static void GetInhabitantStatisticsPerSpecificCountry()
        {

            Console.Write("CountryID=");
            int countryID = int.Parse(Console.ReadLine());
            List<Country> country = rest.Get<Country>("country");
            Country country1 = country.Where(x => x.CountryID == countryID).FirstOrDefault();
            CountryInhabitantStatistics a = country1.GetInhabitantStatisticsPerSpecificCountry().ToList()[0];
            Console.Write($"Males = \t\t{a.maleCount} \nFemales = \t\t{a.femaleCount} \nAll inhabitants = \t{a.allInhabitants} \nAverage age = \t\t{a.averageAge}");
            Console.ReadLine();
        }

        static void GetInhabitantStatisticsPerCountry()
        {
            List<Country> country = rest.Get<Country>("country");
            foreach (Country country1 in country)
            {
                CountryInhabitantStatistics a = country1.GetInhabitantStatisticsPerSpecificCountry().ToList()[0];
                Console.Write($"Country ID = \t\t{country1.CountryID}\nMales = \t\t{a.maleCount} \nFemales = \t\t{a.femaleCount} \nAll inhabitants = \t{a.allInhabitants} \nAverage age = \t\t{a.averageAge}\n");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void GetTownCountPerCountry()
        {
            List<Country> country = rest.Get<Country>("country");
            foreach (Country country1 in country)
            {
                int town_count = country1.GetTownCountPerCountry().ToList()[0];
                Console.WriteLine($"Country id = \t{country1.CountryID}\nTown count = \t{town_count}\n");
            }
            Console.ReadLine();
        }

        static void GetCountyCountAllCountry()
        {
            List<Country> country = rest.Get<Country>("country");
            foreach (Country country1 in country)
            {
                int county_count = country1.GetCountyCountPerCountry().ToList()[0];
                Console.WriteLine($"Country id = \t{country1.CountryID}\nCounty count = \t{county_count}\n");
            }
            Console.ReadLine();
        }

        static void GetCountyCountPerCountry()
        {
            Console.Write("CountryID=");
            int countryID = int.Parse(Console.ReadLine());
            List<Country> country = rest.Get<Country>("country");
            Country country1 = country.Where(x => x.CountryID == countryID).FirstOrDefault();
            int county_count = country1.GetCountyCountPerCountry().ToList()[0];
            Console.WriteLine($"County count = \t{county_count}\n");
            Console.ReadLine();
        }
    }
}