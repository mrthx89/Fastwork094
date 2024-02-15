namespace Inventory.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoidItem : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.TPurchaseDtl", "QtyVoid", c => c.Double(nullable: false));
            //AddColumn("dbo.TPurchaseDtl", "AmountVoid", c => c.Double(nullable: false));
            AddColumn("dbo.TDODtl", "QtyVoid", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TPurchaseDtl", "QtyVoid");
            //DropColumn("dbo.TPurchaseDtl", "AmountVoid");
            DropColumn("dbo.TDODtl", "QtyVoid");
        }
    }
}
