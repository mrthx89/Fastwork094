namespace Inventory.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TIV",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        DocNo = c.String(nullable: false, maxLength: 20),
                        DocDate = c.DateTime(nullable: false),
                        NoReff = c.String(),
                        NoFakturPajak = c.String(),
                        TaxType = c.Int(nullable: false),
                        TaxDefault = c.Double(nullable: false),
                        TaxProsen = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        IDCustomer = c.Guid(nullable: false),
                        SalesOrderNo = c.String(maxLength: 255),
                        Due = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 255),
                        Void = c.Boolean(nullable: false),
                        Finish = c.Boolean(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TContact", t => t.IDCustomer)
                .Index(t => t.DocNo, unique: true)
                .Index(t => t.DocDate)
                .Index(t => t.IDCustomer);
            
            CreateTable(
                "dbo.TIVDtl",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IDIV = c.Guid(nullable: false),
                        NoUrut = c.Int(nullable: false),
                        IDInventor = c.Guid(nullable: false),
                        IDUOM = c.Guid(nullable: false),
                        Qty = c.Double(nullable: false),
                        QtyVoid = c.Double(nullable: false),
                        Note = c.String(maxLength: 255),
                        IDDODtl = c.Guid(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TDODtl", t => t.IDDODtl)
                .ForeignKey("dbo.TInventor", t => t.IDInventor)
                .ForeignKey("dbo.TIV", t => t.IDIV, cascadeDelete: true)
                .ForeignKey("dbo.TUOM", t => t.IDUOM)
                .Index(t => t.IDIV)
                .Index(t => t.IDInventor)
                .Index(t => t.IDUOM)
                .Index(t => t.IDDODtl);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TIVDtl", "IDUOM", "dbo.TUOM");
            DropForeignKey("dbo.TIVDtl", "IDIV", "dbo.TIV");
            DropForeignKey("dbo.TIVDtl", "IDInventor", "dbo.TInventor");
            DropForeignKey("dbo.TIVDtl", "IDDODtl", "dbo.TDODtl");
            DropForeignKey("dbo.TIV", "IDCustomer", "dbo.TContact");
            DropIndex("dbo.TIVDtl", new[] { "IDDODtl" });
            DropIndex("dbo.TIVDtl", new[] { "IDUOM" });
            DropIndex("dbo.TIVDtl", new[] { "IDInventor" });
            DropIndex("dbo.TIVDtl", new[] { "IDIV" });
            DropIndex("dbo.TIV", new[] { "IDCustomer" });
            DropIndex("dbo.TIV", new[] { "DocDate" });
            DropIndex("dbo.TIV", new[] { "DocNo" });
            DropTable("dbo.TIVDtl");
            DropTable("dbo.TIV");
        }
    }
}
