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
    public partial class frmDaftarPengirimanBarang : DevExpress.XtraEditors.XtraForm
    {
        public frmDaftarPengirimanBarang()
        {
            InitializeComponent();
        }

        private void mnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshData();
        }

        private void frmDaftarPengirimanBarang_Load(object sender, EventArgs e)
        {
            this.dateEdit1.DateTime = DateTime.Now.Date.AddDays(-30);
            this.dateEdit2.DateTime = DateTime.Now.Date;
            mnRefresh.PerformClick();
        }

        private void frmDaftarPengirimanBarang_FormCLossing(object sender, FormClosingEventArgs e)
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
                var item = (DO)DOBindingSource.Current;
                if (item != null)
                {
                    addOrEdit(JSONHelper.CloneObject(item));
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
            }
        }

        private void addOrEdit(DO data)
        {
            using (frmEntriPengirimanBarang frm = new frmEntriPengirimanBarang(data))
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
                var item = (DO)DOBindingSource.Current;
                if (item != null)
                {
                    if (MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnHapus_ItemClick", $"Yakin ingin menghapus PengirimanBarang {item.DocNo} ini?") == DialogResult.Yes)
                    {
                        var delete = Repository.PengirimanBarang.deleteDOs(JSONHelper.CloneObject(item));
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

        private List<DO> data = new List<DO>();
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

                    var callCustomer = Repository.Customer.getLookUpCustomers(null);
                    repositoryItemCustomer.DataSource = (from x in (callCustomer.Item1 ? callCustomer.Item2 : new List<CustomerLookUp>())
                                                         select new { x.ID, Customer = x.Code + " - " + x.Name }).ToList();
                    repositoryItemCustomer.ValueMember = "ID";
                    repositoryItemCustomer.DisplayMember = "Customer";

                    var callUser = Repository.User.getLookUp();
                    repositoryItemUser.DataSource = (callUser.Item1 ? callUser.Item2 : null);
                    repositoryItemUser.ValueMember = "ID";
                    repositoryItemUser.DisplayMember = "Nama";

                    var call = Repository.PengirimanBarang.getDOs(dateEdit1.DateTime, dateEdit2.DateTime);
                    if (call.Item1)
                    {
                        data = call.Item2;
                    }
                    DOBindingSource.DataSource = data;
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
            DO rowData = gridView1.GetRow(e.RowHandle) as DO;
            // Check the condition based on your requirements
            if (rowData != null && rowData.Void)
            {
                // Set the appearance for the current row
                e.Appearance.ForeColor = Color.Gray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);
                e.Appearance.Options.UseFont = true;
            }
        }

        private void mnCetakInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var item = (DO)DOBindingSource.Current;
                if (item != null)
                {
                    printData(JSONHelper.CloneObject<DO>(item));
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
            }
        }

        private void printData(DO data)
        {
            var print = Repository.PengirimanBarang.getPrintData(data);
            if (print.Item1)
            {
                ReportHelper.ReportHandler(Utils.Constant.EditReport ? ReportHelper.StatusCetak.Edit : ReportHelper.StatusCetak.Preview, 
                    print.Item3, 
                    "FakturPengirimanBarang.repx", 
                    "Cetak Faktur PengirimanBarang", 
                    new List<ReportHelper.Parameter>());
            }
            else
            {
                MsgBoxHelper.MsgInfo($"{this.Name}.printData", print.Item2);
            }
        }
    }
}