using Inventory.App.Helper;
using Inventory.App.Model.Entity;
using Inventory.App.Model.ViewModel;
using Inventory.App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Repository
{
    public class Vendor
    {
        private static string Name = "Repository.Vendor";

        public static Tuple<bool, VendorMaster> getVendor(Guid ID)
        {
            Tuple<bool, VendorMaster> hasil = new Tuple<bool, VendorMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TContacts.FirstOrDefault(o => o.ID == ID);
                    if (data != null)
                    {
                        var Vendor = Constant.mapper.Map<VendorMaster>(data);

                        hasil = new Tuple<bool, VendorMaster>(true, Vendor);
                    }
                    else
                    {
                        hasil = new Tuple<bool, VendorMaster>(false, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getVendor", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<VendorMaster>> getVendor(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<VendorMaster>> hasil = new Tuple<bool, List<VendorMaster>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TContacts.Where(o => o.Vendor).AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var Vendor in filter)
                        {
                            if (Vendor.Key.Equals("Code"))
                            {
                                string a = (string)Vendor.Value;
                                data = data.Where(o => o.Code.Contains(a));
                            }
                            else if (Vendor.Key.Equals("Name"))
                            {
                                string a = (string)Vendor.Value;
                                data = data.Where(o => o.Name.Contains(a));
                            }
                            else if (Vendor.Key.Equals("Address"))
                            {
                                string a = (string)Vendor.Value;
                                data = data.Where(o => o.Address.Contains(a));
                            }
                        }
                    }
                    var datas = (from Vendor in data
                                 select new VendorMaster
                                 {
                                     ID = Vendor.ID,
                                     Code = Vendor.Code,
                                     Name = Vendor.Name,
                                     IDUserEdit = Vendor.IDUserEdit,
                                     IDUserEntri = Vendor.IDUserEntri,
                                     IDUserHapus = Vendor.IDUserHapus,
                                     Address = Vendor.Address,
                                     Active = Vendor.Active,
                                     TglEdit = Vendor.TglEdit,
                                     TglEntri = Vendor.TglEntri,
                                     TglHapus = Vendor.TglHapus,
                                     Cell = Vendor.Cell,
                                     ContactPerson = Vendor.ContactPerson,
                                     Email = Vendor.Email,
                                     Phone = Vendor.Phone
                                 }).ToList();
                    hasil = new Tuple<bool, List<VendorMaster>>(true, datas);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getVendor", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<VendorLookUp>> getLookUpVendors(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<VendorLookUp>> hasil = new Tuple<bool, List<VendorLookUp>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TContacts.Where(o => o.Active && o.Vendor).AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var Vendor in filter)
                        {
                            if (Vendor.Key.Equals("Code"))
                            {
                                string a = (string)Vendor.Value;
                                data = data.Where(o => o.Code.Contains(a));
                            }
                            else if (Vendor.Key.Equals("Name"))
                            {
                                string a = (string)Vendor.Value;
                                data = data.Where(o => o.Name.Contains(a));
                            }
                            else if (Vendor.Key.Equals("Address"))
                            {
                                string a = (string)Vendor.Value;
                                data = data.Where(o => o.Address.Contains(a));
                            }
                        }
                    }
                    var Vendors = (from Vendor in data
                                   select new VendorLookUp
                                   {
                                       ID = Vendor.ID,
                                       Code = Vendor.Code,
                                       Address = Vendor.Address,
                                       Name = Vendor.Name
                                   }).ToList();
                    hasil = new Tuple<bool, List<VendorLookUp>>(true, Vendors);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getLookUpVendors", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, VendorMaster> deleteVendor(Guid ID)
        {
            Tuple<bool, VendorMaster> hasil = new Tuple<bool, VendorMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TContacts.FirstOrDefault(o => o.ID == ID);
                    if (data != null)
                    {
                        data.Active = false;
                        data.TglHapus = DateTime.Now;
                        data.IDUserHapus = Constant.UserLogin.ID;
                        context.Entry(data).CurrentValues.SetValues(data);
                        context.SaveChanges();

                        hasil = new Tuple<bool, VendorMaster>(true, Constant.mapper.Map<TContact, VendorMaster>(data));
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{Name}.deleteVendor", "Data vendor tidak dVendorukan!");
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.deleteVendor", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, VendorMaster> saveInventor(VendorMaster data)
        {
            Tuple<bool, VendorMaster> hasil = new Tuple<bool, VendorMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        data.IDUserEdit = Constant.UserLogin.ID;
                        data.TglEdit = DateTime.Now;
                        if (!dataExist.Active && data.Active)
                        {
                            //Active Ulang
                            data.IDUserHapus = Guid.Empty;
                            data.TglHapus = null;
                        }
                        var vendor = Constant.mapper.Map<VendorMaster, TContact>(data);
                        vendor.Vendor = true;
                        context.Entry(dataExist).CurrentValues.SetValues(vendor);
                    }
                    else
                    {
                        //Baru
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;
                        data.Active = true;

                        if (string.IsNullOrEmpty(data.Code) || string.IsNullOrWhiteSpace(data.Code))
                        {
                            if (context.TContacts.Where(o => o.Vendor).Count() >= 1)
                            {
                                int maxCode = context.TContacts
                                                .Where(o => o.Vendor)
                                                .Max(o => o.Code.Substring(4))
                                                .Select(o => int.Parse(o.ToString()))
                                                .Max();
                                data.Code = $"SUP-{(maxCode + 1).ToString().PadLeft(5, '0')}";
                            }
                            else
                            {
                                data.Code = $"SUP-{1.ToString().PadLeft(5, '0')}";
                            }
                        }
                        var vendor = Constant.mapper.Map<VendorMaster, TContact>(data);
                        vendor.Vendor = true;
                        context.TContacts.Add(vendor);
                    }

                    hasil = new Tuple<bool, VendorMaster>(true, data);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveInventor", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, VendorMaster> checkNamaExistsVendor(VendorMaster data)
        {
            Tuple<bool, VendorMaster> hasil = new Tuple<bool, VendorMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Vendor && o.Name.Equals(data.Name) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, VendorMaster>(false, Constant.mapper.Map<TContact, VendorMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, VendorMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkNamaExistsVendor", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, VendorMaster> checkEmailExistsVendor(VendorMaster data)
        {
            Tuple<bool, VendorMaster> hasil = new Tuple<bool, VendorMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Vendor && data.Email != null && data.Email.Length >= 1 && o.Email.Equals(data.Email) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, VendorMaster>(false, Constant.mapper.Map<TContact, VendorMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, VendorMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkEmailExistsVendor", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, VendorMaster> checkPhoneExistsVendor(VendorMaster data)
        {
            Tuple<bool, VendorMaster> hasil = new Tuple<bool, VendorMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Vendor && data.Phone != null && data.Phone.Length >= 1 && o.Phone.Equals(data.Phone) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, VendorMaster>(false, Constant.mapper.Map<TContact, VendorMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, VendorMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkPhoneExistsVendor", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, VendorMaster> checkCellExistsVendor(VendorMaster data)
        {
            Tuple<bool, VendorMaster> hasil = new Tuple<bool, VendorMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Vendor && data.Cell != null && data.Cell.Length >= 1 && o.Cell.Equals(data.Cell) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, VendorMaster>(false, Constant.mapper.Map<TContact, VendorMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, VendorMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkCellExistsVendor", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, VendorMaster> checkCodeExistsVendor(VendorMaster data)
        {
            Tuple<bool, VendorMaster> hasil = new Tuple<bool, VendorMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Vendor && data.Code != null && data.Code.Length >= 1 && o.Code.Equals(data.Code) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, VendorMaster>(false, Constant.mapper.Map<TContact, VendorMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, VendorMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkCodeExistsVendor", ex);
                }
            }
            return hasil;
        }
    }
}
