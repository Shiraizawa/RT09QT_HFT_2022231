using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RT09QT_HFT_2022231.Models
{
   public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }

        virtual public ICollection<County> Counties { get; set; }
        public Country(int ID, string name)
        {
            this.CountryName = name;
            this.CountryID = ID;
        }

        public Country(string input)
        {
            string[] cutInput = input.Split("#");
            this.CountryID = int.Parse(cutInput[0]);
            this.CountryName = cutInput[1];
        }
        public Country()
        {

        }

        public IEnumerable<int> GetCountyCountPerCountry()
        {
           
            int count = 0;
            
                foreach (County county in this.Counties)
                {
                    count++;
                }
            
            IEnumerable<int> result = new List<int>() { count };
            return result;

        }
        public IEnumerable<int> GetTownCountPerCountry()
        {
            int count = 0;
            foreach (County county in this.Counties)
            {
                count += county.Towns.Count();
            }
            IEnumerable<int> result = new int[] { count };
            return result;
        }
        public IEnumerable<CountryInhabitantStatistics> GetInhabitantStatisticsPerSpecificCountry()
        {
            List<CountryInhabitantStatistics> result = new List<CountryInhabitantStatistics>();
            
                int maleCount = 0;
                int femaleCount = 0;
                int avgAge = 0;
                int count = 0;

                foreach (County county in this.Counties)
                {

                    foreach (Town town in county.Towns)
                    {

                        foreach (Inhabitant inhabitant in town.Inhabitants)
                        {
                            if (inhabitant.Sex == true)
                                maleCount++;
                            else femaleCount++;
                            count++;
                            avgAge += inhabitant.Age;
                        }

                    }

                }
                result.Add(new CountryInhabitantStatistics(maleCount, femaleCount, (avgAge / count), count, this.CountryID));
            return result;
        }

    }
    public class CountryInhabitantStatistics
    {
        public int maleCount { get; set; }
        public int femaleCount { get; set; }
        public int averageAge { get; set; }
        public int allInhabitants { get; set; }
        public int countryID;
        public CountryInhabitantStatistics(int maleCount, int femaleCount, int averageAge, int allInhabitants, int countryID)
        {
            this.maleCount = maleCount;
            this.femaleCount = femaleCount;
            this.averageAge = averageAge;
            this.allInhabitants = allInhabitants;
            this.countryID = countryID;
        }
        public CountryInhabitantStatistics()
        {

        }

        public override bool Equals(object obj)
        {
            CountryInhabitantStatistics b = obj as CountryInhabitantStatistics;
            if (b == null) return false;
            else
            {
                return this.maleCount == b.maleCount && this.femaleCount == b.femaleCount && this.averageAge == b.averageAge && this.allInhabitants == b.allInhabitants && this.countryID == b.countryID; ;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.maleCount, this.femaleCount, this.averageAge, this.allInhabitants, this.countryID);
        }
    }
}
