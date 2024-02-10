using Inventory.App.Helper;
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
                                     TaxType = item.TaxType,
                                     Void = item.Void,
                                     TaxProsen = item.TaxProsen,
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
                                                        Inventor = i.Desc
                                                    }).ToList(),
                                     IDUserEdit = item.IDUserEdit,
                                     IDUserEntri = item.IDUserEntri,
                                     IDUserHapus = item.IDUserHapus,
                                     TglEdit = item.TglEdit,
                                     TglEntri = item.TglEntri,
                                     TglHapus = item.TglHapus
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
    }
}
