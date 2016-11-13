namespace EriZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZooInitializer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendor", "Email", c => c.String());
            AlterColumn("dbo.Animal", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Food", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Vendor", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendor", "Name", c => c.String());
            AlterColumn("dbo.Food", "Name", c => c.String());
            AlterColumn("dbo.Animal", "Name", c => c.String());
            DropColumn("dbo.Vendor", "Email");
        }
    }
}
