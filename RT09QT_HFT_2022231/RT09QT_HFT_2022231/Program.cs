using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTools;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RT09QT_HFT_2022231.Logic;
using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using RT09QT_HFT_2022231.Test;

namespace RT09QT_HFT_2022231
{
    class Program
    {
        static CountryLogic countryLogic;
        static CountyLogic countyLogic;
        static TownLogic townLogic;
        static InhabitantLogic inhabitantLogic;
        static void Main(string[] args)
        {
            var ctx = new CountryDbContext();

            var countryRepo = new CountryRepository(ctx);
            var countyRepo= new CountyRepository(ctx);
            var townRepo= new TownRepository(ctx);
            var inhabitantRepo= new InhabitantRepository(ctx);

            countryLogic = new CountryLogic(countryRepo);
            countyLogic=new CountyLogic(countyRepo);
            townLogic = new TownLogic(townRepo);
            inhabitantLogic=new InhabitantLogic(inhabitantRepo);


             static void Update(string v)
            {
                if (v == "Country")
                {
                    Country item= new Country();
                    Console.Write("Country ID=");
                    item.CountryID=int.Parse(Console.ReadLine());
                    Console.Write("Country Name=");
                    item.CountryName = Console.ReadLine();
                    countryLogic.Update(item);
                }
                else if (v == "County")
                {
                    County item = new County();
                    Console.Write("County ID=");
                    item.CountyID = int.Parse(Console.ReadLine());
                    Console.Write("County Name=");
                    item.CountyName = Console.ReadLine();
                    Console.Write("Country ID=");
                    item.CountryID= int.Parse(Console.ReadLine());
                    countyLogic.Update(item);
                }
                else if (v == "Town")
                {
                    Town item = new Town();
                    Console.Write("Town ID=");
                    item.TownID = int.Parse(Console.ReadLine());
                    Console.Write("Town Name=");
                    item.TownName = Console.ReadLine();
                    Console.Write("County ID=");
                    item.CountyID= int.Parse(Console.ReadLine());
                    townLogic.Update(item);
                }
                else if (v == "Inhabitant")
                {
                    Inhabitant item = new Inhabitant();
                    Console.Write("Inhabitant ID=");
                    item.InhabitantID= int.Parse(Console.ReadLine());
                    Console.Write("Name=");
                    item.Name= Console.ReadLine();
                    Console.Write("Age=");
                    item.Age = int.Parse(Console.ReadLine());
                    Console.Write("Sex (true=male/false=female) =");
                    item.Sex=bool.Parse(Console.ReadLine());
                    Console.Write("Location ID=");
                    item.LocationID = int.Parse(Console.ReadLine());
                    inhabitantLogic.Update(item);
                }
            }

             static void Delete(string v)
            {
                if (v == "Country") { Console.WriteLine("Format: \n ID"); countryLogic.Delete(int.Parse(Console.ReadLine())); }
                else if (v == "County") { Console.WriteLine("Format: \n ID"); countyLogic.Delete(int.Parse(Console.ReadLine())); }
                else if (v == "Town") { Console.WriteLine("Format: \n ID"); townLogic.Delete(int.Parse(Console.ReadLine())); }
                else if (v == "Inhabitant") { Console.WriteLine("Format: \n ID"); inhabitantLogic.Delete(int.Parse(Console.ReadLine())); }
            }

             static void Create(string v)
            {
                if (v == "Country"){ Console.WriteLine("Format: \n ID#NAME"); Country  item= new Country(Console.ReadLine()); countryLogic.Create(item);  }
                else if (v == "County") { Console.WriteLine("Format: \n ID#NAME#COUNTRYID"); County item = new County(Console.ReadLine()); countyLogic.Create(item); }
                else if (v=="Town") { Console.WriteLine("Format: \n ID#NAME#COUNTYID"); Town item = new Town(Console.ReadLine()); townLogic.Create(item); }
                else if (v=="Inhabitant") { Console.WriteLine("Format: \n ID#NAME#AGE#SEX#LOCATIONID"); Inhabitant item = new Inhabitant(Console.ReadLine()); inhabitantLogic.Create(item); }
            }

             static void List(string v)
            {
                if (v == "Country")
                {
                    var items=countryLogic.ReadAll();
                    Console.WriteLine("ID" + "\t" + "Name");
                    foreach(var item in items)
                    {
                        Console.WriteLine(item.CountryID + "\t" + item.CountryName);
                    }
                }
                else if(v=="County")
                {
                    var items=countyLogic.ReadAll();
                    Console.WriteLine("ID" + "\t" + "Name" +  "\t" +  "CountryID");
                    foreach(var item in items)
                    {
                        Console.WriteLine(item.CountyID+ "\t" + item.CountyName + "\t" + item.CountryID);
                    }
                }
                else if (v == "Town")
                {
                    var items = townLogic.ReadAll();
                    Console.WriteLine("ID" + "\t" + "Name" + "\t" + "CountyID");
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.TownID + "\t" + item.TownName + "\t" + item.CountyID);
                    }
                }
                else if (v == "Inhabitant")
                {
                    var items = inhabitantLogic.ReadAll();
                    Console.WriteLine("ID" + "\t" + "Name" + "\t" +"Age" +"\t" + "Sex" + "\t" + "LocationID");
                    foreach (var item in items)
                    {
                        string sex; ;
                        if (item.Sex == true) sex = "male";
                        else sex = "female";
                        Console.WriteLine(item.InhabitantID + "\t" + item.Name +"\t" + item.Age + "\t" + sex + "\t" + item.LocationID);
                    }
                }
                Console.ReadLine();
            }


            var countrySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Country"))
                .Add("Create", () => Create("Country"))
                .Add("Delete", () => Delete("Country"))
                .Add("Update", () => Update("Country"))
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

            var menu= new ConsoleMenu(args, level: 0)
                .Add("Countries", () => countrySubMenu.Show())
                .Add("Counties", () => countySubMenu.Show())
                .Add("Towns", () => townSubMenu.Show())
                .Add("Inhabitants", () => inhabitantSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }


        
    }
}
