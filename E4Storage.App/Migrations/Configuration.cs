namespace Inventory.App.Migrations
{
    using Inventory.App.Model.Entity;
    using Inventory.App.Utils;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inventory.App.Data.InventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // Atur ke false untuk menghindari kehilangan data
        }

        protected override void Seed(Inventory.App.Data.InventoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            TUser sysAdmin = new TUser {
                ID = Constant.sysAdmin,
                IDUserEntri = Constant.sysAdmin,
                IDUserEdit = Guid.Empty,
                IDUserHapus = Guid.Empty,
                IsAdmin = true,
                IsGudang = true,
                IsSuperAdmin = true,
                Nama = "Admin",
                Password = Repository.Utils.GetHash("SysAdmin".ToUpper()),
                TglEntri = DateTime.Now,
                UserID = "SysAdmin"
            };
            if (context.TUsers.FirstOrDefault(o => o.ID.Equals(sysAdmin.ID)) == null)
            {
                context.TUsers.Add(sysAdmin);
            }

            TTypeTransaction typeTransaction = new TTypeTransaction
            {
                ID = Utils.Constant.stokInType,
                Transaksi = "Stok Masuk",
                NoUrut = 1,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction);
            }

            TTypeTransaction typeTransaction2 = new TTypeTransaction
            {
                ID = Utils.Constant.stokOutType,
                Transaksi = "Stok Keluar",
                NoUrut = 4,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction2.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction2);
            }

            TTypeTransaction typeTransaction3 = new TTypeTransaction
            {
                ID = Utils.Constant.stokPengembalianType,
                Transaksi = "Stok Pengembalian",
                NoUrut = 3,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction3.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction3);
            }
            
            TTypeTransaction typeTransaction4 = new TTypeTransaction
            {
                ID = Utils.Constant.stokSaldoAwal,
                Transaksi = "Saldo Awal",
                NoUrut = -1,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction4.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction4);
            }

            TTypeTransaction typeTransaction5 = new TTypeTransaction
            {
                ID = Utils.Constant.stokMasterDataType,
                Transaksi = "Master Data",
                NoUrut = 2,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction5.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction5);
            }

            TTypeTransaction typeTransaction6 = new TTypeTransaction
            {
                ID = Utils.Constant.stokPembelian,
                Transaksi = "Pembelian",
                NoUrut = 5,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction6.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction6);
            }

            TTypeTransaction typeTransaction7 = new TTypeTransaction
            {
                ID = Utils.Constant.stokReturPembelian,
                Transaksi = "Retur Pembelian",
                NoUrut = 6,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction7.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction7);
            }

            TTypeTransaction typeTransaction9 = new TTypeTransaction
            {
                ID = Utils.Constant.stokPenjualan,
                Transaksi = "Penjualan",
                NoUrut = 8,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction9.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction9);
            }

            TTypeTransaction typeTransaction10 = new TTypeTransaction
            {
                ID = Utils.Constant.stokReturPenjualan,
                Transaksi = "Retur Penjualan",
                NoUrut = 9,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction10.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction10);
            }

            TTypeTransaction typeTransaction11 = new TTypeTransaction
            {
                ID = Utils.Constant.stokManifest,
                Transaksi = "Pengiriman Barang",
                NoUrut = 10,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction11.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction11);
            }

            TWarehouse warehouse = new TWarehouse
            {
                ID = Utils.Constant.warehouse,
                Code = "UTM",
                Name = "Utama",
                Active = true,
                Address = "",
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TWarehouses.FirstOrDefault(o => o.ID.Equals(warehouse.ID)) == null)
            {
                context.TWarehouses.Add(warehouse);

                foreach (var item in context.TStockCards)
                {
                    item.IDWarehouse = warehouse.ID;
                }
                foreach (var item in context.TStockIns)
                {
                    item.IDWarehouse = warehouse.ID;
                }
                foreach (var item in context.TStockMasterDatas)
                {
                    item.IDWarehouse = warehouse.ID;
                }
                foreach (var item in context.TStockOuts)
                {
                    item.IDWarehouse = warehouse.ID;
                }
                foreach (var item in context.TStockPengembalians)
                {
                    item.IDWarehouse = warehouse.ID;
                }
            }

            context.SaveChanges();
        }
    }
}
