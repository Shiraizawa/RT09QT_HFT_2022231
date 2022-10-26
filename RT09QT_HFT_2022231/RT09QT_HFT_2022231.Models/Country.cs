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

        ICollection<City> Cities { get; set; }
        ICollection<Town> Towns { get; set; }
        public Country(int ID, string name)
        {
            this.CountryName = name;
            this.CountryID = ID;
        }
    }
}
