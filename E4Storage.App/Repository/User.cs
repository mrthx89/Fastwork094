﻿using Inventory.App.Model.Entity;
using Inventory.App.Utils;
using Inventory.App.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Repository
{
    public class User
    {
        public static Tuple<bool, TUser> getLogin(string UserID, string Pwd)
        {
            Tuple<bool, TUser> hasil = new Tuple<bool, TUser>(false, null);
            using (Data.InventoryContext InventoryContext = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var user = InventoryContext.TUsers.FirstOrDefault(o => o.UserID.Equals(UserID));
                    if (user != null && user.Password.Equals(Utils.GetHash(Pwd)))
                    {
                        hasil = new Tuple<bool, TUser>(true, user);
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn("User.getLogin", "User yang anda masukkan salah!");
                        hasil = new Tuple<bool, TUser>(false, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError("User.getLogin", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<TUser>> getUsers()
        {
            Tuple<bool, List<TUser>> hasil = new Tuple<bool, List<TUser>>(false, null);
            using (Data.InventoryContext InventoryContext = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var user = InventoryContext.TUsers.ToList();
                    hasil = new Tuple<bool, List<TUser>>(true, user);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError("User.getUsers", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, dynamic> getLookUp()
        {
            Tuple<bool, dynamic> hasil = new Tuple<bool, dynamic>(false, null);
            using (Data.InventoryContext InventoryContext = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var user = (from x in InventoryContext.TUsers
                                select new { x.ID, x.Nama, x.UserID }).ToList();
                    hasil = new Tuple<bool, dynamic>(true, user);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError("User.getLookUp", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<TUser>> saveUsers(List<TUser> users)
        {
            Tuple<bool, List<TUser>> hasil = new Tuple<bool, List<TUser>>(false, null);
            using (Data.InventoryContext dbContext = new Data.InventoryContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var userExists = dbContext.TUsers.ToList();
                    foreach (var item in userExists)
                    {
                        if (users.FirstOrDefault(o => o.ID == item.ID) == null)
                        {
                            dbContext.TUsers.Remove(item);
                        }
                    }

                    foreach (var item in users)
                    {
                        var existingItem = dbContext.TUsers.FirstOrDefault(i => i.ID == item.ID);
                        if (existingItem != null)
                        {
                            item.IDUserEdit = Constant.UserLogin.ID;
                            item.TglEdit = DateTime.Now;
                            dbContext.Entry(existingItem).CurrentValues.SetValues(item);
                        }
                        else
                        {
                            item.IDUserEntri = Constant.UserLogin.ID;
                            item.TglEntri = DateTime.Now;
                            item.IDUserEdit = Guid.Empty;
                            item.TglEdit = null;
                            dbContext.TUsers.Add(item);
                        }
                    }

                    dbContext.SaveChanges();

                    hasil = new Tuple<bool, List<TUser>>(true, dbContext.TUsers.ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError("User.saveUsers", ex);
                }
            }
            return hasil;
        }
    }
}
