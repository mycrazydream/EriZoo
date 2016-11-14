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
                        Name = c.String(nullable: false, maxLength: 50),
                        Group = c.String(maxLength: 50),
                        SubGroup = c.String(),
                        AcquisitionDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        ZooKeeperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ZooKeeper", t => t.ZooKeeperID, cascadeDelete: true)
                .Index(t => t.ZooKeeperID);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Calories = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Int(nullable: false),
                        VendorID = c.Int(nullable: false),
                        Animal_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vendor", t => t.VendorID, cascadeDelete: true)
                .ForeignKey("dbo.Animal", t => t.Animal_ID)
                .Index(t => t.VendorID)
                .Index(t => t.Animal_ID);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ZooKeeper",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animal", "ZooKeeperID", "dbo.ZooKeeper");
            DropForeignKey("dbo.Food", "Animal_ID", "dbo.Animal");
            DropForeignKey("dbo.Food", "VendorID", "dbo.Vendor");
            DropIndex("dbo.Food", new[] { "Animal_ID" });
            DropIndex("dbo.Food", new[] { "VendorID" });
            DropIndex("dbo.Animal", new[] { "ZooKeeperID" });
            DropTable("dbo.ZooKeeper");
            DropTable("dbo.Vendor");
            DropTable("dbo.Food");
            DropTable("dbo.Animal");
        }
    }
}
