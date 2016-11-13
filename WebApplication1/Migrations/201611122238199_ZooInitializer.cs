namespace EriZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZooInitializer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Group = c.String(),
                        SubGroup = c.String(),
                        AcquisitionDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Calories = c.Int(nullable: false),
                        VendorID = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Animal", t => t.AnimalID, cascadeDelete: true)
                .Index(t => t.VendorID)
                .Index(t => t.AnimalID);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Food", "VendorID", "dbo.Vendor");
            DropForeignKey("dbo.Food", "AnimalID", "dbo.Animal");
            DropIndex("dbo.Food", new[] { "AnimalID" });
            DropIndex("dbo.Food", new[] { "VendorID" });
            DropTable("dbo.Vendor");
            DropTable("dbo.Food");
            DropTable("dbo.Animal");
        }
    }
}
