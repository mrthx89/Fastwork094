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
    public partial class frmDaftarPembelian : DevExpress.XtraEditors.XtraForm
    {
        public frmDaftarPembelian()
        {
            InitializeComponent();
        }

        private void mnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshData();
        }

        private void frmDaftarPembelian_Load(object sender, EventArgs e)
        {
            this.dateEdit1.DateTime = DateTime.Now.Date.AddDays(-30);
            this.dateEdit2.DateTime = DateTime.Now.Date;
            mnRefresh.PerformClick();
        }

        private void frmDaftarPembelian_FormCLossing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
        }

        private void mnBaru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addOrEdit(null);
        }

        private void mnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var item = (ItemMaster)purchaseBindingSource.Current;
                if (item != null)
                {
                    addOrEdit(item);
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
            }
        }

        private void addOrEdit(ItemMaster data)
        {
            using (frmEntriItem frm = new frmEntriItem(data))
            {
                try
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        mnRefresh.PerformClick();

                        gridView1.ClearSelection();
                        gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, frm.data.ID.ToString());
                        gridView1.SelectRow(gridView1.FocusedRowHandle);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnBaru_ItemClick", ex);
                }
            }
        }

        private void mnHapus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var item = (ItemMaster)purchaseBindingSource.Current;
                if (item != null)
                {
                    if (MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnHapus_ItemClick", $"Yakin ingin menghapus item {item.Desc} ini?") == DialogResult.Yes)
                    {
                        var delete = Repository.Item.deleteInventor(item.ID);
                        if (delete.Item1)
                        {
                            mnRefresh.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.refreshData", ex);
            }
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, gridView1);
        }

        private List<ItemMaster> data = new List<ItemMaster>();
        private void refreshData()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang merefresh data"))
            {
                try
                {
                    var callGudang = Repository.Warehouse.getLookUpWarehouses(null);
                    repositoryItemGudang.DataSource = (callGudang.Item1 ? callGudang.Item2 : new List<WarehouseLookUp>());
                    repositoryItemGudang.ValueMember = "ID";
                    repositoryItemGudang.DisplayMember = "Code";

                    var callSupplier = Repository.Vendor.getLookUpVendors(null);
                    repositoryItemSupplier.DataSource = (from x in (callSupplier.Item1 ? callSupplier.Item2 : new List<VendorLookUp>())
                                                         select new { x.ID, Supplier = x.Code + " - " + x.Name }).ToList();
                    repositoryItemSupplier.ValueMember = "ID";
                    repositoryItemSupplier.DisplayMember = "Supplier";

                    var callUser = Repository.User.getLookUp();
                    repositoryItemUser.DataSource = (callUser.Item1 ? callUser.Item2 : null);
                    repositoryItemUser.ValueMember = "ID";
                    repositoryItemUser.DisplayMember = "Nama";

                    var call = Repository.Item.getInventors(null, null);
                    if (call.Item1)
                    {
                        data = call.Item2;
                    }
                    purchaseBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshData", ex);
                }
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            // Access the underlying data object for the current row
            Purchase rowData = gridView1.GetRow(e.RowHandle) as Purchase;
            // Check the condition based on your requirements
            if (rowData != null && rowData.Void)
            {
                // Set the appearance for the current row
                e.Appearance.ForeColor = Color.Gray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);
                e.Appearance.Options.UseFont = true;
            }
        }
    }
}