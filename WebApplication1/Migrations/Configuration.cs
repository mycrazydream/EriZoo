namespace EriZoo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EriZoo.DAL.ZooContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        /*
        protected override void Seed(EriZoo.DAL.ZooContext context)
        {

        }
        */
    }
}
