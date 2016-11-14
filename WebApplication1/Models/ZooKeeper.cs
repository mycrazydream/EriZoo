using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EriZoo.Models
{
    [Table("ZooKeeper")]
    public class ZooKeeper
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "First")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Last")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}