
namespace Inventory.App.UI
{
    partial class frmEntriPengirimanBarang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.mnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mnSimpan = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.DODtlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DOMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoUrut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDInventor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemItem = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSatuan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TglEntriDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.TglEditDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.IDUserEntriSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDUserEditSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDUserHapusSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TglHapusDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.DocNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DocDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.NoReffTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.IDWarehouseSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvGudang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDCustomerSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NoteMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDocNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNoReff = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForIDWarehouse = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIDCustomer = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.SealNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForSealNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ContainerNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForContainerNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ConditionDeliveryTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForConditionDelivery = new DevExpress.XtraLayout.LayoutControlItem();
            this.PlantTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForPlant = new DevExpress.XtraLayout.LayoutControlItem();
            this.VehicleNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForVehicleNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.SalesOrderNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForSalesOrderNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForTglEntri = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIDUserEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTglEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIDUserHapus = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTglHapus = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIDUserEntri = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DODtlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSatuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEntriDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEntriDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEditDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEditDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserEntriSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserEditSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserHapusSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglHapusDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglHapusDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoReffTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDWarehouseSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGudang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDCustomerSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNoReff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SealNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSealNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContainerNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConditionDeliveryTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForConditionDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlantTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPlant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VehicleNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVehicleNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSalesOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglEntri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserHapus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglHapus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserEntri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mnSimpan,
            this.mnDelete});
            this.barManager1.MaxItemId = 2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnSimpan, true)});
            this.bar1.Text = "Tools";
            // 
            // mnDelete
            // 
            this.mnDelete.Caption = "&Delete [F4]";
            this.mnDelete.Id = 1;
            this.mnDelete.Name = "mnDelete";
            this.mnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnDelete_ItemClick);
            // 
            // mnSimpan
            // 
            this.mnSimpan.Caption = "&Simpan [F6]";
            this.mnSimpan.Id = 0;
            this.mnSimpan.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.mnSimpan.Name = "mnSimpan";
            this.mnSimpan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnSimpan_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1183, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 632);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1183, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 612);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1183, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 612);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.TglEntriDateEdit);
            this.dataLayoutControl1.Controls.Add(this.TglEditDateEdit);
            this.dataLayoutControl1.Controls.Add(this.IDUserEntriSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.IDUserEditSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.IDUserHapusSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.TglHapusDateEdit);
            this.dataLayoutControl1.Controls.Add(this.DocNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DocDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.NoReffTextEdit);
            this.dataLayoutControl1.Controls.Add(this.IDWarehouseSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.IDCustomerSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.NoteMemoEdit);
            this.dataLayoutControl1.Controls.Add(this.SealNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ContainerNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ConditionDeliveryTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PlantTextEdit);
            this.dataLayoutControl1.Controls.Add(this.VehicleNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SalesOrderNoTextEdit);
            this.dataLayoutControl1.DataSource = this.DOMasterBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 20);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1098, 361, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1183, 612);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.DODtlBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 129);
            this.gridControl1.MainView = this.gvData;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemItem,
            this.repositoryItemSatuan,
            this.repositoryItemNumber,
            this.repositoryItemQty});
            this.gridControl1.Size = new System.Drawing.Size(1159, 280);
            this.gridControl1.TabIndex = 41;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // DODtlBindingSource
            // 
            this.DODtlBindingSource.DataMember = "DODtl";
            this.DODtlBindingSource.DataSource = this.DOMasterBindingSource;
            // 
            // DOMasterBindingSource
            // 
            this.DOMasterBindingSource.DataSource = typeof(Inventory.App.Model.ViewModel.DO);
            // 
            // gvData
            // 
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colIDDO,
            this.colNoUrut,
            this.colIDInventor,
            this.colDesc,
            this.colIDUOM,
            this.colQty,
            this.colNote});
            this.gvData.GridControl = this.gridControl1;
            this.gvData.Name = "gvData";
            this.gvData.OptionsMenu.ShowFooterItem = true;
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowFooter = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNoUrut, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            this.gvData.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvData_ValidatingEditor);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.AllowFocus = false;
            // 
            // colIDDO
            // 
            this.colIDDO.FieldName = "IDDO";
            this.colIDDO.Name = "colIDDO";
            this.colIDDO.OptionsColumn.AllowEdit = false;
            this.colIDDO.OptionsColumn.AllowFocus = false;
            // 
            // colNoUrut
            // 
            this.colNoUrut.FieldName = "NoUrut";
            this.colNoUrut.Name = "colNoUrut";
            this.colNoUrut.OptionsColumn.AllowEdit = false;
            this.colNoUrut.OptionsColumn.AllowFocus = false;
            this.colNoUrut.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "NoUrut", "{0}")});
            this.colNoUrut.Visible = true;
            this.colNoUrut.VisibleIndex = 0;
            this.colNoUrut.Width = 70;
            // 
            // colIDInventor
            // 
            this.colIDInventor.Caption = "Kode Barang";
            this.colIDInventor.ColumnEdit = this.repositoryItemItem;
            this.colIDInventor.FieldName = "IDInventor";
            this.colIDInventor.Name = "colIDInventor";
            this.colIDInventor.Visible = true;
            this.colIDInventor.VisibleIndex = 1;
            this.colIDInventor.Width = 124;
            // 
            // repositoryItemItem
            // 
            this.repositoryItemItem.AutoHeight = false;
            this.repositoryItemItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemItem.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PLU", "PLU"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "Desc"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Satuan", "Satuan"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Saldo", "Saldo", 20, DevExpress.Utils.FormatType.Numeric, "n0", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemItem.Name = "repositoryItemItem";
            // 
            // colDesc
            // 
            this.colDesc.Caption = "Nama Barang";
            this.colDesc.FieldName = "Desc";
            this.colDesc.Name = "colDesc";
            this.colDesc.OptionsColumn.AllowEdit = false;
            this.colDesc.OptionsColumn.AllowFocus = false;
            this.colDesc.Visible = true;
            this.colDesc.VisibleIndex = 2;
            this.colDesc.Width = 260;
            // 
            // colIDUOM
            // 
            this.colIDUOM.Caption = "Satuan";
            this.colIDUOM.ColumnEdit = this.repositoryItemSatuan;
            this.colIDUOM.FieldName = "IDUOM";
            this.colIDUOM.Name = "colIDUOM";
            this.colIDUOM.OptionsColumn.AllowEdit = false;
            this.colIDUOM.OptionsColumn.AllowFocus = false;
            this.colIDUOM.Visible = true;
            this.colIDUOM.VisibleIndex = 3;
            this.colIDUOM.Width = 52;
            // 
            // repositoryItemSatuan
            // 
            this.repositoryItemSatuan.AutoHeight = false;
            this.repositoryItemSatuan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSatuan.Name = "repositoryItemSatuan";
            // 
            // colQty
            // 
            this.colQty.AppearanceCell.Options.UseTextOptions = true;
            this.colQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQty.Caption = "Qty";
            this.colQty.ColumnEdit = this.repositoryItemQty;
            this.colQty.DisplayFormat.FormatString = "n0";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n0}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 4;
            // 
            // repositoryItemQty
            // 
            this.repositoryItemQty.Appearance.Options.UseTextOptions = true;
            this.repositoryItemQty.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemQty.AutoHeight = false;
            this.repositoryItemQty.DisplayFormat.FormatString = "n0";
            this.repositoryItemQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemQty.Mask.EditMask = "n0";
            this.repositoryItemQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemQty.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemQty.Name = "repositoryItemQty";
            // 
            // repositoryItemNumber
            // 
            this.repositoryItemNumber.Appearance.Options.UseTextOptions = true;
            this.repositoryItemNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemNumber.AutoHeight = false;
            this.repositoryItemNumber.EditFormat.FormatString = "n2";
            this.repositoryItemNumber.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemNumber.Mask.EditMask = "n2";
            this.repositoryItemNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemNumber.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemNumber.Name = "repositoryItemNumber";
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 5;
            this.colNote.Width = 266;
            // 
            // TglEntriDateEdit
            // 
            this.TglEntriDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "TglEntri", true));
            this.TglEntriDateEdit.EditValue = null;
            this.TglEntriDateEdit.EnterMoveNextControl = true;
            this.TglEntriDateEdit.Location = new System.Drawing.Point(114, 472);
            this.TglEntriDateEdit.MenuManager = this.barManager1;
            this.TglEntriDateEdit.Name = "TglEntriDateEdit";
            this.TglEntriDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.TglEntriDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglEntriDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglEntriDateEdit.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm:ss";
            this.TglEntriDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.TglEntriDateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TglEntriDateEdit.Properties.ReadOnly = true;
            this.TglEntriDateEdit.Size = new System.Drawing.Size(178, 20);
            this.TglEntriDateEdit.StyleController = this.dataLayoutControl1;
            this.TglEntriDateEdit.TabIndex = 8;
            // 
            // TglEditDateEdit
            // 
            this.TglEditDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "TglEdit", true));
            this.TglEditDateEdit.EditValue = null;
            this.TglEditDateEdit.EnterMoveNextControl = true;
            this.TglEditDateEdit.Location = new System.Drawing.Point(114, 520);
            this.TglEditDateEdit.MenuManager = this.barManager1;
            this.TglEditDateEdit.Name = "TglEditDateEdit";
            this.TglEditDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.TglEditDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglEditDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglEditDateEdit.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm:ss";
            this.TglEditDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.TglEditDateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TglEditDateEdit.Properties.ReadOnly = true;
            this.TglEditDateEdit.Size = new System.Drawing.Size(178, 20);
            this.TglEditDateEdit.StyleController = this.dataLayoutControl1;
            this.TglEditDateEdit.TabIndex = 10;
            // 
            // IDUserEntriSearchLookUpEdit
            // 
            this.IDUserEntriSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "IDUserEntri", true));
            this.IDUserEntriSearchLookUpEdit.EnterMoveNextControl = true;
            this.IDUserEntriSearchLookUpEdit.Location = new System.Drawing.Point(114, 448);
            this.IDUserEntriSearchLookUpEdit.MenuManager = this.barManager1;
            this.IDUserEntriSearchLookUpEdit.Name = "IDUserEntriSearchLookUpEdit";
            this.IDUserEntriSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IDUserEntriSearchLookUpEdit.Properties.NullText = "";
            this.IDUserEntriSearchLookUpEdit.Properties.PopupView = this.gridView1;
            this.IDUserEntriSearchLookUpEdit.Properties.ReadOnly = true;
            this.IDUserEntriSearchLookUpEdit.Size = new System.Drawing.Size(178, 20);
            this.IDUserEntriSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.IDUserEntriSearchLookUpEdit.TabIndex = 12;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // IDUserEditSearchLookUpEdit
            // 
            this.IDUserEditSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "IDUserEdit", true));
            this.IDUserEditSearchLookUpEdit.EnterMoveNextControl = true;
            this.IDUserEditSearchLookUpEdit.Location = new System.Drawing.Point(114, 496);
            this.IDUserEditSearchLookUpEdit.MenuManager = this.barManager1;
            this.IDUserEditSearchLookUpEdit.Name = "IDUserEditSearchLookUpEdit";
            this.IDUserEditSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IDUserEditSearchLookUpEdit.Properties.NullText = "";
            this.IDUserEditSearchLookUpEdit.Properties.PopupView = this.gridView2;
            this.IDUserEditSearchLookUpEdit.Properties.ReadOnly = true;
            this.IDUserEditSearchLookUpEdit.Size = new System.Drawing.Size(178, 20);
            this.IDUserEditSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.IDUserEditSearchLookUpEdit.TabIndex = 13;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // IDUserHapusSearchLookUpEdit
            // 
            this.IDUserHapusSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "IDUserHapus", true));
            this.IDUserHapusSearchLookUpEdit.EnterMoveNextControl = true;
            this.IDUserHapusSearchLookUpEdit.Location = new System.Drawing.Point(114, 544);
            this.IDUserHapusSearchLookUpEdit.MenuManager = this.barManager1;
            this.IDUserHapusSearchLookUpEdit.Name = "IDUserHapusSearchLookUpEdit";
            this.IDUserHapusSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IDUserHapusSearchLookUpEdit.Properties.NullText = "";
            this.IDUserHapusSearchLookUpEdit.Properties.PopupView = this.gridView3;
            this.IDUserHapusSearchLookUpEdit.Properties.ReadOnly = true;
            this.IDUserHapusSearchLookUpEdit.Size = new System.Drawing.Size(178, 20);
            this.IDUserHapusSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.IDUserHapusSearchLookUpEdit.TabIndex = 24;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // TglHapusDateEdit
            // 
            this.TglHapusDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "TglHapus", true));
            this.TglHapusDateEdit.EditValue = null;
            this.TglHapusDateEdit.EnterMoveNextControl = true;
            this.TglHapusDateEdit.Location = new System.Drawing.Point(114, 568);
            this.TglHapusDateEdit.MenuManager = this.barManager1;
            this.TglHapusDateEdit.Name = "TglHapusDateEdit";
            this.TglHapusDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.TglHapusDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglHapusDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglHapusDateEdit.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm:ss";
            this.TglHapusDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.TglHapusDateEdit.Properties.ReadOnly = true;
            this.TglHapusDateEdit.Size = new System.Drawing.Size(178, 20);
            this.TglHapusDateEdit.StyleController = this.dataLayoutControl1;
            this.TglHapusDateEdit.TabIndex = 25;
            // 
            // DocNoTextEdit
            // 
            this.DocNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "DocNo", true));
            this.DocNoTextEdit.EnterMoveNextControl = true;
            this.DocNoTextEdit.Location = new System.Drawing.Point(114, 45);
            this.DocNoTextEdit.MenuManager = this.barManager1;
            this.DocNoTextEdit.Name = "DocNoTextEdit";
            this.DocNoTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DocNoTextEdit.Properties.ReadOnly = true;
            this.DocNoTextEdit.Size = new System.Drawing.Size(138, 20);
            this.DocNoTextEdit.StyleController = this.dataLayoutControl1;
            this.DocNoTextEdit.TabIndex = 27;
            // 
            // DocDateDateEdit
            // 
            this.DocDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "DocDate", true));
            this.DocDateDateEdit.EditValue = null;
            this.DocDateDateEdit.EnterMoveNextControl = true;
            this.DocDateDateEdit.Location = new System.Drawing.Point(114, 69);
            this.DocDateDateEdit.MenuManager = this.barManager1;
            this.DocDateDateEdit.Name = "DocDateDateEdit";
            this.DocDateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DocDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocDateDateEdit.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm:ss";
            this.DocDateDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DocDateDateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DocDateDateEdit.Size = new System.Drawing.Size(138, 20);
            this.DocDateDateEdit.StyleController = this.dataLayoutControl1;
            this.DocDateDateEdit.TabIndex = 28;
            this.DocDateDateEdit.EditValueChanged += new System.EventHandler(this.DocDateDateEdit_EditValueChanged);
            // 
            // NoReffTextEdit
            // 
            this.NoReffTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "NoReff", true));
            this.NoReffTextEdit.EnterMoveNextControl = true;
            this.NoReffTextEdit.Location = new System.Drawing.Point(114, 93);
            this.NoReffTextEdit.MenuManager = this.barManager1;
            this.NoReffTextEdit.Name = "NoReffTextEdit";
            this.NoReffTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NoReffTextEdit.Size = new System.Drawing.Size(138, 20);
            this.NoReffTextEdit.StyleController = this.dataLayoutControl1;
            this.NoReffTextEdit.TabIndex = 29;
            // 
            // IDWarehouseSearchLookUpEdit
            // 
            this.IDWarehouseSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "IDWarehouse", true));
            this.IDWarehouseSearchLookUpEdit.EnterMoveNextControl = true;
            this.IDWarehouseSearchLookUpEdit.Location = new System.Drawing.Point(980, 69);
            this.IDWarehouseSearchLookUpEdit.MenuManager = this.barManager1;
            this.IDWarehouseSearchLookUpEdit.Name = "IDWarehouseSearchLookUpEdit";
            this.IDWarehouseSearchLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.IDWarehouseSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IDWarehouseSearchLookUpEdit.Properties.NullText = "";
            this.IDWarehouseSearchLookUpEdit.Properties.PopupView = this.gvGudang;
            this.IDWarehouseSearchLookUpEdit.Size = new System.Drawing.Size(179, 20);
            this.IDWarehouseSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.IDWarehouseSearchLookUpEdit.TabIndex = 30;
            this.IDWarehouseSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.IDWarehouseSearchLookUpEdit_EditValueChanged);
            // 
            // gvGudang
            // 
            this.gvGudang.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvGudang.Name = "gvGudang";
            this.gvGudang.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvGudang.OptionsView.ShowGroupPanel = false;
            // 
            // IDCustomerSearchLookUpEdit
            // 
            this.IDCustomerSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "IDCustomer", true));
            this.IDCustomerSearchLookUpEdit.EnterMoveNextControl = true;
            this.IDCustomerSearchLookUpEdit.Location = new System.Drawing.Point(980, 45);
            this.IDCustomerSearchLookUpEdit.MenuManager = this.barManager1;
            this.IDCustomerSearchLookUpEdit.Name = "IDCustomerSearchLookUpEdit";
            this.IDCustomerSearchLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.IDCustomerSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IDCustomerSearchLookUpEdit.Properties.NullText = "";
            this.IDCustomerSearchLookUpEdit.Properties.PopupView = this.gridView4;
            this.IDCustomerSearchLookUpEdit.Size = new System.Drawing.Size(179, 20);
            this.IDCustomerSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.IDCustomerSearchLookUpEdit.TabIndex = 31;
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // NoteMemoEdit
            // 
            this.NoteMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "Note", true));
            this.NoteMemoEdit.Location = new System.Drawing.Point(980, 425);
            this.NoteMemoEdit.MenuManager = this.barManager1;
            this.NoteMemoEdit.Name = "NoteMemoEdit";
            this.NoteMemoEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NoteMemoEdit.Size = new System.Drawing.Size(179, 163);
            this.NoteMemoEdit.StyleController = this.dataLayoutControl1;
            this.NoteMemoEdit.TabIndex = 40;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1183, 612);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup4,
            this.layoutControlGroup5,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1163, 592);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDocNo,
            this.ItemForDocDate,
            this.ItemForNoReff});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(256, 117);
            this.layoutControlGroup2.Text = "Informasi Umum";
            // 
            // ItemForDocNo
            // 
            this.ItemForDocNo.Control = this.DocNoTextEdit;
            this.ItemForDocNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForDocNo.MaxSize = new System.Drawing.Size(232, 24);
            this.ItemForDocNo.MinSize = new System.Drawing.Size(232, 24);
            this.ItemForDocNo.Name = "ItemForDocNo";
            this.ItemForDocNo.Size = new System.Drawing.Size(232, 24);
            this.ItemForDocNo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForDocNo.Text = "Doc No";
            this.ItemForDocNo.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ItemForDocDate
            // 
            this.ItemForDocDate.Control = this.DocDateDateEdit;
            this.ItemForDocDate.Location = new System.Drawing.Point(0, 24);
            this.ItemForDocDate.Name = "ItemForDocDate";
            this.ItemForDocDate.Size = new System.Drawing.Size(232, 24);
            this.ItemForDocDate.Text = "Doc Date";
            this.ItemForDocDate.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ItemForNoReff
            // 
            this.ItemForNoReff.Control = this.NoReffTextEdit;
            this.ItemForNoReff.Location = new System.Drawing.Point(0, 48);
            this.ItemForNoReff.Name = "ItemForNoReff";
            this.ItemForNoReff.Size = new System.Drawing.Size(232, 24);
            this.ItemForNoReff.Text = "No Reff";
            this.ItemForNoReff.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForIDWarehouse,
            this.ItemForIDCustomer});
            this.layoutControlGroup4.Location = new System.Drawing.Point(866, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(297, 117);
            this.layoutControlGroup4.Text = "Customer";
            // 
            // ItemForIDWarehouse
            // 
            this.ItemForIDWarehouse.Control = this.IDWarehouseSearchLookUpEdit;
            this.ItemForIDWarehouse.Location = new System.Drawing.Point(0, 24);
            this.ItemForIDWarehouse.Name = "ItemForIDWarehouse";
            this.ItemForIDWarehouse.Size = new System.Drawing.Size(273, 48);
            this.ItemForIDWarehouse.Text = "Gudang";
            this.ItemForIDWarehouse.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ItemForIDCustomer
            // 
            this.ItemForIDCustomer.Control = this.IDCustomerSearchLookUpEdit;
            this.ItemForIDCustomer.Location = new System.Drawing.Point(0, 0);
            this.ItemForIDCustomer.MaxSize = new System.Drawing.Size(273, 24);
            this.ItemForIDCustomer.MinSize = new System.Drawing.Size(273, 24);
            this.ItemForIDCustomer.Name = "ItemForIDCustomer";
            this.ItemForIDCustomer.Size = new System.Drawing.Size(273, 24);
            this.ItemForIDCustomer.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForIDCustomer.Text = "Customer";
            this.ItemForIDCustomer.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForNote});
            this.layoutControlGroup5.Location = new System.Drawing.Point(866, 401);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(297, 191);
            this.layoutControlGroup5.Text = "Nilai";
            this.layoutControlGroup5.TextVisible = false;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteMemoEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 0);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(273, 167);
            this.ItemForNote.StartNewLine = true;
            this.ItemForNote.Text = "Note";
            this.ItemForNote.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 117);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1163, 284);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(256, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(610, 117);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(296, 401);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(570, 191);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // SealNoTextEdit
            // 
            this.SealNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "SealNo", true));
            this.SealNoTextEdit.Location = new System.Drawing.Point(114, 496);
            this.SealNoTextEdit.MenuManager = this.barManager1;
            this.SealNoTextEdit.Name = "SealNoTextEdit";
            this.SealNoTextEdit.Size = new System.Drawing.Size(178, 20);
            this.SealNoTextEdit.StyleController = this.dataLayoutControl1;
            this.SealNoTextEdit.TabIndex = 42;
            // 
            // ItemForSealNo
            // 
            this.ItemForSealNo.Control = this.SealNoTextEdit;
            this.ItemForSealNo.Location = new System.Drawing.Point(0, 48);
            this.ItemForSealNo.Name = "ItemForSealNo";
            this.ItemForSealNo.Size = new System.Drawing.Size(272, 24);
            this.ItemForSealNo.Text = "Seal No";
            this.ItemForSealNo.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ContainerNoTextEdit
            // 
            this.ContainerNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "ContainerNo", true));
            this.ContainerNoTextEdit.Location = new System.Drawing.Point(114, 472);
            this.ContainerNoTextEdit.MenuManager = this.barManager1;
            this.ContainerNoTextEdit.Name = "ContainerNoTextEdit";
            this.ContainerNoTextEdit.Size = new System.Drawing.Size(178, 20);
            this.ContainerNoTextEdit.StyleController = this.dataLayoutControl1;
            this.ContainerNoTextEdit.TabIndex = 43;
            // 
            // ItemForContainerNo
            // 
            this.ItemForContainerNo.Control = this.ContainerNoTextEdit;
            this.ItemForContainerNo.Location = new System.Drawing.Point(0, 24);
            this.ItemForContainerNo.Name = "ItemForContainerNo";
            this.ItemForContainerNo.Size = new System.Drawing.Size(272, 24);
            this.ItemForContainerNo.Text = "Container No";
            this.ItemForContainerNo.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ConditionDeliveryTextEdit
            // 
            this.ConditionDeliveryTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "ConditionDelivery", true));
            this.ConditionDeliveryTextEdit.Location = new System.Drawing.Point(114, 448);
            this.ConditionDeliveryTextEdit.MenuManager = this.barManager1;
            this.ConditionDeliveryTextEdit.Name = "ConditionDeliveryTextEdit";
            this.ConditionDeliveryTextEdit.Size = new System.Drawing.Size(178, 20);
            this.ConditionDeliveryTextEdit.StyleController = this.dataLayoutControl1;
            this.ConditionDeliveryTextEdit.TabIndex = 44;
            // 
            // ItemForConditionDelivery
            // 
            this.ItemForConditionDelivery.Control = this.ConditionDeliveryTextEdit;
            this.ItemForConditionDelivery.Location = new System.Drawing.Point(0, 0);
            this.ItemForConditionDelivery.Name = "ItemForConditionDelivery";
            this.ItemForConditionDelivery.Size = new System.Drawing.Size(272, 24);
            this.ItemForConditionDelivery.Text = "Condition Delivery";
            this.ItemForConditionDelivery.TextSize = new System.Drawing.Size(87, 13);
            // 
            // PlantTextEdit
            // 
            this.PlantTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "Plant", true));
            this.PlantTextEdit.Location = new System.Drawing.Point(114, 520);
            this.PlantTextEdit.MenuManager = this.barManager1;
            this.PlantTextEdit.Name = "PlantTextEdit";
            this.PlantTextEdit.Size = new System.Drawing.Size(178, 20);
            this.PlantTextEdit.StyleController = this.dataLayoutControl1;
            this.PlantTextEdit.TabIndex = 45;
            // 
            // ItemForPlant
            // 
            this.ItemForPlant.Control = this.PlantTextEdit;
            this.ItemForPlant.Location = new System.Drawing.Point(0, 72);
            this.ItemForPlant.Name = "ItemForPlant";
            this.ItemForPlant.Size = new System.Drawing.Size(272, 24);
            this.ItemForPlant.Text = "Plant";
            this.ItemForPlant.TextSize = new System.Drawing.Size(87, 13);
            // 
            // VehicleNoTextEdit
            // 
            this.VehicleNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "VehicleNo", true));
            this.VehicleNoTextEdit.Location = new System.Drawing.Point(114, 544);
            this.VehicleNoTextEdit.MenuManager = this.barManager1;
            this.VehicleNoTextEdit.Name = "VehicleNoTextEdit";
            this.VehicleNoTextEdit.Size = new System.Drawing.Size(178, 20);
            this.VehicleNoTextEdit.StyleController = this.dataLayoutControl1;
            this.VehicleNoTextEdit.TabIndex = 46;
            // 
            // ItemForVehicleNo
            // 
            this.ItemForVehicleNo.Control = this.VehicleNoTextEdit;
            this.ItemForVehicleNo.Location = new System.Drawing.Point(0, 96);
            this.ItemForVehicleNo.Name = "ItemForVehicleNo";
            this.ItemForVehicleNo.Size = new System.Drawing.Size(272, 24);
            this.ItemForVehicleNo.Text = "Vehicle No";
            this.ItemForVehicleNo.TextSize = new System.Drawing.Size(87, 13);
            // 
            // SalesOrderNoTextEdit
            // 
            this.SalesOrderNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DOMasterBindingSource, "SalesOrderNo", true));
            this.SalesOrderNoTextEdit.Location = new System.Drawing.Point(114, 568);
            this.SalesOrderNoTextEdit.MenuManager = this.barManager1;
            this.SalesOrderNoTextEdit.Name = "SalesOrderNoTextEdit";
            this.SalesOrderNoTextEdit.Size = new System.Drawing.Size(178, 20);
            this.SalesOrderNoTextEdit.StyleController = this.dataLayoutControl1;
            this.SalesOrderNoTextEdit.TabIndex = 47;
            // 
            // ItemForSalesOrderNo
            // 
            this.ItemForSalesOrderNo.Control = this.SalesOrderNoTextEdit;
            this.ItemForSalesOrderNo.Location = new System.Drawing.Point(0, 120);
            this.ItemForSalesOrderNo.Name = "ItemForSalesOrderNo";
            this.ItemForSalesOrderNo.Size = new System.Drawing.Size(272, 24);
            this.ItemForSalesOrderNo.Text = "Sales Order No";
            this.ItemForSalesOrderNo.TextSize = new System.Drawing.Size(87, 13);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 401);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup6;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(296, 191);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup6,
            this.layoutControlGroup3});
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTglEntri,
            this.ItemForIDUserEdit,
            this.ItemForTglEdit,
            this.ItemForIDUserHapus,
            this.ItemForTglHapus,
            this.ItemForIDUserEntri});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(272, 144);
            this.layoutControlGroup3.Text = "Log Data";
            // 
            // ItemForTglEntri
            // 
            this.ItemForTglEntri.Control = this.TglEntriDateEdit;
            this.ItemForTglEntri.Location = new System.Drawing.Point(0, 24);
            this.ItemForTglEntri.Name = "ItemForTglEntri";
            this.ItemForTglEntri.Size = new System.Drawing.Size(272, 24);
            this.ItemForTglEntri.Text = "Tgl Entri";
            this.ItemForTglEntri.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ItemForIDUserEdit
            // 
            this.ItemForIDUserEdit.Control = this.IDUserEditSearchLookUpEdit;
            this.ItemForIDUserEdit.Location = new System.Drawing.Point(0, 48);
            this.ItemForIDUserEdit.Name = "ItemForIDUserEdit";
            this.ItemForIDUserEdit.Size = new System.Drawing.Size(272, 24);
            this.ItemForIDUserEdit.Text = "User Edit";
            this.ItemForIDUserEdit.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ItemForTglEdit
            // 
            this.ItemForTglEdit.Control = this.TglEditDateEdit;
            this.ItemForTglEdit.Location = new System.Drawing.Point(0, 72);
            this.ItemForTglEdit.Name = "ItemForTglEdit";
            this.ItemForTglEdit.Size = new System.Drawing.Size(272, 24);
            this.ItemForTglEdit.Text = "Tgl Edit";
            this.ItemForTglEdit.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ItemForIDUserHapus
            // 
            this.ItemForIDUserHapus.Control = this.IDUserHapusSearchLookUpEdit;
            this.ItemForIDUserHapus.Location = new System.Drawing.Point(0, 96);
            this.ItemForIDUserHapus.Name = "ItemForIDUserHapus";
            this.ItemForIDUserHapus.Size = new System.Drawing.Size(272, 24);
            this.ItemForIDUserHapus.Text = "User Hapus";
            this.ItemForIDUserHapus.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ItemForTglHapus
            // 
            this.ItemForTglHapus.Control = this.TglHapusDateEdit;
            this.ItemForTglHapus.Location = new System.Drawing.Point(0, 120);
            this.ItemForTglHapus.Name = "ItemForTglHapus";
            this.ItemForTglHapus.Size = new System.Drawing.Size(272, 24);
            this.ItemForTglHapus.Text = "Tgl Hapus";
            this.ItemForTglHapus.TextSize = new System.Drawing.Size(87, 13);
            // 
            // ItemForIDUserEntri
            // 
            this.ItemForIDUserEntri.Control = this.IDUserEntriSearchLookUpEdit;
            this.ItemForIDUserEntri.Location = new System.Drawing.Point(0, 0);
            this.ItemForIDUserEntri.MaxSize = new System.Drawing.Size(272, 24);
            this.ItemForIDUserEntri.MinSize = new System.Drawing.Size(272, 24);
            this.ItemForIDUserEntri.Name = "ItemForIDUserEntri";
            this.ItemForIDUserEntri.Size = new System.Drawing.Size(272, 24);
            this.ItemForIDUserEntri.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForIDUserEntri.Text = "User Entri";
            this.ItemForIDUserEntri.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForConditionDelivery,
            this.ItemForContainerNo,
            this.ItemForSealNo,
            this.ItemForPlant,
            this.ItemForVehicleNo,
            this.ItemForSalesOrderNo});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(272, 144);
            this.layoutControlGroup6.Text = "Informasi Pengiriman";
            // 
            // frmEntriPengirimanBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 632);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmEntriPengirimanBarang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entri Pengiriman Barang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntriPengirimanBarang_FormClosing);
            this.Load += new System.EventHandler(this.frmEntriPengirimanBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DODtlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSatuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEntriDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEntriDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEditDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEditDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserEntriSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserEditSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserHapusSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglHapusDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglHapusDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoReffTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDWarehouseSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGudang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDCustomerSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNoReff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SealNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSealNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContainerNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConditionDeliveryTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForConditionDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlantTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPlant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VehicleNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVehicleNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSalesOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglEntri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserHapus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglHapus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserEntri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraBars.BarButtonItem mnSimpan;
        private System.Windows.Forms.BindingSource DOMasterBindingSource;
        private DevExpress.XtraEditors.DateEdit TglEntriDateEdit;
        private DevExpress.XtraEditors.DateEdit TglEditDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SearchLookUpEdit IDUserEntriSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchLookUpEdit IDUserEditSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.SearchLookUpEdit IDUserHapusSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.DateEdit TglHapusDateEdit;
        private DevExpress.XtraEditors.TextEdit DocNoTextEdit;
        private DevExpress.XtraEditors.DateEdit DocDateDateEdit;
        private DevExpress.XtraEditors.TextEdit NoReffTextEdit;
        private DevExpress.XtraEditors.SearchLookUpEdit IDWarehouseSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGudang;
        private DevExpress.XtraEditors.SearchLookUpEdit IDCustomerSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.MemoEdit NoteMemoEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIDWarehouse;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIDCustomer;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemItem;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNoReff;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource DODtlBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colIDDO;
        private DevExpress.XtraGrid.Columns.GridColumn colNoUrut;
        private DevExpress.XtraGrid.Columns.GridColumn colIDInventor;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUOM;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colDesc;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemSatuan;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemNumber;
        private DevExpress.XtraBars.BarButtonItem mnDelete;
        private DevExpress.XtraEditors.TextEdit SealNoTextEdit;
        private DevExpress.XtraEditors.TextEdit ContainerNoTextEdit;
        private DevExpress.XtraEditors.TextEdit ConditionDeliveryTextEdit;
        private DevExpress.XtraEditors.TextEdit PlantTextEdit;
        private DevExpress.XtraEditors.TextEdit VehicleNoTextEdit;
        private DevExpress.XtraEditors.TextEdit SalesOrderNoTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSealNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContainerNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForConditionDelivery;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPlant;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVehicleNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSalesOrderNo;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTglEntri;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIDUserEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTglEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIDUserHapus;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTglHapus;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIDUserEntri;
    }
}