using System;
using System.Collections.Generic;

namespace EriZoo.Models
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}