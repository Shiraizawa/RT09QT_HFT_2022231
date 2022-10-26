﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Models
{
    public class Town
    {

        //TODO add reference to other tables
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TownID { get; set; }

        [Required]
        [StringLength(100)]
        public string TownName { get; set; }

        ICollection<Inhabitant> Inhabitants { get; set; }
        public int CountryID { get; set; }
        public Country HomeCountry { get; set; }

        public Town(int ID, string name, int CountryID, Inhabitant inhabitants)
        {
            this.TownID = ID;
            this.TownName = name;
            this.CountryID = CountryID;
            this.Inhabitants = (ICollection<Inhabitant>)inhabitants;
        }
        public Town(int ID, string name, int CountryID)
        {
            this.TownID = ID;
            this.TownName = name;
            this.CountryID = CountryID;
        }
    }
}
