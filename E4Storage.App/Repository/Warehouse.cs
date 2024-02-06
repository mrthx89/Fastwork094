using Inventory.App.Model.Entity;
using Inventory.App.Utils;
using Inventory.App.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.App.Model.ViewModel;

namespace Inventory.App.Repository
{
    public class Warehouse
    {
        private static string Name = "Repository.Warehouse";

        public static Tuple<bool, List<WarehouseMaster>> getWarehouses(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<WarehouseMaster>> hasil = new Tuple<bool, List<WarehouseMaster>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TWarehouses.AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var Warehouse in filter)
                        {
                            if (Warehouse.Key.Equals("Code"))
                            {
                                string a = (string)Warehouse.Value;
                                data = data.Where(o => o.Code.Contains(a));
                            }
                            else if (Warehouse.Key.Equals("Name"))
                            {
                                string a = (string)Warehouse.Value;
                                data = data.Where(o => o.Name.Contains(a));
                            }
                        }
                    }
                    var Warehouses = (from Warehouse in data
                                      select new WarehouseMaster
                                      {
                                         ID = Warehouse.ID,
                                         Name = Warehouse.Name,
                                         Code = Warehouse.Code,
                                         IDUserEdit = Warehouse.IDUserEdit,
                                         IDUserEntri = Warehouse.IDUserEntri,
                                         IDUserHapus = Warehouse.IDUserHapus,
                                         Active = Warehouse.Active,
                                         Address = Warehouse.Address
                                      }).ToList();
                    hasil = new Tuple<bool, List<WarehouseMaster>>(true, Warehouses);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geWarehouseMasters", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<WarehouseLookUp>> getLookUpWarehouses(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<WarehouseLookUp>> hasil = new Tuple<bool, List<WarehouseLookUp>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TWarehouses.Where(o => o.Active).AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var Warehouse in filter)
                        {
                            if (Warehouse.Key.Equals("Code"))
                            {
                                string a = (string)Warehouse.Value;
                                data = data.Where(o => o.Code.Contains(a));
                            }
                            else if (Warehouse.Key.Equals("Name"))
                            {
                                string a = (string)Warehouse.Value;
                                data = data.Where(o => o.Name.Contains(a));
                            }
                        }
                    }
                    var Warehouses = (from Warehouse in data
                                      select new WarehouseLookUp
                                      {
                                          ID = Warehouse.ID,
                                          Code = Warehouse.Code,
                                          Name = Warehouse.Name
                                      }).ToList();
                    hasil = new Tuple<bool, List<WarehouseLookUp>>(true, Warehouses);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getLookUpWarehouses", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, WarehouseMaster> getWarehouse(Guid ID)
        {
            Tuple<bool, WarehouseMaster> hasil = new Tuple<bool, WarehouseMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TWarehouses.FirstOrDefault(o => o.ID == ID);
                    if (data != null)
                    {
                        var Warehouse = Constant.mapper.Map<WarehouseMaster>(data);

                        hasil = new Tuple<bool, WarehouseMaster>(true, Warehouse);
                    }
                    else
                    {
                        hasil = new Tuple<bool, WarehouseMaster>(false, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geWarehouseMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<WarehouseMaster>> getWarehouse(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<WarehouseMaster>> hasil = new Tuple<bool, List<WarehouseMaster>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var datas = context.TWarehouses.AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var Warehouse in filter)
                        {
                            if (Warehouse.Key.Equals("Code"))
                            {
                                string a = (string)Warehouse.Value;
                                datas = datas.Where(o => o.Code.Equals(a));
                            }
                            else if (Warehouse.Key.Equals("Name"))
                            {
                                string a = (string)Warehouse.Value;
                                datas = datas.Where(o => o.Name.Equals(a));
                            }
                        }
                    }
                    
                    var Warehouses = (from Warehouse in datas
                                        select new WarehouseMaster
                                        {
                                            ID = Warehouse.ID,
                                            Name = Warehouse.Name,
                                            Code = Warehouse.Code,
                                            Active = Warehouse.Active,
                                            Address = Warehouse.Address,
                                            IDUserEdit = Warehouse.IDUserEdit,
                                            IDUserEntri = Warehouse.IDUserEntri,
                                            IDUserHapus = Warehouse.IDUserHapus,
                                            TglEdit = Warehouse.TglEdit,
                                            TglEntri = Warehouse.TglEntri,
                                            TglHapus = Warehouse.TglHapus
                                        }).ToList();
                    hasil = new Tuple<bool, List<WarehouseMaster>>(true, Warehouses);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geWarehouseMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, WarehouseMaster> deleteWarehouse(Guid ID)
        {
            Tuple<bool, WarehouseMaster> hasil = new Tuple<bool, WarehouseMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TWarehouses.FirstOrDefault(o => o.ID == ID);
                    if (data != null)
                    {                        
                        //Hapus
                        data.IDUserHapus = Constant.UserLogin.ID;
                        data.TglHapus = DateTime.Now;
                        data.Active = false;

                        context.Entry(context.TWarehouses.FirstOrDefault(o => o.ID == ID)).CurrentValues.SetValues(data);
                        hasil = new Tuple<bool, WarehouseMaster>(true, null);
                        context.SaveChanges();
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{Name}.deleteWarehouse", "Data warehouse tidak dWarehouseukan!");
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geWarehouseMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<WarehouseMaster>> saveWarehouse(List<WarehouseMaster> data)
        {
            Tuple<bool, List<WarehouseMaster>> hasil = new Tuple<bool, List<WarehouseMaster>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    foreach (var item in data)
                    {
                        var dataExist = context.TWarehouses.FirstOrDefault(o => o.ID == item.ID);
                        if (dataExist != null)
                        {
                            //Edit
                            item.IDUserEdit = Constant.UserLogin.ID;
                            item.TglEdit = DateTime.Now;

                            context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<WarehouseMaster, TWarehouse>(item));
                        }
                        else
                        {
                            //Baru
                            item.IDUserEntri = Constant.UserLogin.ID;
                            item.TglEntri = DateTime.Now;

                            context.TWarehouses.Add(Constant.mapper.Map<WarehouseMaster, TWarehouse>(item));
                        }
                    }

                    hasil = new Tuple<bool, List<WarehouseMaster>>(true, data);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geWarehouseMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, WarehouseMaster> checkCodeExistsWarehouse(WarehouseMaster data)
        {
            Tuple<bool, WarehouseMaster> hasil = new Tuple<bool, WarehouseMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TWarehouses.FirstOrDefault(o => o.Code.Equals(data.Code) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, WarehouseMaster>(false, Constant.mapper.Map<TWarehouse, WarehouseMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, WarehouseMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geWarehouseMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, WarehouseMaster> checkNamaExistsWarehouse(WarehouseMaster data)
        {
            Tuple<bool, WarehouseMaster> hasil = new Tuple<bool, WarehouseMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TWarehouses.FirstOrDefault(o => o.Name.Equals(data.Name) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, WarehouseMaster>(false, Constant.mapper.Map<TWarehouse, WarehouseMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, WarehouseMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geWarehouseMaster", ex);
                }
            }
            return hasil;
        }
    }
}
