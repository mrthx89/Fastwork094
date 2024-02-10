namespace Inventory.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TPurchaseDtl", "Disc1Prosen", c => c.Double(nullable: false));
            AddColumn("dbo.TPurchaseDtl", "Disc1", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TPurchaseDtl", "Disc1");
            DropColumn("dbo.TPurchaseDtl", "Disc1Prosen");
        }
    }
}
