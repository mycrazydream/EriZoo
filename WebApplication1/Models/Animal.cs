using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EriZoo.Models
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Animal Name")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Group { get; set; }

        [Display(Name = "Sub Group")]
        public string SubGroup { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Acquisition Date")]
        public DateTime AcquisitionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Unknown")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Birthed In House")]
        public bool InHouse
        {
            get
            {
                return AcquisitionDate.Date == BirthDate.Date;
            }
        }

        [ForeignKey("ZooKeeper")]
        public int ZooKeeperID { get; set; }

        public virtual ZooKeeper ZooKeeper { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}