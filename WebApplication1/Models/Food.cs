using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EriZoo.Models
{
    [Table("Food")]
    public class Food
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(0, 2000)]
        public int Calories { get; set; }

        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [Display(Name = "Weight in Grams")]
        [Range(1,100000)]
        public int Weight { get; set; }

        [ForeignKey("Vendor")]
        public int VendorID { get; set; }
        /*[ForeignKey("Animal")]
        public int AnimalID { get; set; }*/

        public virtual Vendor Vendor { get; set; }
        //public virtual ICollection<Animal> Animals { get; set; }
    }

}