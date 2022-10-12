using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Models
{
    public class City
    {

        //TODO add reference to other tables
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityID { get; set; }

        [Required]
        [StringLength(100)]
        public string CityName { get; set; }

        ICollection<Inhabitant> Inhabitants { get; set; }

        public int CountryID { get; set; }
        public City(int ID, string name,int CountryID, Inhabitant inhabitants)
        {
            this.CityID = ID;
            this.CityName = name;
            this.CountryID = CountryID;
            this.Inhabitants = (ICollection<Inhabitant>)inhabitants;
        }
    }
}
