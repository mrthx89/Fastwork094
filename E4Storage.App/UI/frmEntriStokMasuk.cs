﻿using DevExpress.XtraEditors;
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
    public partial class frmEntriStokMasuk : DevExpress.XtraEditors.XtraForm
    {
        public Model.ViewModel.StokMasuk data { get; set; }
        public frmEntriStokMasuk(Model.ViewModel.StokMasuk data)
        {
            InitializeComponent();

            this.data = data;
        }

        private void frmEntriStokMasuk_Load(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, dataLayoutControl1);
            if (data == null)
            {
                data = new Model.ViewModel.StokMasuk()
                {
                    ID = Guid.NewGuid(),
                    IDInventor = Guid.Empty,
                    IDUOM = Guid.Empty,
                    IDUserEdit = Guid.Empty,
                    IDUserEntri = Constant.UserLogin.ID,
                    IDUserHapus = Guid.Empty,
                    Keterangan = "",
                    NamaBarang = "",
                    DocNo = "",
                    NoSJ = "",
                    Qty = 0,
                    Supplier = "",
                    Tanggal = DateTime.Now,
                    TglEdit = DateTime.Parse("1900-01-01"),
                    TglEntri = DateTime.Parse("1900-01-01"),
                    TglHapus = DateTime.Parse("1900-01-01"),
                    Cabinet = 0,
                    IDBelt = Guid.Empty,
                    IDCategory = Guid.Empty,
                    PIC = "",
                    Row = ""
                };
            }
            refreshLookUp();
            stokMasukBindingSource.DataSource = data;
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
                    if (data.IDInventor == Guid.Empty || string.IsNullOrEmpty(data.NamaBarang))
                    {
                        dxErrorProvider1.SetError(IDInventorSearchLookUpEdit, "Kode Barang harus diisi!");
                    }

                    if (data.Qty <= 0)
                    {
                        dxErrorProvider1.SetError(QtyCalcEdit, "Qty harus diisi dengan benar!");
                    }
                    if (data.IDInventor == Guid.Empty || string.IsNullOrEmpty(data.NamaBarang))
                    {
                        dxErrorProvider1.SetError(IDInventorSearchLookUpEdit, "Kode Barang harus diisi!");
                    }

                    if (data.IDBelt == Guid.Empty || string.IsNullOrEmpty(IDBeltSearchLookUpEdit.Text))
                    {
                        dxErrorProvider1.SetError(IDBeltSearchLookUpEdit, "Belt harus diisi!");
                    }

                    if (data.IDCategory == Guid.Empty || string.IsNullOrEmpty(IDCategorySearchLookUpEdit.Text))
                    {
                        dxErrorProvider1.SetError(IDCategorySearchLookUpEdit, "Category harus diisi!");
                    }

                    if (!dxErrorProvider1.HasErrors)
                    {
                        var save = Repository.StokMasuk.saveStokMasuk(data);
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

        private void IDInventorSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Guid.TryParse(IDInventorSearchLookUpEdit.EditValue.ToString(), out Guid IDInventor);
                var item = itemLookUps.FirstOrDefault(o => o.ID == IDInventor);
                if (item != null)
                {
                    data.IDUOM = item.IDUOM;
                    data.NamaBarang = item.Desc;
                    IDUOMSearchLookUpEdit.EditValue = item.IDUOM;
                    NamaBarangTextEdit.EditValue = item.Desc;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.IDInventorSearchLookUpEdit_EditValueChanged", ex);
            }
        }

        private List<ItemLookUp> itemLookUps = new List<ItemLookUp>();
        private void refreshLookUp()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang mengambil data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();

                    var callItems = Repository.Item.getLookUpInventors(data.Tanggal, Guid.Empty, null);
                    if (callItems.Item1)
                    {
                        itemLookUps = callItems.Item2;
                    }
                    else
                    {
                        itemLookUps = new List<ItemLookUp>();
                    }
                    IDInventorSearchLookUpEdit.Properties.DataSource = itemLookUps;
                    IDInventorSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDInventorSearchLookUpEdit.Properties.DisplayMember = "PLU";

                    var call = Repository.Item.getUOMs();
                    if (call.Item1)
                    {
                        IDUOMSearchLookUpEdit.Properties.DataSource = (from x in call.Item2
                                                                       select new { x.ID, x.Satuan }).ToList();
                    }
                    else
                    {
                        IDUOMSearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDUOMSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUOMSearchLookUpEdit.Properties.DisplayMember = "Satuan";

                    var callUser = Repository.User.getLookUp();
                    if (callUser.Item1)
                    {
                        IDUserEditSearchLookUpEdit.Properties.DataSource = callUser.Item2;
                        IDUserEntriSearchLookUpEdit.Properties.DataSource = callUser.Item2;
                    }
                    else
                    {
                        IDUserEditSearchLookUpEdit.Properties.DataSource = null;
                        IDUserEntriSearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDUserEntriSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserEntriSearchLookUpEdit.Properties.DisplayMember = "Nama";
                    IDUserEditSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserEditSearchLookUpEdit.Properties.DisplayMember = "Nama";

                    var callBelt = Repository.Item.getBelts();
                    if (callBelt.Item1)
                    {
                        IDBeltSearchLookUpEdit.Properties.DataSource = (from x in callBelt.Item2
                                                                        select new { x.ID, x.Belt }).ToList();
                    }
                    else
                    {
                        IDBeltSearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDBeltSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDBeltSearchLookUpEdit.Properties.DisplayMember = "Belt";

                    var callCategories = Repository.Item.getCategories();
                    if (callCategories.Item1)
                    {
                        IDCategorySearchLookUpEdit.Properties.DataSource = (from x in callCategories.Item2
                                                                            select new { x.ID, x.Category }).ToList();
                    }
                    else
                    {
                        IDCategorySearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDCategorySearchLookUpEdit.Properties.ValueMember = "ID";
                    IDCategorySearchLookUpEdit.Properties.DisplayMember = "Category";

                    IDInventorSearchLookUpEdit.Properties.Buttons[1].Visible = Utils.Constant.UserLogin.IsAdmin;
                    IDBeltSearchLookUpEdit.Properties.Buttons[1].Visible = Utils.Constant.UserLogin.IsAdmin;
                    IDCategorySearchLookUpEdit.Properties.Buttons[1].Visible = Utils.Constant.UserLogin.IsAdmin;
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshLookUp", ex);
                }
            }
        }

        private void frmEntriStokMasuk_FOrmClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, searchLookUpEdit1View);
            Constant.layoutsHelper.SaveLayouts(this.Name, dataLayoutControl1);
            Constant.layoutsHelper.SaveLayouts(this.Name, gvBelt);
            Constant.layoutsHelper.SaveLayouts(this.Name, gvCategory);
        }

        private void gv1_DataSourceChanged(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, (DevExpress.XtraGrid.Views.Grid.GridView)sender);
        }

        private void IDInventorSearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmDaftarMasterItem frm = new frmDaftarMasterItem())
                {
                    try
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);
                        refreshLookUp();
                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.MsgError($"{this.Name}.IDInventorSearchLookUpEdit_ButtonClick", ex);
                    }
                }
            }
        }

        private void IDBeltSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void IDBeltSearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmDaftarBelt frm = new frmDaftarBelt())
                {
                    try
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);
                        refreshLookUp();
                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.MsgError($"{this.Name}.IDBeltSearchLookUpEdit_ButtonClick", ex);
                    }
                }
            }
        }

        private void IDCategorySearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void IDCategorySearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmDaftarCategory frm = new frmDaftarCategory())
                {
                    try
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);
                        refreshLookUp();
                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.MsgError($"{this.Name}.IDCategorySearchLookUpEdit_ButtonClick", ex);
                    }
                }
            }
        }
    }
}