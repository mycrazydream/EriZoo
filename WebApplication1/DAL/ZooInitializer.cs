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
            var keepers = new List<ZooKeeper>
            {
            new ZooKeeper{FirstName="Jon", LastName="Brown", HireDate=DateTime.Parse("2008-10-21"),Animals = new List<Animal>()},
            new ZooKeeper{FirstName="Cobra", LastName="Wilson" ,HireDate=DateTime.Parse("2013-10-11"),Animals = new List<Animal>()},
            new ZooKeeper{FirstName="John", LastName="Gotti", HireDate=DateTime.Parse("2015-03-04"),Animals = new List<Animal>()}
            };
            keepers.ForEach(k => context.ZooKeepers.Add(k));
            context.SaveChanges();

            var animals = new List<Animal>
            {
            new Animal{Name="Giraffe",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2005-09-21"),BirthDate=DateTime.Parse("2005-09-21"), ZooKeeperID=keepers.Single( k => k.LastName == "Gotti").ID, Foods = new List<Food>()},
            new Animal{Name="Black Widow",Group="Invertebrate",SubGroup="Arachnid",AcquisitionDate=DateTime.Parse("2016-10-01"),BirthDate=DateTime.Parse("2016-10-01"),ZooKeeperID=keepers.Single( k => k.LastName == "Gotti").ID, Foods = new List<Food>()},
            new Animal{Name="Snake",Group="Vertebrate",SubGroup="Reptile",AcquisitionDate=DateTime.Parse("2015-03-01"),BirthDate=DateTime.Parse("2015-03-01"),ZooKeeperID=keepers.Single( k => k.LastName == "Gotti").ID, Foods = new List<Food>()},
            new Animal{Name="Elephant",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2007-10-06"),BirthDate=DateTime.Parse("2005-09-01"),ZooKeeperID=keepers.Single( k => k.LastName == "Wilson").ID, Foods = new List<Food>()},
            new Animal{Name="Lion",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2012-12-01"),BirthDate=DateTime.Parse("2010-05-02"),ZooKeeperID=keepers.Single( k => k.LastName == "Wilson").ID, Foods = new List<Food>()},
            new Animal{Name="Tiger",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2010-09-01"),BirthDate=DateTime.Parse("2005-04-11"),ZooKeeperID=keepers.Single( k => k.LastName == "Gotti").ID, Foods = new List<Food>()},
            new Animal{Name="Panda",Group="Vertebrate",SubGroup="Mammal",AcquisitionDate=DateTime.Parse("2003-11-01"),BirthDate=DateTime.Parse("2003-11-01"),ZooKeeperID=keepers.Single( k => k.LastName == "Brown").ID, Foods = new List<Food>()},
            new Animal{Name="Raptor",Group="Vertebrate",SubGroup="Bird",AcquisitionDate=DateTime.Parse("2015-09-01"),BirthDate=DateTime.Parse("2015-09-01"),ZooKeeperID=keepers.Single( k => k.LastName == "Brown").ID, Foods = new List<Food>()}
            };
            animals.ForEach(a => context.Animals.Add(a));
            // not necessary to call the SaveChanges method after each group of entities but it helps locate problem if an error occurs
            context.SaveChanges();

            var vendors = new List<Vendor>
            {
            new Vendor{ID=1,Name="Vetrinarian Goods, Inc",Phone="555-444-2222",Address="123 Anywhere St", Address2="Suite 2", Foods = new List<Food>()},
            new Vendor{ID=2,Name="International Foods",Phone="555-333-2222",Address="123 Somewhere St", Address2="", Foods = new List<Food>()},
            new Vendor{ID=3,Name="Gourmet Animal Delite",Phone="555-333-1111",Address="123 Nunya St", Address2="", Foods = new List<Food>()}
            };
            vendors.ForEach(v => context.Vendors.Add(v));
            context.SaveChanges();

            var foods = new List<Food>
            {
            new Food{Name="Bamboo",Calories=300,VendorID=vendors.Single( v => v.Name == "Vetrinarian Goods, Inc").ID,Weight=3000},
            new Food{Name="Liquid Protein",Calories=100,VendorID=vendors.Single( v => v.Name == "Gourmet Animal Delite").ID,Weight=2},
            new Food{Name="Mice",Calories=500,VendorID=vendors.Single( v => v.Name == "International Foods").ID,Weight=100},
            new Food{Name="Grass",Calories=2000,VendorID=vendors.Single( v => v.Name == "Vetrinarian Goods, Inc").ID,Weight=1000},
            new Food{Name="Pork",Calories=1000,VendorID=vendors.Single( v => v.Name == "International Foods").ID,Weight=5000},
            new Food{Name="Beef",Calories=3000,VendorID=vendors.Single( v => v.Name == "International Foods").ID,Weight=5000},
            new Food{Name="Leaves",Calories=1000,VendorID=vendors.Single( v => v.Name == "Vetrinarian Goods, Inc").ID,Weight=3000},
            new Food{Name="Mice",Calories=500,VendorID=vendors.Single( v => v.Name == "Gourmet Animal Delite").ID,Weight=1000},
            new Food{Name="Hay",Calories=500,VendorID=vendors.Single( v => v.Name == "Gourmet Animal Delite").ID,Weight=1000},
            new Food{Name="Chicken",Calories=1000,VendorID=vendors.Single( v => v.Name == "Gourmet Animal Delite").ID,Weight=1000}
            };
            foods.ForEach(f => context.Foods.Add(f));
            context.SaveChanges();

            
            
        }
    }
}