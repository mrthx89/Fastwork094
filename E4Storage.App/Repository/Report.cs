using Inventory.App.Model.Entity;
using Inventory.App.Utils;
using Inventory.App.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.App.Model.ViewModel;
using AutoMapper;
using System.Data.Entity;

namespace Inventory.App.Repository
{
    public class Report
    {
        private static string Name = "Repository.Report";

        public static Tuple<bool, List<Model.ViewModel.MutasiStok>> getMutasiStoks(DateTime tglDari, DateTime tglSampai)
        {
            Tuple<bool, List<Model.ViewModel.MutasiStok>> hasil = new Tuple<bool, List<Model.ViewModel.MutasiStok>>(false, new List<Model.ViewModel.MutasiStok>());
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataSaldo = from k in context.TStockCards
                                    where DbFunctions.TruncateTime(k.Tanggal) < tglDari.Date
                                    group k by new { k.IDWarehouse, k.IDInventor } into grp
                                    select new { grp.Key.IDWarehouse, grp.Key.IDInventor, SaldoAwal = grp.Sum(o => o.QtyMasuk - o.QtyKeluar) };

                    var dataMutasi = from k in context.TStockCards
                                     where DbFunctions.TruncateTime(k.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(k.Tanggal) <= tglSampai.Date
                                     group k by new { k.IDWarehouse, k.IDInventor } into grp
                                     select new
                                     {
                                         grp.Key.IDInventor,
                                         grp.Key.IDWarehouse,
                                         QtyMasuk = grp.Sum(o => o.QtyMasuk),
                                         QtyKeluar = grp.Sum(o => o.QtyKeluar)
                                     };

                    var datas = from i in context.TInventors
                                from w in context.TWarehouses
                                from s in dataSaldo.Where(o => o.IDInventor == i.ID && o.IDWarehouse == w.ID).DefaultIfEmpty()
                                from m in dataMutasi.Where(o => o.IDInventor == i.ID && o.IDWarehouse == w.ID).DefaultIfEmpty()
                                select new Model.ViewModel.MutasiStok
                                {
                                    IDInventor = i.ID,
                                    IDUOM = i.IDUOM,
                                    NamaBarang = i.Desc,
                                    IDWarehouse = w.ID,
                                    SaldoAwal = (s != null ? s.SaldoAwal : 0),
                                    QtyMasuk = (m != null ? m.QtyMasuk : 0),
                                    QtyKeluar = (m != null ? m.QtyKeluar : 0),
                                    QtyMin = (i.QtyMin.HasValue ? i.QtyMin : 0d),
                                    QtyMax = (i.QtyMax.HasValue ? i.QtyMax : 0d)
                                };

                    hasil = new Tuple<bool, List<Model.ViewModel.MutasiStok>>(true, datas.OrderBy(o => o.NamaBarang).ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getMutasiStoks", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<Model.ViewModel.KartuStok>> getKartuStoks(Guid IDInventor, Guid IDWarehouse, DateTime tglDari, DateTime tglSampai)
        {
            Tuple<bool, List<Model.ViewModel.KartuStok>> hasil = new Tuple<bool, List<Model.ViewModel.KartuStok>>(false, new List<Model.ViewModel.KartuStok>());
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataSaldo = from k in context.TStockCards.Where(o => IDWarehouse == Guid.Empty || o.IDWarehouse == IDWarehouse)
                                    from i in context.TInventors.Where(o => o.ID == k.IDInventor).DefaultIfEmpty()
                                    where k.IDInventor == IDInventor && DbFunctions.TruncateTime(k.Tanggal) < tglDari.Date
                                    group k by new { k.IDInventor, i.IDUOM, i.Desc } into grp
                                    select new
                                    {
                                        grp.Key.IDInventor,
                                        grp.Key.IDUOM,
                                        grp.Key.Desc,
                                        SaldoAwal = grp.Sum(o => o.QtyMasuk - o.QtyKeluar)
                                    };

                    List<Model.ViewModel.KartuStok> dataKartu = (from k in context.TStockCards.Where(o => IDWarehouse == Guid.Empty || o.IDWarehouse == IDWarehouse)
                                                                 from i in context.TInventors.Where(o => o.ID == k.IDInventor).DefaultIfEmpty()
                                                                 from t in context.TTypeTransactions.Where(o => o.ID == k.IDType).DefaultIfEmpty()
                                                                 where k.IDInventor == IDInventor && DbFunctions.TruncateTime(k.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(k.Tanggal) <= tglSampai.Date
                                                                 orderby k.Tanggal, t.NoUrut
                                                                 select new Model.ViewModel.KartuStok
                                                                 {
                                                                     ID = k.ID,
                                                                     DocNo = k.DocNo,
                                                                     IDBelt = k.IDBelt,
                                                                     IDWarehouse = k.IDWarehouse,
                                                                     IDInventor = k.IDInventor,
                                                                     IDTransaksi = k.IDTransaksi,
                                                                     IDTransaksiD = k.IDTransaksiD,
                                                                     IDType = k.IDType,
                                                                     IDUOM = k.IDUOM,
                                                                     IDUserEdit = k.IDUserEdit,
                                                                     IDUserEntri = k.IDUserEntri,
                                                                     IDUserHapus = k.IDUserHapus,
                                                                     NamaBarang = i.Desc,
                                                                     PIC = k.PIC,
                                                                     QtyKeluar = k.QtyKeluar,
                                                                     QtyMasuk = k.QtyMasuk,
                                                                     SaldoAwal = 0f,
                                                                     Tanggal = k.Tanggal,
                                                                     TglEdit = k.TglEdit,
                                                                     TglEntri = k.TglEntri,
                                                                     TglHapus = k.TglHapus,
                                                                     NoUrut = t.NoUrut
                                                                 }).ToList();

                    if (dataSaldo != null && dataSaldo.Count() >= 1)
                    {
                        var saldos = from s in dataSaldo.ToList()
                                     group s by new { s.IDInventor, s.IDUOM, s.Desc } into grp
                                     select new Model.ViewModel.KartuStok
                                     {
                                         ID = Guid.NewGuid(),
                                         DocNo = "Saldo Awal",
                                         IDBelt = Guid.Empty,
                                         IDWarehouse = IDWarehouse,
                                         IDInventor = grp.Key.IDInventor,
                                         IDTransaksi = Guid.Empty,
                                         IDTransaksiD = Guid.Empty,
                                         IDType = Guid.Parse("D6022513-AFD4-4A67-9F47-594E43D5F220"),
                                         IDUOM = grp.Key.IDUOM,
                                         IDUserEdit = Guid.Empty,
                                         IDUserEntri = Guid.Empty,
                                         IDUserHapus = Guid.Empty,
                                         NamaBarang = grp.Key.Desc,
                                         PIC = "",
                                         QtyKeluar = 0f,
                                         QtyMasuk = 0f,
                                         SaldoAwal = grp.Sum(s => s.SaldoAwal),
                                         Tanggal = tglDari.Date.AddDays(-1),
                                         TglEdit = DateTime.Parse("1900-01-01"),
                                         TglEntri = DateTime.Parse("1900-01-01"),
                                         TglHapus = DateTime.Parse("1900-01-01"),
                                         NoUrut = -1
                                     };
                        dataKartu.AddRange(saldos.ToList());
                    }
                    else
                    {
                        dataKartu.AddRange(from i in context.TInventors.Where(i => i.ID == IDInventor).ToList()
                                           select new Model.ViewModel.KartuStok
                                           {
                                               ID = Guid.NewGuid(),
                                               DocNo = "Saldo Awal",
                                               IDBelt = Guid.Empty,
                                               IDWarehouse = IDWarehouse,
                                               IDInventor = i.ID,
                                               IDTransaksi = Guid.Empty,
                                               IDTransaksiD = Guid.Empty,
                                               IDType = Guid.Parse("D6022513-AFD4-4A67-9F47-594E43D5F220"),
                                               IDUOM = i.IDUOM,
                                               IDUserEdit = Guid.Empty,
                                               IDUserEntri = Guid.Empty,
                                               IDUserHapus = Guid.Empty,
                                               NamaBarang = i.Desc,
                                               PIC = "",
                                               QtyKeluar = 0f,
                                               QtyMasuk = 0f,
                                               SaldoAwal = 0f,
                                               Tanggal = tglDari.Date.AddDays(-1),
                                               TglEdit = DateTime.Parse("1900-01-01"),
                                               TglEntri = DateTime.Parse("1900-01-01"),
                                               TglHapus = DateTime.Parse("1900-01-01"),
                                               NoUrut = -1
                                           });
                    }

                    float Saldo = 0f;
                    foreach (var item in dataKartu.OrderBy(o => o.Tanggal).ThenBy(o => o.NoUrut).ToList())
                    {
                        if (item.NoUrut != -1)
                        {
                            item.SaldoAwal = Saldo;
                        }
                        Saldo = item.SaldoAkhir;
                    }

                    hasil = new Tuple<bool, List<Model.ViewModel.KartuStok>>(true, dataKartu.OrderBy(o => o.Tanggal).ThenBy(o => o.NoUrut).ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getKartuStoks", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<SaldoStok>> getSaldoStoks(Dictionary<string, dynamic> filter, DateTime? SaldoPerTanggal)
        {
            Tuple<bool, List<SaldoStok>> hasil = new Tuple<bool, List<SaldoStok>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TInventors.AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var item in filter)
                        {
                            if (item.Key.Equals("PLU"))
                            {
                                string a = (string)item.Value;
                                data = data.Where(o => o.PLU.Contains(a));
                            }
                            else if (item.Key.Equals("DESC"))
                            {
                                string a = (string)item.Value;
                                data = data.Where(o => o.Desc.Contains(a));
                            }
                        }
                    }
                    var saldoQuery = from stockCard in context.TStockCards
                                     join item in data on stockCard.IDInventor equals item.ID
                                     join gudang in context.TWarehouses on stockCard.IDWarehouse equals gudang.ID
                                     where stockCard.Tanggal <= (SaldoPerTanggal ?? DateTime.MaxValue)
                                     group stockCard by new { stockCard.IDInventor, stockCard.IDWarehouse, gudang.Code } into grouped
                                     select new
                                     {
                                         IDInventor = grouped.Key.IDInventor,
                                         IDWarehouse = grouped.Key.IDWarehouse,
                                         Warehouse = grouped.Key.Code,
                                         Saldo = grouped.Sum(t => t.QtyMasuk - t.QtyKeluar)
                                     };
                    var items = (from item in data
                                 from saldo in saldoQuery
                                 select new SaldoStok
                                 {
                                     ID = item.ID,
                                     Desc = item.Desc,
                                     IDUOM = item.IDUOM,
                                     IDUserEdit = item.IDUserEdit,
                                     IDUserEntri = item.IDUserEntri,
                                     IDUserHapus = item.IDUserHapus,
                                     PLU = item.PLU,
                                     Saldo = (saldo != null ? saldo.Saldo : 0),
                                     TglEdit = item.TglEdit,
                                     TglEntri = item.TglEntri,
                                     TglHapus = item.TglHapus,
                                     QtyMax = item.QtyMax,
                                     QtyMin = item.QtyMin,
                                     IDWarehouse = saldo.IDWarehouse,
                                     Warehouse = saldo.Warehouse
                                 }).ToList();
                    hasil = new Tuple<bool, List<SaldoStok>>(true, items);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getSaldoStoks", ex);
                }
            }
            return hasil;
        }
    }
}
