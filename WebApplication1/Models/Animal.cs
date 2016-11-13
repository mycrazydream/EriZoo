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
        public string Name { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
        [Required]
        public DateTime AcquisitionDate { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}