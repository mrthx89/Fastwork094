using Inventory.App.Helper;
using Inventory.App.Model.Entity;
using Inventory.App.Model.ViewModel;
using Inventory.App.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Repository
{
    public class PengirimanBarang
    {
        private static string Name = "Repository.PengirimanBarang";

        public static Tuple<bool, List<DO>> getDOs(DateTime TglDari, DateTime TglSampai)
        {
            Tuple<bool, List<DO>> hasil = new Tuple<bool, List<DO>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TDOs.Where(o =>
                                                        DbFunctions.TruncateTime(o.DocDate) >= DbFunctions.TruncateTime(TglDari) &&
                                                        DbFunctions.TruncateTime(o.DocDate) <= DbFunctions.TruncateTime(TglSampai)).AsQueryable();
                    var items = (from item in data
                                 select new DO
                                 {
                                     ID = item.ID,
                                     DocDate = item.DocDate,
                                     DocNo = item.DocNo,
                                     IDCustomer = item.IDCustomer,
                                     IDWarehouse = item.IDWarehouse,
                                     NoReff = item.NoReff,
                                     Note = item.Note,
                                     Void = item.Void,
                                     IDUserEdit = item.IDUserEdit,
                                     IDUserEntri = item.IDUserEntri,
                                     IDUserHapus = item.IDUserHapus,
                                     TglEdit = item.TglEdit,
                                     TglEntri = item.TglEntri,
                                     TglHapus = item.TglHapus,
                                     ConditionDelivery = item.ConditionDelivery,
                                     ContainerNo = item.ContainerNo,
                                     Finish = item.Finish,
                                     Plant = item.Plant,
                                     SalesOrderNo = item.SalesOrderNo,
                                     SealNo = item.SealNo,
                                     VehicleNo = item.VehicleNo,
                                     DODtl = (from x in item.DODtls
                                                    from i in context.TInventors.Where(o => o.ID == x.IDInventor).DefaultIfEmpty()
                                                    select new DODtl
                                                    {
                                                        ID = x.ID,
                                                        IDDO = x.IDDO,
                                                        NoUrut = x.NoUrut,
                                                        IDInventor = x.IDInventor,
                                                        Desc = i.Desc,
                                                        IDUOM = x.IDUOM,
                                                        IDUserEdit = x.IDUserEdit,
                                                        IDUserEntri = x.IDUserEntri,
                                                        IDUserHapus = x.IDUserHapus,
                                                        TglEdit = x.TglEdit,
                                                        TglEntri = x.TglEntri,
                                                        TglHapus = x.TglHapus,
                                                        Note = x.Note,
                                                        Qty = x.Qty,
                                                        QtyVoid = x.QtyVoid,
                                                        Finish = x.Finish
                                                    }).ToList()
                                 }).ToList();
                    hasil = new Tuple<bool, List<DO>>(true, items);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getDOs", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, string, DO> saveDOs(DO data)
        {
            bool saveHeader = false;
            Tuple<bool, string, DO> hasil = new Tuple<bool, string, DO>(false, "", null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    int iLoc = 0;
                    //Kosongi dulu Detailnya
                    foreach (var item in data.DODtl.OrderBy(o => o.NoUrut))
                    {
                        iLoc++;
                        item.ID = (item.ID == Guid.Empty ? Guid.NewGuid() : item.ID);
                        item.IDDO = data.ID;
                        item.NoUrut = iLoc;
                    }

                    var dataExist = context.TDOs.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        if (dataExist.Void)
                        {
                            hasil = new Tuple<bool, string, DO>(false, "Data telah divoid!", null);
                            saveHeader = false;
                        }
                        else
                        {
                            data.IDUserEdit = Constant.UserLogin.ID;
                            data.TglEdit = DateTime.Now;

                            context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<Model.ViewModel.DO, TDO>(data));
                            saveHeader = true;
                        }
                    }
                    else
                    {
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;

                        string docNo = $"SJ/{data.DocDate.ToString("yyMM")}/";
                        if (context.TDOs.Where(o => o.DocNo.Substring(0, docNo.Length).Equals(docNo)).Count() >= 1)
                        {
                            int maxCode = context.TDOs.Where(o => o.DocNo.Substring(0, docNo.Length).Equals(docNo))
                                            .Max(o => o.DocNo.Substring(docNo.Length))
                                            .Select(o => int.Parse(o.ToString()))
                                            .Max();
                            data.DocNo = $"{docNo}{(maxCode + 1).ToString().PadLeft(5, '0')}";
                        }
                        else
                        {
                            data.DocNo = $"{docNo}{1.ToString().PadLeft(5, '0')}";
                        }

                        context.TDOs.Add(Constant.mapper.Map<Model.ViewModel.DO, TDO>(data));
                        saveHeader = true;
                    }

                    if (saveHeader)
                    {
                        //Remove Kartu Stok
                        context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokManifest));
                        //Remove Detail
                        context.TDODtls.RemoveRange(context.TDODtls.Where(o => o.IDDO == data.ID));

                        foreach (var item in data.DODtl.OrderBy(o => o.NoUrut))
                        {
                            TDODtl detil = Constant.mapper.Map<Model.ViewModel.DODtl, TDODtl>(item);
                            //Insert Detail
                            context.TDODtls.Add(detil);

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
                                IDType = Constant.stokManifest,
                                IDUOM = detil.IDUOM,
                                IDUserEdit = data.IDUserEdit,
                                IDUserEntri = data.IDUserEntri,
                                IDUserHapus = data.IDUserHapus,
                                IDWarehouse = data.IDWarehouse,
                                PIC = "",
                                QtyKeluar = (float)detil.Qty,
                                QtyMasuk = 0f,
                                Row = "",
                                Tanggal = data.DocDate,
                                TglEdit = data.TglEdit,
                                TglEntri = data.TglEntri,
                                TglHapus = data.TglHapus
                            };
                            context.TStockCards.Add(kartu);
                        }

                        context.SaveChanges();
                        hasil = new Tuple<bool, string, DO>(true, "", data);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getDOs", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, string, DataSet> getPrintData(DO data)
        {
            DataSet dataSet = new DataSet();
            Tuple<bool, string, DataSet> hasil = new Tuple<bool, string, DataSet>(false, "", null);
            using (SqlConnection cn = new SqlConnection(Constant.appSetting.KoneksiString))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    using (SqlDataAdapter oDA = new SqlDataAdapter())
                    {
                        try
                        {
                            cn.Open();
                            com.Connection = cn;
                            com.CommandTimeout = cn.ConnectionTimeout;
                            oDA.SelectCommand = com;

                            string query = "";
                            if (System.IO.File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "Report", "Script", "FakturPengirimanBarang.sql")))
                            {
                                query = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "Report", "Script", "FakturPengirimanBarang.sql"));
                            }
                            else
                            {
                                query = @"SELECT TDO.*,
                                            TWarehouse.Code CodeGudang,
                                            TWarehouse.[Name] Gudang,
                                            TContact.Code CodeCustomer,
                                            TContact.[Name] Customer,
                                            TContact.[Address] AddressCustomer,
                                            UserEntri.Nama UserEntri,
                                            UserEdit.Nama UserEdit,
                                            UserHapus.Nama UserHapus
                                            FROM TDO(NOLOCK)
                                            LEFT JOIN TWarehouse(NOLOCK) ON TDO.IDWarehouse = TWarehouse.ID
                                            LEFT JOIN TContact(NOLOCK) ON TDO.IDCustomer = TContact.ID
                                            LEFT JOIN TUser(NOLOCK) UserEntri ON TDO.IDUserEntri = UserEntri.ID
                                            LEFT JOIN TUser(NOLOCK) UserEdit ON TDO.IDUserEdit = UserEdit.ID
                                            LEFT JOIN TUser(NOLOCK) UserHapus ON TDO.IDUserHapus = UserHapus.ID
                                            WHERE TDO.ID=@ID
                                            ORDER BY TDO.ID;
                                          SELECT TDODtl.*,
                                            TInventor.PLU,
                                            TInventor.[Desc],
                                            TUOM.Satuan
                                            FROM TDODtl(NOLOCK)
                                            LEFT JOIN TInventor(NOLOCK) ON TDODtl.IDInventor = TInventor.ID
                                            LEFT JOIN TUOM(NOLOCK) ON TDODtl.IDUOM = TUOM.ID
                                            WHERE TDODtl.IDDO=@ID
                                            ORDER BY TDODtl.NoUrut;";
                                System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "Report", "Script", "FakturPengirimanBarang.sql"), query);
                            }
                            com.CommandText = query;
                            com.Parameters.Clear();
                            com.Parameters.AddWithValue("@ID", data.ID);
                            oDA.Fill(dataSet);

                            dataSet.Tables[0].TableName = "TDO";
                            dataSet.Tables[1].TableName = "TDODtl";
                            dataSet.Relations.Add(new DataRelation("IX_DODtl", dataSet.Tables[0].Columns["ID"], dataSet.Tables[1].Columns["IDDO"]));
                            hasil = new Tuple<bool, string, DataSet>(true, "Success", dataSet);
                        }
                        catch (Exception ex)
                        {
                            hasil = new Tuple<bool, string, DataSet>(false, ex.Message, null);
                        }
                    }
                }
            }
            return hasil;
        }

        public static Tuple<bool, string, DO> deleteDOs(DO data)
        {
            bool saveHeader = false;
            Tuple<bool, string, DO> hasil = new Tuple<bool, string, DO>(false, "", null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    int iLoc = 0;
                    //Kosongi dulu Detailnya
                    foreach (var item in data.DODtl.OrderBy(o => o.NoUrut))
                    {
                        iLoc++;
                        item.ID = (item.ID == Guid.Empty ? Guid.NewGuid() : item.ID);
                        item.IDDO = data.ID;
                        item.NoUrut = iLoc;
                    }

                    var dataExist = context.TDOs.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        if (dataExist.Void)
                        {
                            hasil = new Tuple<bool, string, DO>(false, "Data telah divoid!", null);
                            saveHeader = false;
                        }
                        else
                        {
                            iLoc = 0;
                            foreach (var item in data.DODtl.OrderBy(o => o.NoUrut))
                            {
                                iLoc++;
                                item.QtyVoid = item.Qty;
                                item.Qty = 0;
                            }
                            data.Void = true;

                            data.IDUserHapus = Constant.UserLogin.ID;
                            data.TglHapus = DateTime.Now;

                            context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<Model.ViewModel.DO, TDO>(data));
                            saveHeader = true;
                        }
                    }
                    else
                    {
                        hasil = new Tuple<bool, string, DO>(false, "Data tidak ditemukan!", data);
                        saveHeader = false;
                    }

                    if (saveHeader)
                    {
                        //Remove Kartu Stok
                        context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokManifest));
                        //Remove Detail
                        context.TDODtls.RemoveRange(context.TDODtls.Where(o => o.IDDO == data.ID));

                        foreach (var item in data.DODtl.OrderBy(o => o.NoUrut))
                        {
                            TDODtl detil = Constant.mapper.Map<Model.ViewModel.DODtl, TDODtl>(item);
                            //Insert Detail
                            context.TDODtls.Add(detil);
                        }

                        context.SaveChanges();
                        hasil = new Tuple<bool, string, DO>(true, "", data);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getDOs", ex);
                }
            }
            return hasil;
        }
    }
}
