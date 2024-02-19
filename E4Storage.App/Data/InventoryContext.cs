using Inventory.App.Model.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Inventory.App.Data
{
    public partial class InventoryContext : DbContext
    {
        public InventoryContext()
            : base("name=Inventory")
        {

        }

        public InventoryContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<TTypeTransaction> TTypeTransactions { get; set; }
        public DbSet<TUOM> TUOMs { get; set; }
        public DbSet<TUser> TUsers { get; set; }
        public DbSet<TBelt> TBelts { get; set; }
        public DbSet<TCategory> TCategories { get; set; }
        public DbSet<TInventor> TInventors { get; set; }
        public DbSet<TStockIn> TStockIns { get; set; }
        public DbSet<TStockOut> TStockOuts { get; set; }
        public DbSet<TStockCard> TStockCards { get; set; }
        public DbSet<TStockPengembalian> TStockPengembalians { get; set; }
        public DbSet<TStockMasterData> TStockMasterDatas { get; set; }
        public DbSet<TContact> TContacts { get; set; }
        public DbSet<TWarehouse> TWarehouses { get; set; }
        public DbSet<TPurchase> TPurchases { get; set; }
        public DbSet<TPurchaseDtl> TPurchaseDtls { get; set; }
        public DbSet<TDO> TDOs { get; set; }
        public DbSet<TDODtl> TDODtls { get; set; }
        public DbSet<TIV> TIVs { get; set; }
        public DbSet<TIVDtl> TIVDtls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TTypeTransaction>()
                .Property(p => p.NoUrut)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_NoUrut") { IsUnique = true }));

            modelBuilder.Entity<TTypeTransaction>()
                .Property(p => p.Transaksi)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Transaksi") { IsUnique = true }));

            modelBuilder.Entity<TUser>()
                .Property(p => p.UserID)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_UserID") { IsUnique = true }));

            modelBuilder.Entity<TUOM>()
                .Property(p => p.Satuan)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Satuan") { IsUnique = true }));

            modelBuilder.Entity<TInventor>()
                .Property(p => p.PLU)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PLU") { IsUnique = true }));

            modelBuilder.Entity<TBelt>()
                .Property(p => p.Belt)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Belt") { IsUnique = true }));

            modelBuilder.Entity<TCategory>()
                .Property(p => p.Category)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Category") { IsUnique = true }));

            modelBuilder.Entity<TStockIn>()
                .Property(p => p.NoPO)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_NoPO")));

            modelBuilder.Entity<TStockIn>()
                .Property(p => p.NoSJ)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_NoSJ")));

            modelBuilder.Entity<TStockOut>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo")));

            modelBuilder.Entity<TStockPengembalian>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo")));

            modelBuilder.Entity<TStockMasterData>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo")));

            modelBuilder.Entity<TPurchase>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo") { IsUnique = true }));

            modelBuilder.Entity<TPurchase>()
                .Property(p => p.DocDate)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocDate")));

            modelBuilder.Entity<TDO>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo") { IsUnique = true }));

            modelBuilder.Entity<TDO>()
                .Property(p => p.DocDate)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocDate")));

            modelBuilder.Entity<TIV>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo") { IsUnique = true }));

            modelBuilder.Entity<TIV>()
                .Property(p => p.DocDate)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocDate")));

            modelBuilder.Entity<TContact>()
                .HasIndex(p => new { p.Code, p.Vendor, p.Customer })
                .IsUnique();

            modelBuilder.Entity<TWarehouse>()
                .HasIndex(p => new { p.Code })
                .IsUnique();

            modelBuilder.Entity<TStockCard>()
                .HasIndex(p => new { p.IDTransaksiD, p.IDType })
                .IsUnique();

            modelBuilder.Entity<TInventor>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.Inventors)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockCard>()
                .HasRequired(b => b.TypeTransaction)
                .WithMany(a => a.StockCards)
                .HasForeignKey(b => b.IDType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockCard>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockCards)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockIn>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockIns)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockOut>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockOuts)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockPengembalian>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockPengembalians)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockMasterData>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockMasterDatas)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockCard>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockCards)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockIn>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockIns)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockOut>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockOuts)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockPengembalian>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockPengembalians)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockMasterData>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockMasterDatas)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockCard>()
                .HasRequired(b => b.Warehouse)
                .WithMany(a => a.StockCards)
                .HasForeignKey(b => b.IDWarehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockIn>()
                .HasRequired(b => b.Warehouse)
                .WithMany(a => a.StockIns)
                .HasForeignKey(b => b.IDWarehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockOut>()
                .HasRequired(b => b.Warehouse)
                .WithMany(a => a.StockOuts)
                .HasForeignKey(b => b.IDWarehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockPengembalian>()
                .HasRequired(b => b.Warehouse)
                .WithMany(a => a.StockPengembalians)
                .HasForeignKey(b => b.IDWarehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockMasterData>()
                .HasRequired(b => b.Warehouse)
                .WithMany(a => a.StockMasterDatas)
                .HasForeignKey(b => b.IDWarehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TPurchase>()
                .HasRequired(b => b.Warehouse)
                .WithMany(a => a.Purchases)
                .HasForeignKey(b => b.IDWarehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TPurchase>()
                .HasRequired(b => b.Vendor)
                .WithMany(a => a.Purchases)
                .HasForeignKey(b => b.IDVendor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TPurchaseDtl>()
                .HasRequired(b => b.Purchase)
                .WithMany(a => a.PurchaseDtls)
                .HasForeignKey(b => b.IDPurchase)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TPurchaseDtl>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.PurchaseDtls)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TPurchaseDtl>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.PurchaseDtls)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TDO>()
                .HasRequired(b => b.Warehouse)
                .WithMany(a => a.DOs)
                .HasForeignKey(b => b.IDWarehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TDO>()
                .HasRequired(b => b.Customer)
                .WithMany(a => a.DOs)
                .HasForeignKey(b => b.IDCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TDODtl>()
                .HasRequired(b => b.DO)
                .WithMany(a => a.DODtls)
                .HasForeignKey(b => b.IDDO)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TDODtl>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.DODtls)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TDODtl>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.DODtls)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<TStockCard>()
            //    .HasRequired(b => b.Category)
            //    .WithMany(a => a.StockCards)
            //    .HasForeignKey(b => b.IDCategory)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockIn>()
                .HasRequired(b => b.Category)
                .WithMany(a => a.StockIns)
                .HasForeignKey(b => b.IDCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockMasterData>()
                .HasRequired(b => b.Category)
                .WithMany(a => a.StockMasterDatas)
                .HasForeignKey(b => b.IDCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockOut>()
                .HasRequired(b => b.Category)
                .WithMany(a => a.StockOuts)
                .HasForeignKey(b => b.IDCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockPengembalian>()
                .HasRequired(b => b.Category)
                .WithMany(a => a.StockPengembalians)
                .HasForeignKey(b => b.IDCategory)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<TStockCard>()
            //    .HasRequired(b => b.Belt)
            //    .WithMany(a => a.StockCards)
            //    .HasForeignKey(b => b.IDBelt)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockIn>()
                .HasRequired(b => b.Belt)
                .WithMany(a => a.StockIns)
                .HasForeignKey(b => b.IDBelt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockMasterData>()
                .HasRequired(b => b.Belt)
                .WithMany(a => a.StockMasterDatas)
                .HasForeignKey(b => b.IDBelt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockOut>()
                .HasRequired(b => b.Belt)
                .WithMany(a => a.StockOuts)
                .HasForeignKey(b => b.IDBelt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockPengembalian>()
                .HasRequired(b => b.Belt)
                .WithMany(a => a.StockPengembalians)
                .HasForeignKey(b => b.IDBelt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIV>()
                .HasRequired(b => b.Customer)
                .WithMany(a => a.IVs)
                .HasForeignKey(b => b.IDCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIVDtl>()
                .HasRequired(b => b.IV)
                .WithMany(a => a.IVDtls)
                .HasForeignKey(b => b.IDIV)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TIVDtl>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.IVDtls)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIVDtl>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.IVDtls)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIVDtl>()
                .HasOptional(b => b.DODtl)
                .WithMany(a => a.IVDtls)
                .HasForeignKey(b => b.IDDODtl)
                .WillCascadeOnDelete(false);
        }
    }
}
