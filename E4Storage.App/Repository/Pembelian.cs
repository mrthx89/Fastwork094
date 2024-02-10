using Inventory.App.Helper;
using Inventory.App.Model.Entity;
using Inventory.App.Model.ViewModel;
using Inventory.App.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Repository
{
    public class Pembelian
    {
        private static string Name = "Repository.Pembelian";

        public static Tuple<bool, List<Purchase>> getPurchases(DateTime TglDari, DateTime TglSampai)
        {
            Tuple<bool, List<Purchase>> hasil = new Tuple<bool, List<Purchase>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TPurchases.Where(o =>
                                                        DbFunctions.TruncateTime(o.DocDate) >= DbFunctions.TruncateTime(TglDari) &&
                                                        DbFunctions.TruncateTime(o.DocDate) <= DbFunctions.TruncateTime(TglSampai)).AsQueryable();
                    var items = (from item in data
                                 select new Purchase
                                 {
                                     ID = item.ID,
                                     DocDate = item.DocDate,
                                     DocNo = item.DocNo,
                                     IDVendor = item.IDVendor,
                                     DiscProsen = item.DiscProsen,
                                     IDWarehouse = item.IDWarehouse,
                                     NoReff = item.NoReff,
                                     Note = item.Note,
                                     Void = item.Void,
                                     TaxType = item.TaxType,
                                     TaxProsen = item.TaxProsen,
                                     IDUserEdit = item.IDUserEdit,
                                     IDUserEntri = item.IDUserEntri,
                                     IDUserHapus = item.IDUserHapus,
                                     TglEdit = item.TglEdit,
                                     TglEntri = item.TglEntri,
                                     TglHapus = item.TglHapus,
                                     PurchaseDtl = (from x in item.PurchaseDtls
                                                    from i in context.TInventors.Where(o => o.ID == x.IDInventor).DefaultIfEmpty()
                                                    select new PurchaseDtl
                                                    {
                                                        ID = x.ID,
                                                        IDPurchase = x.IDPurchase,
                                                        Disc1Prosen = x.Disc1Prosen,
                                                        DiscProsen = x.DiscProsen,
                                                        Disc1 = x.Disc1,
                                                        NoUrut = x.NoUrut,
                                                        IDInventor = x.IDInventor,
                                                        IDUOM = x.IDUOM,
                                                        IDUserEdit = x.IDUserEdit,
                                                        IDUserEntri = x.IDUserEntri,
                                                        IDUserHapus = x.IDUserHapus,
                                                        TglEdit = x.TglEdit,
                                                        TglEntri = x.TglEntri,
                                                        TglHapus = x.TglHapus,
                                                        Note = x.Note,
                                                        Qty = x.Qty,
                                                        TaxDefault = x.TaxDefault,
                                                        TaxProsen = x.TaxProsen,
                                                        UnitPrice = x.UnitPrice,
                                                        Tax = x.Tax,
                                                        Desc = i.Desc
                                                    }).ToList()
                                 }).ToList();
                    hasil = new Tuple<bool, List<Purchase>>(true, items);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getPurchases", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, string, Purchase> savePurchases(Purchase data)
        {
            bool saveHeader = false;
            Tuple<bool, string, Purchase> hasil = new Tuple<bool, string, Purchase>(false, "", null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    int iLoc = 0;
                    //Kosongi dulu Detailnya
                    foreach (var item in data.PurchaseDtl.OrderBy(o => o.NoUrut))
                    {
                        iLoc++;
                        item.ID = (item.ID == Guid.Empty ? Guid.NewGuid() : item.ID);
                        item.IDPurchase = data.ID;
                        item.NoUrut = iLoc;
                        item.Disc1Prosen = 0d;
                        item.Disc1 = 0d;
                        item.TaxDefault = 0d;
                        item.TaxProsen = 0d;
                        item.Tax = 0d;
                    }
                    iLoc = 0;
                    foreach (var item in data.PurchaseDtl.OrderBy(o => o.Amount))
                    {
                        iLoc++;
                        item.Disc1Prosen = data.DiscProsen;
                        item.Disc1 = Math.Round(item.Amount * (item.Disc1Prosen / 100d), 2);
                        if (iLoc >= data.PurchaseDtl.Count)
                        {
                            //Addjustment
                            item.Disc1 += data.Disc - data.PurchaseDtl.Sum(o => o.Disc1);
                        }
                        item.TaxProsen = data.TaxProsen;
                        item.TaxDefault = Math.Round(data.TaxType == 1 ? (item.Amount - item.Disc1) / (1d + (item.TaxProsen / 100d)) : (item.Amount - item.Disc1), 2);
                        if (iLoc >= data.PurchaseDtl.Count)
                        {
                            //Addjustment
                            item.TaxDefault += data.TaxDefault - data.PurchaseDtl.Sum(o => o.TaxDefault);
                        }
                        item.Tax = Math.Round(data.TaxType == 0 ? 0d : data.TaxType == 1 ? (item.Amount - item.Disc1) - item.TaxDefault : item.TaxDefault * (item.TaxProsen / 100d), 2);
                        if (iLoc >= data.PurchaseDtl.Count)
                        {
                            //Addjustment
                            item.Tax += data.Tax - data.PurchaseDtl.Sum(o => o.Tax);
                        }
                    }

                    var dataExist = context.TPurchases.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        if (dataExist.Void)
                        {
                            hasil = new Tuple<bool, string, Purchase>(false, "Data telah divoid!", null);
                            saveHeader = false;
                        }
                        else
                        {
                            data.IDUserEdit = Constant.UserLogin.ID;
                            data.TglEdit = DateTime.Now;

                            context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<Model.ViewModel.Purchase, TPurchase>(data));
                            saveHeader = true;
                        }
                    }
                    else
                    {
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;

                        string docNo = $"BL/{data.DocDate.ToString("yyMM")}/";
                        if (context.TPurchases.Where(o => o.DocNo.Substring(0, docNo.Length).Equals(docNo)).Count() >= 1)
                        {
                            int maxCode = context.TPurchases.Where(o => o.DocNo.Substring(0, docNo.Length).Equals(docNo))
                                            .Max(o => o.DocNo.Substring(docNo.Length))
                                            .Select(o => int.Parse(o.ToString()))
                                            .Max();
                            data.DocNo = $"{docNo}{(maxCode + 1).ToString().PadLeft(5, '0')}";
                        }
                        else
                        {
                            data.DocNo = $"{docNo}{1.ToString().PadLeft(5, '0')}";
                        }

                        context.TPurchases.Add(Constant.mapper.Map<Model.ViewModel.Purchase, TPurchase>(data));
                        saveHeader = true;
                    }

                    if (saveHeader)
                    {
                        //Remove Kartu Stok
                        context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokPembelian));
                        //Remove Detail
                        context.TPurchaseDtls.RemoveRange(context.TPurchaseDtls.Where(o => o.IDPurchase == data.ID));

                        foreach (var item in data.PurchaseDtl.OrderBy(o => o.NoUrut))
                        {
                            TPurchaseDtl detil = Constant.mapper.Map<Model.ViewModel.PurchaseDtl, TPurchaseDtl>(item);
                            //Insert Detail
                            context.TPurchaseDtls.Add(detil);

                            //Insert Kartu Stok
                            TStockCard kartu = new TStockCard()
                            {
                                Cabinet = null,
                                DocNo = data.DocNo,
                                ID = detil.ID,
                                IDBelt = null,
                                IDCategory = null,
                                IDInventor = detil.IDInventor,
                                IDTransaksi = data.ID,
                                IDTransaksiD = detil.ID,
                                IDType = Constant.stokPembelian,
                                IDUOM = detil.IDUOM,
                                IDUserEdit = data.IDUserEdit,
                                IDUserEntri = data.IDUserEntri,
                                IDUserHapus = data.IDUserHapus,
                                IDWarehouse = data.IDWarehouse,
                                PIC = "",
                                QtyKeluar = 0f,
                                QtyMasuk = (float)detil.Qty,
                                Row = "",
                                Tanggal = data.DocDate,
                                TglEdit = data.TglEdit,
                                TglEntri = data.TglEntri,
                                TglHapus = data.TglHapus
                            };
                            context.TStockCards.Add(kartu);
                        }

                        context.SaveChanges();
                        hasil = new Tuple<bool, string, Purchase>(true, "", data);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getPurchases", ex);
                }
            }
            return hasil;
        }
    }
}
