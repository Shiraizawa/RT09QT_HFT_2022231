﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RT09QT_HFT_2022231.Models
{
    public class Inhabitant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InhabitantID { get; set; }

        [Required]
        [StringLength(70)] //according to UK Government Data Standards Catalogue 
        public string Name { get; set; }

        public int Age { get; set; }
        
        public bool? Sex { get; set; }  //true=male, false=female
        [Required]
        [JsonIgnore]
        virtual public Town Location { get; set; }
        [Required]
        public int LocationID { get; set; }
        public Inhabitant(int inhabitantID, string name, int age, bool sex)
        {
            InhabitantID = inhabitantID;
            Name = name;
            Age = age;
            Sex = sex;
        }
        public Inhabitant(string input)
        {
            string[] cutInput = input.Split("#");
            this.InhabitantID = int.Parse(cutInput[0]);
            this.Name = cutInput[1];
            this.Age = int.Parse(cutInput[2]);
            this.Sex = bool.Parse(cutInput[3]);
            this.LocationID = int.Parse(cutInput[4]);
        }
        public Inhabitant()
        {

        }
    }
}
