namespace Inventory.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TPurchaseDtl",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IDPurchase = c.Guid(nullable: false),
                        NoUrut = c.Int(nullable: false),
                        IDInventor = c.Guid(nullable: false),
                        IDUOM = c.Guid(nullable: false),
                        Qty = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        DiscProsen = c.Double(nullable: false),
                        Disc = c.Double(nullable: false),
                        TaxDefault = c.Double(nullable: false),
                        TaxProsen = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        Note = c.String(maxLength: 255),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TInventor", t => t.IDInventor)
                .ForeignKey("dbo.TPurchase", t => t.IDPurchase, cascadeDelete: true)
                .ForeignKey("dbo.TUOM", t => t.IDUOM)
                .Index(t => t.IDPurchase)
                .Index(t => t.IDInventor)
                .Index(t => t.IDUOM);
            
            CreateTable(
                "dbo.TPurchase",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        DocNo = c.String(nullable: false, maxLength: 20),
                        DocDate = c.DateTime(nullable: false),
                        NoReff = c.String(),
                        IDWarehouse = c.Guid(nullable: false),
                        IDVendor = c.Guid(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        TaxType = c.Int(nullable: false),
                        TaxDefault = c.Double(nullable: false),
                        TaxProsen = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        DiscProsen = c.Double(nullable: false),
                        Disc = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        Note = c.String(maxLength: 255),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TContact", t => t.IDVendor)
                .ForeignKey("dbo.TWarehouse", t => t.IDWarehouse)
                .Index(t => t.DocNo, unique: true)
                .Index(t => t.DocDate)
                .Index(t => t.IDWarehouse)
                .Index(t => t.IDVendor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TPurchaseDtl", "IDUOM", "dbo.TUOM");
            DropForeignKey("dbo.TPurchaseDtl", "IDPurchase", "dbo.TPurchase");
            DropForeignKey("dbo.TPurchase", "IDWarehouse", "dbo.TWarehouse");
            DropForeignKey("dbo.TPurchase", "IDVendor", "dbo.TContact");
            DropForeignKey("dbo.TPurchaseDtl", "IDInventor", "dbo.TInventor");
            DropIndex("dbo.TPurchase", new[] { "IDVendor" });
            DropIndex("dbo.TPurchase", new[] { "IDWarehouse" });
            DropIndex("dbo.TPurchase", new[] { "DocDate" });
            DropIndex("dbo.TPurchase", new[] { "DocNo" });
            DropIndex("dbo.TPurchaseDtl", new[] { "IDUOM" });
            DropIndex("dbo.TPurchaseDtl", new[] { "IDInventor" });
            DropIndex("dbo.TPurchaseDtl", new[] { "IDPurchase" });
            DropTable("dbo.TPurchase");
            DropTable("dbo.TPurchaseDtl");
        }
    }
}
