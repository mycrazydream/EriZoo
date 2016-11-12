using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EriZoo.Models
{
    public class Vendor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}