using DevExpress.XtraEditors;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory.App.Helper;
using Inventory.App.Utils;
using Inventory.App.Repository;
using Inventory.App.Model.ViewModel;
using Inventory.App.Model.Entity;

namespace Inventory.App.UI
{
    public partial class frmEntriVendor : DevExpress.XtraEditors.XtraForm
    {
        public VendorMaster data;
        public frmEntriVendor(VendorMaster data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void frmEntriVendor_Load(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, dataLayoutControl1);
            refreshLookUp();
            if (data == null)
            {
                //Create Baru
                data = new VendorMaster
                {
                    ID = Guid.NewGuid(),
                    Code = "",
                    Name = "",
                    Active = true,
                    IDUserEdit = Guid.Empty,
                    IDUserEntri = Constant.UserLogin.ID,
                    IDUserHapus = Guid.Empty,
                    Address = "",
                    TglEdit = DateTime.Parse("1900-01-01"),
                    TglEntri = DateTime.Now,
                    TglHapus = DateTime.Parse("1900-01-01"),
                    Cell = "",
                    ContactPerson = "",
                    Email = "",
                    Phone = ""
                };
            }
            vendorMasterBindingSource.DataSource = data;
            dataLayoutControl1.Refresh();
        }

        private void mnSimpan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang menyimpan data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();

                    dataLayoutControl1.Validate();
                    this.Validate();

                    dxErrorProvider1.ClearErrors();
                    var check1 = Repository.Vendor.checkCodeExistsVendor(data);
                    if (!check1.Item1)
                    {
                        dxErrorProvider1.SetError(CodeTextEdit, "Kode Supplier ini sudah dipakai!");
                    }
                    check1 = Repository.Vendor.checkNamaExistsVendor(data);
                    if (!check1.Item1)
                    {
                        dxErrorProvider1.SetError(NameTextEdit, "Nama Supplier ini sudah dipakai!");
                    }
                    check1 = Repository.Vendor.checkEmailExistsVendor(data);
                    if (!check1.Item1)
                    {
                        dxErrorProvider1.SetError(EmailTextEdit, "Email Supplier ini sudah dipakai!");
                    }
                    check1 = Repository.Vendor.checkCellExistsVendor(data);
                    if (!check1.Item1)
                    {
                        dxErrorProvider1.SetError(CellTextEdit, "HP Supplier ini sudah dipakai!");
                    }
                    check1 = Repository.Vendor.checkPhoneExistsVendor(data);
                    if (!check1.Item1)
                    {
                        dxErrorProvider1.SetError(PhoneTextEdit, "Telp Supplier ini sudah dipakai!");
                    }

                    if (!dxErrorProvider1.HasErrors)
                    {
                        var save = Repository.Vendor.saveInventor(data);
                        if (save.Item1)
                        {
                            this.data = save.Item2;
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{this.Name}.mnSimpan_ItemClick", string.Join(", ", (from x in dxErrorProvider1.GetControlsWithError()
                                                                                                   select new { errMsg = dxErrorProvider1.GetError(x) }).Select(o => o.errMsg).ToList()));
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnSimpan_ItemClick", ex);
                }
            }
        }

        private void frmEntriVendor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, dataLayoutControl1);
        }

        private void refreshLookUp()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang mengambil data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();

                    var callUser = Repository.User.getLookUp();
                    if (callUser.Item1)
                    {
                        IDUserEditSearchLookUpEdit.Properties.DataSource = callUser.Item2;
                        IDUserEntriSearchLookUpEdit.Properties.DataSource = callUser.Item2;
                        IDUserHapusSearchLookUpEdit.Properties.DataSource = callUser.Item2;
                    }
                    else
                    {
                        IDUserEditSearchLookUpEdit.Properties.DataSource = null;
                        IDUserEntriSearchLookUpEdit.Properties.DataSource = null;
                        IDUserHapusSearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDUserEntriSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserEntriSearchLookUpEdit.Properties.DisplayMember = "Nama";
                    IDUserEditSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserEditSearchLookUpEdit.Properties.DisplayMember = "Nama";
                    IDUserHapusSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserHapusSearchLookUpEdit.Properties.DisplayMember = "Nama";
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshLookUp", ex);
                }
            }
        }
    }
}