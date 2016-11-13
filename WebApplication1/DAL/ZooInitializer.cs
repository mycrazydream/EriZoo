using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EriZoo.Models;

namespace EriZoo.DAL
{
    public class ZooInitializer : DropCreateDatabaseIfModelChanges<ZooContext>
    {
        protected override void Seed(ZooContext context)
        {
            var animals = new List<Animal>
            {
            new Animal{Name="Giraffe",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2005-09-21"),BirthDate=DateTime.Parse("2005-09-21")},
            new Animal{Name="Black Widow",Group="Invertebrate",SubGroup="Arachnid",AcquisitionDate=DateTime.Parse("2016-10-01"),BirthDate=DateTime.Parse("2016-10-01")},
            new Animal{Name="Snake",Group="Vertebrate",SubGroup="Reptile",AcquisitionDate=DateTime.Parse("2015-03-01"),BirthDate=DateTime.Parse("2015-03-01")},
            new Animal{Name="Elephant",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2007-10-06"),BirthDate=DateTime.Parse("2005-09-01")},
            new Animal{Name="Lion",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2012-12-01"),BirthDate=DateTime.Parse("2010-05-02")},
            new Animal{Name="Tiger",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2010-09-01"),BirthDate=DateTime.Parse("2005-04-11")},
            new Animal{Name="Panda",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2003-11-01"),BirthDate=DateTime.Parse("2003-11-01")},
            new Animal{Name="Raptor",Group="Vertebrate",SubGroup="Bird",AcquisitionDate=DateTime.Parse("2015-09-01"),BirthDate=DateTime.Parse("2015-09-01")}
            };
            animals.ForEach(a => context.Animals.Add(a));
            // not necessary to call the SaveChanges method after each group of entities but it helps locate problem if an error occurs
            context.SaveChanges();
            
            var foods = new List<Food>
            {
            new Food{Name="Bamboo",Calories=300,VendorID=1,AnimalID=7},
            new Food{Name="Liquid Protein",Calories=100,VendorID=1,AnimalID=2},
            new Food{Name="Mice",Calories=500,VendorID=2,AnimalID=3},
            new Food{Name="Grass",Calories=2000,VendorID=1,AnimalID=4},
            new Food{Name="Pork",Calories=1000,VendorID=1,AnimalID=5},
            new Food{Name="Beef",Calories=3000,VendorID=1,AnimalID=6},
            new Food{Name="Leaves",Calories=1000,VendorID=3,AnimalID=1},
            new Food{Name="Mice",Calories=500,VendorID=2,AnimalID=8}
            };
            foods.ForEach(f => context.Foods.Add(f));
            context.SaveChanges();

            var vendors = new List<Vendor>
            {
            new Vendor{ID=1,Name="Vetrinarian Goods, Inc",Phone="555-444-2222",Address="123 Anywhere St", Address2="Suite 2"},
            new Vendor{ID=2,Name="International Foods",Phone="555-333-2222",Address="123 Somewhere St", Address2=""},
            new Vendor{ID=3,Name="Gourmet Animal Delite",Phone="555-333-1111",Address="123 Nunya St", Address2=""}
            };
            vendors.ForEach(v => context.Vendors.Add(v));
            context.SaveChanges();
        }
    }
}