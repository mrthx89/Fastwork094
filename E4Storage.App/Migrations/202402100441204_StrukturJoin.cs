namespace Inventory.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrukturJoin : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TStockOut", new[] { "TBelt_ID" });
            DropIndex("dbo.TStockOut", new[] { "TCategory_ID" });
            DropColumn("dbo.TStockOut", "IDBelt");
            DropColumn("dbo.TStockOut", "IDCategory");
            RenameColumn(table: "dbo.TStockOut", name: "TBelt_ID", newName: "IDBelt");
            RenameColumn(table: "dbo.TStockOut", name: "TCategory_ID", newName: "IDCategory");
            AlterColumn("dbo.TStockOut", "IDBelt", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockOut", "IDCategory", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockOut", "IDBelt", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockOut", "IDCategory", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockIn", "IDBelt", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockIn", "IDCategory", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockMasterData", "IDBelt", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockMasterData", "IDCategory", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockPengembalian", "IDBelt", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockPengembalian", "IDCategory", c => c.Guid(nullable: false));
            CreateIndex("dbo.TStockIn", "IDBelt");
            CreateIndex("dbo.TStockIn", "IDCategory");
            CreateIndex("dbo.TStockMasterData", "IDBelt");
            CreateIndex("dbo.TStockMasterData", "IDCategory");
            CreateIndex("dbo.TStockOut", "IDBelt");
            CreateIndex("dbo.TStockOut", "IDCategory");
            CreateIndex("dbo.TStockPengembalian", "IDBelt");
            CreateIndex("dbo.TStockPengembalian", "IDCategory");
            AddForeignKey("dbo.TStockIn", "IDBelt", "dbo.TBelt", "ID");
            AddForeignKey("dbo.TStockMasterData", "IDBelt", "dbo.TBelt", "ID");
            AddForeignKey("dbo.TStockMasterData", "IDCategory", "dbo.TCategory", "ID");
            AddForeignKey("dbo.TStockPengembalian", "IDBelt", "dbo.TBelt", "ID");
            AddForeignKey("dbo.TStockPengembalian", "IDCategory", "dbo.TCategory", "ID");
            AddForeignKey("dbo.TStockIn", "IDCategory", "dbo.TCategory", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TStockIn", "IDCategory", "dbo.TCategory");
            DropForeignKey("dbo.TStockPengembalian", "IDCategory", "dbo.TCategory");
            DropForeignKey("dbo.TStockPengembalian", "IDBelt", "dbo.TBelt");
            DropForeignKey("dbo.TStockMasterData", "IDCategory", "dbo.TCategory");
            DropForeignKey("dbo.TStockMasterData", "IDBelt", "dbo.TBelt");
            DropForeignKey("dbo.TStockIn", "IDBelt", "dbo.TBelt");
            DropIndex("dbo.TStockPengembalian", new[] { "IDCategory" });
            DropIndex("dbo.TStockPengembalian", new[] { "IDBelt" });
            DropIndex("dbo.TStockOut", new[] { "IDCategory" });
            DropIndex("dbo.TStockOut", new[] { "IDBelt" });
            DropIndex("dbo.TStockMasterData", new[] { "IDCategory" });
            DropIndex("dbo.TStockMasterData", new[] { "IDBelt" });
            DropIndex("dbo.TStockIn", new[] { "IDCategory" });
            DropIndex("dbo.TStockIn", new[] { "IDBelt" });
            AlterColumn("dbo.TStockPengembalian", "IDCategory", c => c.Guid());
            AlterColumn("dbo.TStockPengembalian", "IDBelt", c => c.Guid());
            AlterColumn("dbo.TStockMasterData", "IDCategory", c => c.Guid());
            AlterColumn("dbo.TStockMasterData", "IDBelt", c => c.Guid());
            AlterColumn("dbo.TStockIn", "IDCategory", c => c.Guid());
            AlterColumn("dbo.TStockIn", "IDBelt", c => c.Guid());
            AlterColumn("dbo.TStockOut", "IDCategory", c => c.Guid());
            AlterColumn("dbo.TStockOut", "IDBelt", c => c.Guid());
            AlterColumn("dbo.TStockOut", "IDCategory", c => c.Guid());
            AlterColumn("dbo.TStockOut", "IDBelt", c => c.Guid());
            RenameColumn(table: "dbo.TStockOut", name: "IDCategory", newName: "TCategory_ID");
            RenameColumn(table: "dbo.TStockOut", name: "IDBelt", newName: "TBelt_ID");
            AddColumn("dbo.TStockOut", "IDCategory", c => c.Guid());
            AddColumn("dbo.TStockOut", "IDBelt", c => c.Guid());
            CreateIndex("dbo.TStockOut", "TCategory_ID");
            CreateIndex("dbo.TStockOut", "TBelt_ID");
        }
    }
}
