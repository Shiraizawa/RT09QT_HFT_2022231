using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RT09QT_HFT_2022231.Models
{
   public class Village
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VillageID { get; set; }

        [Required]
        [StringLength(100)]
        public string VillageName { get; set; }
        ICollection<Inhabitant> Inhabitants { get; set; }
        public Village(int ID, string name, Inhabitant inhabitants)
        {
            this.Inhabitants = (ICollection<Inhabitant>)inhabitants;
            this.VillageName = name;
            this.VillageID = ID;
        }
    }
}
