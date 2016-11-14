using EriZoo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EriZoo.DAL
{
    public class ZooContext : DbContext
    {
        public ZooContext() : base("ZooContext")
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ZooKeeper> ZooKeepers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}