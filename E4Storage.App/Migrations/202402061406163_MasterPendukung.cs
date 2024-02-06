namespace Inventory.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MasterPendukung : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TWarehouse",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.TContact",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Cell = c.String(maxLength: 50),
                        ContactPerson = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        Vendor = c.Boolean(nullable: false),
                        Customer = c.Boolean(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => new { t.Code, t.Vendor, t.Customer }, unique: true);
            
            AddColumn("dbo.TStockOut", "IDWarehouse", c => c.Guid(nullable: false));
            AddColumn("dbo.TStockCard", "IDWarehouse", c => c.Guid(nullable: false));
            AddColumn("dbo.TStockIn", "IDWarehouse", c => c.Guid(nullable: false));
            AddColumn("dbo.TStockMasterData", "IDWarehouse", c => c.Guid(nullable: false));
            AddColumn("dbo.TStockPengembalian", "IDWarehouse", c => c.Guid(nullable: false));
            CreateIndex("dbo.TStockOut", "IDWarehouse");
            CreateIndex("dbo.TStockCard", "IDWarehouse");
            CreateIndex("dbo.TStockIn", "IDWarehouse");
            CreateIndex("dbo.TStockMasterData", "IDWarehouse");
            CreateIndex("dbo.TStockPengembalian", "IDWarehouse");
            AddForeignKey("dbo.TStockMasterData", "IDWarehouse", "dbo.TWarehouse", "ID");
            AddForeignKey("dbo.TStockPengembalian", "IDWarehouse", "dbo.TWarehouse", "ID");
            AddForeignKey("dbo.TStockIn", "IDWarehouse", "dbo.TWarehouse", "ID");
            AddForeignKey("dbo.TStockCard", "IDWarehouse", "dbo.TWarehouse", "ID");
            AddForeignKey("dbo.TStockOut", "IDWarehouse", "dbo.TWarehouse", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TStockOut", "IDWarehouse", "dbo.TWarehouse");
            DropForeignKey("dbo.TStockCard", "IDWarehouse", "dbo.TWarehouse");
            DropForeignKey("dbo.TStockIn", "IDWarehouse", "dbo.TWarehouse");
            DropForeignKey("dbo.TStockPengembalian", "IDWarehouse", "dbo.TWarehouse");
            DropForeignKey("dbo.TStockMasterData", "IDWarehouse", "dbo.TWarehouse");
            DropIndex("dbo.TContact", new[] { "Code", "Vendor", "Customer" });
            DropIndex("dbo.TStockPengembalian", new[] { "IDWarehouse" });
            DropIndex("dbo.TStockMasterData", new[] { "IDWarehouse" });
            DropIndex("dbo.TWarehouse", new[] { "Code" });
            DropIndex("dbo.TStockIn", new[] { "IDWarehouse" });
            DropIndex("dbo.TStockCard", new[] { "IDWarehouse" });
            DropIndex("dbo.TStockOut", new[] { "IDWarehouse" });
            DropColumn("dbo.TStockPengembalian", "IDWarehouse");
            DropColumn("dbo.TStockMasterData", "IDWarehouse");
            DropColumn("dbo.TStockIn", "IDWarehouse");
            DropColumn("dbo.TStockCard", "IDWarehouse");
            DropColumn("dbo.TStockOut", "IDWarehouse");
            DropTable("dbo.TContact");
            DropTable("dbo.TWarehouse");
        }
    }
}
