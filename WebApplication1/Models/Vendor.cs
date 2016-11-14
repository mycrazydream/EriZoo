using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EriZoo.Models
{
    [Table("Vendor")]
    public class Vendor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}