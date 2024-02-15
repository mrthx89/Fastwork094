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
    public class Customer
    {
        private static string Name = "Repository.Customer";

        public static Tuple<bool, CustomerMaster> getCustomer(Guid ID)
        {
            Tuple<bool, CustomerMaster> hasil = new Tuple<bool, CustomerMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TContacts.FirstOrDefault(o => o.ID == ID);
                    if (data != null)
                    {
                        var Customer = Constant.mapper.Map<CustomerMaster>(data);

                        hasil = new Tuple<bool, CustomerMaster>(true, Customer);
                    }
                    else
                    {
                        hasil = new Tuple<bool, CustomerMaster>(false, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getCustomer", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<CustomerMaster>> getCustomer(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<CustomerMaster>> hasil = new Tuple<bool, List<CustomerMaster>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TContacts.Where(o => o.Customer).AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var Customer in filter)
                        {
                            if (Customer.Key.Equals("Code"))
                            {
                                string a = (string)Customer.Value;
                                data = data.Where(o => o.Code.Contains(a));
                            }
                            else if (Customer.Key.Equals("Name"))
                            {
                                string a = (string)Customer.Value;
                                data = data.Where(o => o.Name.Contains(a));
                            }
                            else if (Customer.Key.Equals("Address"))
                            {
                                string a = (string)Customer.Value;
                                data = data.Where(o => o.Address.Contains(a));
                            }
                        }
                    }
                    var datas = (from Customer in data
                                 select new CustomerMaster
                                 {
                                     ID = Customer.ID,
                                     Code = Customer.Code,
                                     Name = Customer.Name,
                                     IDUserEdit = Customer.IDUserEdit,
                                     IDUserEntri = Customer.IDUserEntri,
                                     IDUserHapus = Customer.IDUserHapus,
                                     Address = Customer.Address,
                                     Active = Customer.Active,
                                     TglEdit = Customer.TglEdit,
                                     TglEntri = Customer.TglEntri,
                                     TglHapus = Customer.TglHapus,
                                     Cell = Customer.Cell,
                                     ContactPerson = Customer.ContactPerson,
                                     Email = Customer.Email,
                                     Phone = Customer.Phone,
                                     NPWP = Customer.NPWP
                                 }).ToList();
                    hasil = new Tuple<bool, List<CustomerMaster>>(true, datas);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getCustomer", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<CustomerLookUp>> getLookUpCustomers(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<CustomerLookUp>> hasil = new Tuple<bool, List<CustomerLookUp>>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var data = context.TContacts.Where(o => o.Active && o.Customer).AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var Customer in filter)
                        {
                            if (Customer.Key.Equals("Code"))
                            {
                                string a = (string)Customer.Value;
                                data = data.Where(o => o.Code.Contains(a));
                            }
                            else if (Customer.Key.Equals("Name"))
                            {
                                string a = (string)Customer.Value;
                                data = data.Where(o => o.Name.Contains(a));
                            }
                            else if (Customer.Key.Equals("Address"))
                            {
                                string a = (string)Customer.Value;
                                data = data.Where(o => o.Address.Contains(a));
                            }
                        }
                    }
                    var Customers = (from Customer in data
                                   select new CustomerLookUp
                                   {
                                       ID = Customer.ID,
                                       Code = Customer.Code,
                                       Address = Customer.Address,
                                       Name = Customer.Name
                                   }).ToList();
                    hasil = new Tuple<bool, List<CustomerLookUp>>(true, Customers);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getLookUpCustomers", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, CustomerMaster> deleteCustomer(Guid ID)
        {
            Tuple<bool, CustomerMaster> hasil = new Tuple<bool, CustomerMaster>(false, null);
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

                        hasil = new Tuple<bool, CustomerMaster>(true, Constant.mapper.Map<TContact, CustomerMaster>(data));
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{Name}.deleteCustomer", "Data Customer tidak dCustomerukan!");
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.deleteCustomer", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, CustomerMaster> saveInventor(CustomerMaster data)
        {
            Tuple<bool, CustomerMaster> hasil = new Tuple<bool, CustomerMaster>(false, null);
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
                        var Customer = Constant.mapper.Map<CustomerMaster, TContact>(data);
                        Customer.Customer = true;
                        context.Entry(dataExist).CurrentValues.SetValues(Customer);
                    }
                    else
                    {
                        //Baru
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;
                        data.Active = true;

                        if (string.IsNullOrEmpty(data.Code) || string.IsNullOrWhiteSpace(data.Code))
                        {
                            if (context.TContacts.Where(o => o.Customer).Count() >= 1)
                            {
                                int maxCode = context.TContacts
                                                .Where(o => o.Customer)
                                                .Max(o => o.Code.Substring(4))
                                                .Select(o => int.Parse(o.ToString()))
                                                .Max();
                                data.Code = $"CUS-{(maxCode + 1).ToString().PadLeft(5, '0')}";
                            }
                            else
                            {
                                data.Code = $"CUS-{1.ToString().PadLeft(5, '0')}";
                            }
                        }
                        var Customer = Constant.mapper.Map<CustomerMaster, TContact>(data);
                        Customer.Customer = true;
                        context.TContacts.Add(Customer);
                    }

                    hasil = new Tuple<bool, CustomerMaster>(true, data);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveInventor", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, CustomerMaster> checkNamaExistsCustomer(CustomerMaster data)
        {
            Tuple<bool, CustomerMaster> hasil = new Tuple<bool, CustomerMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Customer && o.Name.Equals(data.Name) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, CustomerMaster>(false, Constant.mapper.Map<TContact, CustomerMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, CustomerMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkNamaExistsCustomer", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, CustomerMaster> checkEmailExistsCustomer(CustomerMaster data)
        {
            Tuple<bool, CustomerMaster> hasil = new Tuple<bool, CustomerMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Customer && data.Email != null && data.Email.Length >= 1 && o.Email.Equals(data.Email) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, CustomerMaster>(false, Constant.mapper.Map<TContact, CustomerMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, CustomerMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkEmailExistsCustomer", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, CustomerMaster> checkPhoneExistsCustomer(CustomerMaster data)
        {
            Tuple<bool, CustomerMaster> hasil = new Tuple<bool, CustomerMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Customer && data.Phone != null && data.Phone.Length >= 1 && o.Phone.Equals(data.Phone) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, CustomerMaster>(false, Constant.mapper.Map<TContact, CustomerMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, CustomerMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkPhoneExistsCustomer", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, CustomerMaster> checkCellExistsCustomer(CustomerMaster data)
        {
            Tuple<bool, CustomerMaster> hasil = new Tuple<bool, CustomerMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Customer && data.Cell != null && data.Cell.Length >= 1 && o.Cell.Equals(data.Cell) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, CustomerMaster>(false, Constant.mapper.Map<TContact, CustomerMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, CustomerMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkCellExistsCustomer", ex);
                }
            }
            return hasil;
        }
        public static Tuple<bool, CustomerMaster> checkCodeExistsCustomer(CustomerMaster data)
        {
            Tuple<bool, CustomerMaster> hasil = new Tuple<bool, CustomerMaster>(false, null);
            using (Data.InventoryContext context = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TContacts.FirstOrDefault(o => o.Customer && data.Code != null && data.Code.Length >= 1 && o.Code.Equals(data.Code) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, CustomerMaster>(false, Constant.mapper.Map<TContact, CustomerMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, CustomerMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.checkCodeExistsCustomer", ex);
                }
            }
            return hasil;
        }
    }
}
