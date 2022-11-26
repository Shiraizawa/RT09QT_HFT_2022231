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
    public class Town
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TownID { get; set; }

        [Required]
        [StringLength(85)] //Longest town name is 85 characters long
        public string TownName { get; set; }

        [Required]
        public int CountyID { get; set; }
        [JsonIgnore]
        virtual public County HomeCounty { get; set; }
        virtual public ICollection<Inhabitant> Inhabitants { get; set; }

        public Town(int ID, string name, int CountyID)
        {
            this.TownID = ID;
            this.TownName = name;
            this.CountyID = CountyID;
        }

        public Town(string input)
        {
            string[] cutInput = input.Split("#");
            this.TownID = int.Parse(cutInput[0]);
            this.TownName = cutInput[1];
            this.CountyID = int.Parse(cutInput[2]);
        }
        public Town()
        {

        }
    }
}
