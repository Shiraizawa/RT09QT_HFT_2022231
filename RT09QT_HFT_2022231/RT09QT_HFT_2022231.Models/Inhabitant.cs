using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RT09QT_HFT_2022231.Models
{
    public class Inhabitant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InhabitantID
        {
            get; set;
        }
        [Required]
        [StringLength(100)]
        string Name
        {
            get; set;
        }
        [StringLength(200)]
        string Address { get; set; }
        
        int Age { get; set; }
        [Required]
        [StringLength(100)]
        string MothersName { get; set; }

        public Inhabitant(int ID,string name, string address, int age, string mothersName)
        {
            this.InhabitantID = ID;
            this.Name = name;
            this.Address = address;
            this.Age = age;
            this.MothersName = mothersName;
        }
    }
}
