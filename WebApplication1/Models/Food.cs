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
        public string Name { get; set; }
        public int Calories { get; set; }
        [ForeignKey("Vendor")]
        public int VendorID { get; set; }
        [ForeignKey("Animal")]
        public int AnimalID { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual Animal Animal { get; set; }
    }
}