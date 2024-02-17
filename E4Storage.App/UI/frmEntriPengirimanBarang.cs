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
using DevExpress.XtraGrid.Views.Grid;

namespace Inventory.App.UI
{
    public partial class frmEntriPengirimanBarang : DevExpress.XtraEditors.XtraForm
    {
        public DO data;
        public frmEntriPengirimanBarang(DO data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void frmEntriPengirimanBarang_Load(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, dataLayoutControl1);
            refreshLookUp();
            if (data == null)
            {
                //Create Baru
                data = new DO
                {
                    ID = Guid.NewGuid(),
                    DocNo = "",
                    DocDate = DateTime.Now,
                    IDCustomer = Guid.Empty,
                    IDWarehouse = Guid.Empty,
                    NoReff = "",
                    Note = "",
                    ConditionDelivery = "",
                    ContainerNo = "",
                    Finish = false,
                    Plant = "",
                    SalesOrderNo = "",
                    SealNo = "",
                    VehicleNo = "",
                    DODtl = new List<DODtl>(),
                    Void = false,
                    IDUserEdit = Guid.Empty,
                    IDUserEntri = Constant.UserLogin.ID,
                    IDUserHapus = Guid.Empty,
                    TglEdit = DateTime.Parse("1900-01-01"),
                    TglEntri = DateTime.Now,
                    TglHapus = DateTime.Parse("1900-01-01")
                };
            }
            DOMasterBindingSource.DataSource = data;
            dataLayoutControl1.Refresh();

            gridView1.DataSourceChanged += gridView1_DataSourceChanged;
            gridView2.DataSourceChanged += gridView1_DataSourceChanged;
            gridView3.DataSourceChanged += gridView1_DataSourceChanged;
            gridView4.DataSourceChanged += gridView1_DataSourceChanged;
            gvData.DataSourceChanged += gridView1_DataSourceChanged;
            gvGudang.DataSourceChanged += gridView1_DataSourceChanged;
            gvData.InitNewRow += gridView1_InitNewRow;

            //Kalau Sudah Void Maka diKunci
            mnSimpan.Enabled = !data.Void && !data.Finish;
            mnDelete.Enabled = !data.Void && !data.Finish;
            gvData.OptionsBehavior.Editable = !data.Void && !data.Finish;
            gvData.OptionsView.NewItemRowPosition = data.Void || data.Finish ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                int NoUrut = data.DODtl.Max(o => o.NoUrut);
                gridView1.SetRowCellValue(e.RowHandle, colNoUrut, NoUrut + 1);
                gridView1.SetRowCellValue(e.RowHandle, colID, Guid.NewGuid());
                gridView1.SetRowCellValue(e.RowHandle, colIDDO, data.ID);
                gridView1.SetRowCellValue(e.RowHandle, colIDInventor, Guid.Empty);
                gridView1.SetRowCellValue(e.RowHandle, colIDUOM, Guid.Empty);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.gridView1_InitNewRow", ex);
            }
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
                    if (data.IDWarehouse == null || data.IDWarehouse == Guid.Empty)
                    {
                        dxErrorProvider1.SetError(IDWarehouseSearchLookUpEdit, "Gudang harus dipilih!");
                    }
                    if (data.IDCustomer == null || data.IDCustomer == Guid.Empty)
                    {
                        dxErrorProvider1.SetError(IDCustomerSearchLookUpEdit, "Customer harus dipilih!");
                    }
                    if (data.DODtl == null || data.DODtl.Count == 0)
                    {
                        dxErrorProvider1.SetError(DocNoTextEdit, "Item Barang belum ada!");
                    }
                    if (data.Void)
                    {
                        dxErrorProvider1.SetError(DocNoTextEdit, "PengirimanBarang ini telah divoid!");
                    }

                    if (!dxErrorProvider1.HasErrors)
                    {
                        var save = Repository.PengirimanBarang.saveDOs(data);
                        if (save.Item1)
                        {
                            this.data = save.Item3;
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else if (!string.IsNullOrEmpty(save.Item2) && !string.IsNullOrWhiteSpace(save.Item2))
                        {
                            MsgBoxHelper.MsgWarn($"{this.Name}.mnSimpan_ItemClick", save.Item2);
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

        private void frmEntriPengirimanBarang_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, dataLayoutControl1);
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView2);
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView3);
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView4);
            Constant.layoutsHelper.SaveLayouts(this.Name, gvData);
            Constant.layoutsHelper.SaveLayouts(this.Name, gvGudang);
        }

        private List<ItemLookUp> listItem = new List<ItemLookUp>();
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

                    Guid IDWarehouse = Guid.Empty;
                    if (IDWarehouseSearchLookUpEdit.EditValue != null)
                    {
                        Guid.TryParse(IDWarehouseSearchLookUpEdit.EditValue.ToString(), out IDWarehouse);
                    }
                    var callItem = Repository.Item.getLookUpInventors(DocDateDateEdit.EditValue == null ? DateTime.Parse("1900-01-01") : DocDateDateEdit.DateTime,
                                                                      IDWarehouse,
                                                                      (data != null ? data.ID : Guid.Empty),
                                                                      null);
                    if (callItem.Item1)
                    {
                        listItem = callItem.Item2;
                    }
                    else
                    {
                        listItem = new List<ItemLookUp>();
                    }
                    repositoryItemItem.DataSource = listItem;
                    repositoryItemItem.ValueMember = "ID";
                    repositoryItemItem.DisplayMember = "PLU";

                    var callUOM = Repository.Item.getUOMs();
                    repositoryItemSatuan.DataSource = callUOM.Item2;
                    repositoryItemSatuan.ValueMember = "ID";
                    repositoryItemSatuan.DisplayMember = "Satuan";

                    var callCustomer = Repository.Customer.getLookUpCustomers(null);
                    IDCustomerSearchLookUpEdit.Properties.DataSource = (from x in callCustomer.Item2
                                                                        select new { x.ID, Customer = x.Code + " - " + x.Name, x.Address }).ToList();
                    IDCustomerSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDCustomerSearchLookUpEdit.Properties.DisplayMember = "Customer";

                    var callWarehouse = Repository.Warehouse.getLookUpWarehouses(null);
                    IDWarehouseSearchLookUpEdit.Properties.DataSource = callWarehouse.Item2;
                    IDWarehouseSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDWarehouseSearchLookUpEdit.Properties.DisplayMember = "Code";
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshLookUp", ex);
                }
            }
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, sender as GridView);
        }

        private void mnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvData.DeleteSelectedRows();
            HitungTotal();
        }

        private void HitungTotal()
        {
            dataLayoutControl1.Validate();
            this.Validate();

            dataLayoutControl1.Refresh();
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.Valid)
            {
                DODtl currentItem = (DODtlBindingSource.Current as DODtl);
                ItemLookUp barang = listItem.FirstOrDefault(o => o.ID == currentItem.IDInventor);
                if (barang != null)
                {
                    currentItem.IDUOM = barang.IDUOM;
                    currentItem.Desc = barang.Desc;
                    var grp = data.DODtl.Where(o => o.IDInventor == currentItem.IDInventor).Sum(o => o.Qty);

                    if (currentItem.Qty > barang.Saldo || grp > barang.Saldo)
                    {
                        e.Valid = false;
                        e.ErrorText = "Saldo Barang tidak mencukupi!";
                    }
                }
                else
                {
                    e.Valid = false;
                    e.ErrorText = "Item harus dipilih";
                }

                HitungTotal();
            }
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Valid)
            {
                DODtl currentItem = (DODtlBindingSource.Current as DODtl);
                if (currentItem.NoUrut == 0)
                {
                    currentItem.NoUrut = data.DODtl.Max(o => o.NoUrut) + 1;
                }
                Guid IDInventor = Guid.Empty;
                if (gvData.FocusedColumn == colIDInventor)
                {
                    Guid.TryParse(e.Value.ToString(), out IDInventor);
                }
                else
                {
                    IDInventor = currentItem.IDInventor;
                }
                ItemLookUp barang = listItem.FirstOrDefault(o => o.ID == IDInventor);
                if (barang != null)
                {
                    currentItem.IDUOM = barang.IDUOM;
                    currentItem.Desc = barang.Desc;
                }

                HitungTotal();
            }
        }

        private void DocDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            refreshLookUp();
        }

        private void TaxTypeComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            HitungTotal();
        }

        private void TaxProsenTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            HitungTotal();
        }

        private void IDWarehouseSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            refreshLookUp();
        }

        private void DiscProsenTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            HitungTotal();
        }

        private void DiscTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            HitungTotal();
        }
    }
}