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
    public partial class frmDaftarMasterCustomer : DevExpress.XtraEditors.XtraForm
    {
        public frmDaftarMasterCustomer()
        {
            InitializeComponent();
        }

        private void mnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshData();
        }

        private void frmDaftarMasterCustomer_Load(object sender, EventArgs e)
        {
            mnRefresh.PerformClick();
        }

        private void frmDaftarMasterCustomer_FormCLossing(object sender, FormClosingEventArgs e)
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
                var item = (CustomerMaster)tCustomerBindingSource.Current;
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

        private void addOrEdit(CustomerMaster data)
        {
            using (frmEntriCustomer frm = new frmEntriCustomer(data))
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
                var item = (CustomerMaster)tCustomerBindingSource.Current;
                if (item != null)
                {
                    if (MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnHapus_ItemClick", $"Yakin ingin menghapus customer {item.Name} ini?") == DialogResult.Yes)
                    {
                        var delete = Repository.Customer.deleteCustomer(item.ID);
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

        private List<CustomerMaster> data = new List<CustomerMaster>();
        private void refreshData()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang merefresh data"))
            {
                try
                {
                    var callUser = Repository.User.getLookUp();
                    repositoryItemUser.DataSource = (callUser.Item1 ? callUser.Item2 : null);
                    repositoryItemUser.ValueMember = "ID";
                    repositoryItemUser.DisplayMember = "Nama";

                    var call = Repository.Customer.getCustomer(null);
                    if (call.Item1)
                    {
                        data = call.Item2;
                    }
                    tCustomerBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshData", ex);
                }
            }
        }
    }
}