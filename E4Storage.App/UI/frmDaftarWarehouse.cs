﻿using DevExpress.XtraEditors;
using DevExpress.Utils;
using Inventory.App.Helper;
using Inventory.App.Model.Entity;
using Inventory.App.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory.App.Model.ViewModel;

namespace Inventory.App.UI
{
    public partial class frmDaftarWarehouse : DevExpress.XtraEditors.XtraForm
    {
        public frmDaftarWarehouse()
        {
            InitializeComponent();
        }

        //private Guid notDeleted = Guid.Parse("EC82D19B-14AD-41E6-90BE-ED2B17855BF3");

        private void mnSimpan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang menyimpan data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();
                    dlg.Focus();

                    this.Validate();
                    var save = Repository.Warehouse.saveWarehouse(data);
                    if (save.Item1)
                    {
                        data = save.Item2;
                    }
                    warehouseMasterBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();

                    if (this.MdiParent == null)
                    {
                        //LookUp
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.repositoryItemPassword_ButtonClick", ex);
                }
            }
        }

        private void mnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang merefresh data ..."))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();
                    dlg.Focus();

                    var dataGet = Repository.Warehouse.getWarehouses(null);
                    if (dataGet.Item1)
                    {
                        data = dataGet.Item2;
                    }
                    warehouseMasterBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnReload_ItemClick", ex);
                }
            }
        }

        private void mnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    WarehouseMaster CurrenWarehouseMaster = (WarehouseMaster)warehouseMasterBindingSource.Current;
                    if (CurrenWarehouseMaster != null)
                    {
                        CurrenWarehouseMaster.Active = false;
                        CurrenWarehouseMaster.IDUserHapus = Utils.Constant.UserLogin.ID;
                        CurrenWarehouseMaster.TglHapus = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.repositoryItemPassword_ButtonClick", ex);
            }
        }

        private List<WarehouseMaster> data = null;
        private dynamic lookupUser = null;
        private void frmDaftarWarehouse_Load(object sender, EventArgs e)
        {
            var lookUp = Repository.User.getLookUp();
            if (lookUp.Item1)
            {
                lookupUser = lookUp.Item2;
            }
            repositoryItemUser.DataSource = lookupUser;
            repositoryItemUser.ValueMember = "ID";
            repositoryItemUser.DisplayMember = "Nama";

            mnReload.PerformClick();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridView1.SetRowCellValue(e.RowHandle, colID, Guid.NewGuid());
                gridView1.SetRowCellValue(e.RowHandle, colTglEntri, DateTime.Now);
                gridView1.SetRowCellValue(e.RowHandle, colIDUserEntri, Constant.UserLogin.ID);
                gridView1.SetRowCellValue(e.RowHandle, colCode, "");
                gridView1.SetRowCellValue(e.RowHandle, colName, "");
                gridView1.SetRowCellValue(e.RowHandle, colAddress, "");
                gridView1.SetRowCellValue(e.RowHandle, colActive, true);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.gridView1_InitNewRow", ex);
            }
        }

        private void gridView1_DataSourceChange(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, gridView1);
        }

        private void frmDaftarWarehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
        }

        private void gricView1_FocusRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void gricView1_FocusColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            
        }
    }
}