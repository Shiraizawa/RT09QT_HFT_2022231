using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Models
{
    public class County
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountyID { get; set; }

        [Required]
        [StringLength(100)]
        public string CountyName { get; set; }


        public int CountryID { get; set; }
        [JsonIgnore]
        virtual public Country HomeCountry { get; set; } 
        virtual public ICollection<Town> Towns { get; set; }

        public County(int ID, string name, int CountryID)
        {
            this.CountyID = ID;
            this.CountyName = name;
            this.CountryID = CountryID;
        }
        public County(string input)
        {
            string[] cutInput = input.Split("#");
            this.CountyID = int.Parse(cutInput[0]);
            this.CountyName = cutInput[1];
            this.CountryID= int.Parse(cutInput[2]); 
        }
        public County()
        {

        }
    }
}
