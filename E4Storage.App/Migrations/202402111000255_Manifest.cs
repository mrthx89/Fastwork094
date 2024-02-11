namespace Inventory.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Manifest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TDODtl",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IDDO = c.Guid(nullable: false),
                        NoUrut = c.Int(nullable: false),
                        IDInventor = c.Guid(nullable: false),
                        IDUOM = c.Guid(nullable: false),
                        Qty = c.Double(nullable: false),
                        Note = c.String(maxLength: 255),
                        Finish = c.Boolean(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TDO", t => t.IDDO, cascadeDelete: true)
                .ForeignKey("dbo.TInventor", t => t.IDInventor)
                .ForeignKey("dbo.TUOM", t => t.IDUOM)
                .Index(t => t.IDDO)
                .Index(t => t.IDInventor)
                .Index(t => t.IDUOM);
            
            CreateTable(
                "dbo.TDO",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        DocNo = c.String(nullable: false, maxLength: 20),
                        DocDate = c.DateTime(nullable: false),
                        NoReff = c.String(),
                        IDWarehouse = c.Guid(nullable: false),
                        IDCustomer = c.Guid(nullable: false),
                        SealNo = c.String(maxLength: 255),
                        ContainerNo = c.String(maxLength: 255),
                        ConditionDelivery = c.String(maxLength: 255),
                        Plant = c.String(maxLength: 255),
                        VehicleNo = c.String(maxLength: 255),
                        SalesOrderNo = c.String(maxLength: 255),
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
                .ForeignKey("dbo.TWarehouse", t => t.IDWarehouse)
                .Index(t => t.DocNo, unique: true)
                .Index(t => t.DocDate)
                .Index(t => t.IDWarehouse)
                .Index(t => t.IDCustomer);
            
            AddColumn("dbo.TContact", "NPWP", c => c.String(maxLength: 50));
            AddColumn("dbo.TUser", "IsSuperAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.TUser", "IsGudang", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TDODtl", "IDUOM", "dbo.TUOM");
            DropForeignKey("dbo.TDODtl", "IDInventor", "dbo.TInventor");
            DropForeignKey("dbo.TDODtl", "IDDO", "dbo.TDO");
            DropForeignKey("dbo.TDO", "IDWarehouse", "dbo.TWarehouse");
            DropForeignKey("dbo.TDO", "IDCustomer", "dbo.TContact");
            DropIndex("dbo.TDO", new[] { "IDCustomer" });
            DropIndex("dbo.TDO", new[] { "IDWarehouse" });
            DropIndex("dbo.TDO", new[] { "DocDate" });
            DropIndex("dbo.TDO", new[] { "DocNo" });
            DropIndex("dbo.TDODtl", new[] { "IDUOM" });
            DropIndex("dbo.TDODtl", new[] { "IDInventor" });
            DropIndex("dbo.TDODtl", new[] { "IDDO" });
            DropColumn("dbo.TUser", "IsGudang");
            DropColumn("dbo.TUser", "IsSuperAdmin");
            DropColumn("dbo.TContact", "NPWP");
            DropTable("dbo.TDO");
            DropTable("dbo.TDODtl");
        }
    }
}
