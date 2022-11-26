using Moq;
using NUnit.Framework;
using RT09QT_HFT_2022231.Logic;
using RT09QT_HFT_2022231.Models;
using RT09QT_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RT09QT_HFT_2022231.Test
{
    [TestFixture]
    public class Test
    {
        Mock<ICountryRepository> mockCountryRepo;

        CountryLogic c1;

        IQueryable<Country> Countries;

        [SetUp]
        public void Init()
        {
            Countries = new List<Country>()
            {
                new Country("1#CountryA"){Counties=new List<County>()
                {
                 new County("1#CountyA#1"){Towns= new List<Town>(){
                     new Town("1#TownA#1"){Inhabitants=new List<Inhabitant>()
                                                         {
                new Inhabitant("1#John Doe#25#true#1"),
                new Inhabitant("2#James Doe#37#true#1"),
                new Inhabitant("3#Jane Doe#60#false#1"), }
                  } }
                 },
                 new County("2#CountyB#1"){Towns= new List<Town>(){
                     new Town("2#TownA#1"){Inhabitants=new List<Inhabitant>()
                                                         {
                new Inhabitant("4#Anne Name#12#false#2"),
                new Inhabitant("5#Ursula Default#25#false#2"),
                new Inhabitant("6#Bob Basic#52#true#2"), }
                  } }
                 }

                }
            },
                new Country("2#CountryB")
                {
                   Counties = new List<County>(){new County("2#Namur#2"){Towns= new List<Town>(){
                     new Town("3#Dinant#2"){Inhabitants=new List<Inhabitant>()
                                                         {
                new Inhabitant("7#Joseph Doe#25#true#3"),
                new Inhabitant("8#Thomas Total#33#true#3"), }
                  } }
                 } }
                },
                new Country("3#CountryC")
                {
                   Counties = new List<County>(){new County("3#Ontario#3"){Towns= new List<Town>(){
                     new Town("4#Killarney#3"){Inhabitants=new List<Inhabitant>()
                                                         {
                new Inhabitant("9#Commander Total#54#true#4"), }
                  } }
                 } }
                },
                new Country("4#CountryD")
                {
                   Counties = new List<County>(){new County("4#Ribe County#4"){Towns= new List<Town>(){
                     new Town("5#Ribe#4"){Inhabitants=new List<Inhabitant>()
                                                         {
                new Inhabitant("10#Josephine Joestar#27#false#5"), }
                  } }
                 } }
                },
            }.AsQueryable();

            mockCountryRepo = new();

            mockCountryRepo.Setup(m => m.ReadAll()).Returns(Countries);
            c1 = new CountryLogic(mockCountryRepo.Object);
            ;
        }

        [Test]
        public void CountryCountyCountSingular()
        {

            int count = c1.GetCountyCountPerCountry(1).ToList()[0];
            Assert.That(count, Is.EqualTo(2));
            ;
        }
        [Test]
        public void CountryCountyCountTotal()
        {

            IEnumerable<int> count = c1.GetCountyCountAllCountry();
            IEnumerable<int> expected = new List<int>()
            {
                2,1,1,1
            };
            Assert.AreEqual(count, expected);
            ;
        }
        [Test]
        public void CountryInhabitantsStatistics()
        {
            var actual = c1.GetInhabitantStatisticsPerSpecificCountry(1).ToList<CountryInhabitantStatistics>();

            var expected = new List<CountryInhabitantStatistics>() {
                new CountryInhabitantStatistics()
                {
                    averageAge= 35,
                    maleCount=3,
                    femaleCount=3,
                    allInhabitants=6,
                    countryID=1
                }
            }.ToList<CountryInhabitantStatistics>();

            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void CountryInhabitantsStatisticsAll()
        {
            var actual = c1.GetInhabitantStatisticsPerCountry().ToList<CountryInhabitantStatistics>();
            var expected = new List<CountryInhabitantStatistics>() {
                new CountryInhabitantStatistics()
                {
                    averageAge= 35,
                    maleCount=3,
                    femaleCount=3,
                    allInhabitants=6,
                    countryID=1
                },
                new CountryInhabitantStatistics()
                {
                    averageAge= 29,
                    maleCount=2,
                    femaleCount=0,
                    allInhabitants=2,
                    countryID=2
                },
                new CountryInhabitantStatistics()
                {
                    averageAge= 54,
                    maleCount=1,
                    femaleCount=0,
                    allInhabitants=1,
                    countryID=3
                },
                new CountryInhabitantStatistics()
                {
                    averageAge= 27,
                    maleCount=0,
                    femaleCount=1,
                    allInhabitants=1,
                    countryID=4
                },
            }.ToList<CountryInhabitantStatistics>();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CountryTownCount()
        {
            int count = c1.GetTownCountPerCountry(1).ToList<int>()[0];
            Assert.That(count, Is.EqualTo(2));
        }
        [Test]
        public void CreateCountryTest()
        {
            var country = new Country() { CountryName = "Hungary" };
            c1.Create(country);

            mockCountryRepo.Verify(r => r.Create(country), Times.Once);
        }
        [Test]
        public void CreateCountryTestFail()
        {
            try { var country = new Country() { CountryName = "Alm" }; }
            catch (Exception)
            {
                Assert.Fail();
            }


        }
        [Test]
        public void CreateInhabitantFail()
        {
            try { var inhabitant = new Inhabitant() { Age = -5, Name = "Juli Anna", Sex = false }; }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        [Test]
        public void UpdateCountryTest()
        {
            Country country = new Country() { CountryID = 1, CountryName = "Azerbaijan" };
            c1.Update(country);
            mockCountryRepo.Verify(r => r.Update(country), Times.Once);
        }

        [Test]
        public void ReadAllCountryTest()
        {

            c1.ReadAll();
            mockCountryRepo.Verify(r => r.ReadAll(), Times.Once);
        }

    }
}