
namespace Inventory.App.UI
{
    partial class frmDaftarPengirimanBarang
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
            this.mnBaru = new DevExpress.XtraBars.BarButtonItem();
            this.mnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.mnHapus = new DevExpress.XtraBars.BarButtonItem();
            this.mnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.mnCetakInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.DOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoReff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDWarehouse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGudang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIDCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCustomer = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserEntri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemUser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTglEntri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTglEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserHapus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTglHapus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.colConditionDelivery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSealNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVoid = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGudang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
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
            this.mnBaru,
            this.mnEdit,
            this.mnHapus,
            this.mnRefresh,
            this.mnCetakInvoice});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnBaru),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnHapus),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnCetakInvoice, true)});
            this.bar1.Text = "Tools";
            // 
            // mnBaru
            // 
            this.mnBaru.Caption = "&Baru [F1]";
            this.mnBaru.Id = 0;
            this.mnBaru.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.mnBaru.Name = "mnBaru";
            this.mnBaru.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnBaru_ItemClick);
            // 
            // mnEdit
            // 
            this.mnEdit.Caption = "&Edit [F2]";
            this.mnEdit.Id = 1;
            this.mnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.mnEdit.Name = "mnEdit";
            this.mnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnEdit_ItemClick);
            // 
            // mnHapus
            // 
            this.mnHapus.Caption = "&Hapus [F4]";
            this.mnHapus.Id = 2;
            this.mnHapus.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.mnHapus.Name = "mnHapus";
            this.mnHapus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnHapus_ItemClick);
            // 
            // mnRefresh
            // 
            this.mnRefresh.Caption = "&Refresh [F5]";
            this.mnRefresh.Id = 3;
            this.mnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.mnRefresh.Name = "mnRefresh";
            this.mnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnRefresh_ItemClick);
            // 
            // mnCetakInvoice
            // 
            this.mnCetakInvoice.Caption = "&Cetak [F6]";
            this.mnCetakInvoice.Id = 4;
            this.mnCetakInvoice.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.mnCetakInvoice.Name = "mnCetakInvoice";
            this.mnCetakInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnCetakInvoice_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1102, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 674);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1102, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 654);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1102, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 654);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.DOBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemUser,
            this.repositoryItemGudang,
            this.repositoryItemCustomer});
            this.gridControl1.Size = new System.Drawing.Size(1102, 618);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // DOBindingSource
            // 
            this.DOBindingSource.DataSource = typeof(Inventory.App.Model.ViewModel.DO);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colDocNo,
            this.colDocDate,
            this.colNoReff,
            this.colIDWarehouse,
            this.colIDCustomer,
            this.colNote,
            this.colIDUserEntri,
            this.colTglEntri,
            this.colIDUserEdit,
            this.colTglEdit,
            this.colIDUserHapus,
            this.colTglHapus,
            this.colConditionDelivery,
            this.colContainerNo,
            this.colFinish,
            this.colPlant,
            this.colSalesOrderNo,
            this.colSealNo,
            this.colVehicleNo,
            this.colVoid});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView1.DataSourceChanged += new System.EventHandler(this.gridView1_DataSourceChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colDocNo
            // 
            this.colDocNo.Caption = "No Nota";
            this.colDocNo.FieldName = "DocNo";
            this.colDocNo.Name = "colDocNo";
            this.colDocNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DocNo", "{0}")});
            this.colDocNo.Visible = true;
            this.colDocNo.VisibleIndex = 0;
            // 
            // colDocDate
            // 
            this.colDocDate.Caption = "Tanggal";
            this.colDocDate.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colDocDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 1;
            // 
            // colNoReff
            // 
            this.colNoReff.FieldName = "NoReff";
            this.colNoReff.Name = "colNoReff";
            this.colNoReff.Visible = true;
            this.colNoReff.VisibleIndex = 2;
            // 
            // colIDWarehouse
            // 
            this.colIDWarehouse.Caption = "Gudang";
            this.colIDWarehouse.ColumnEdit = this.repositoryItemGudang;
            this.colIDWarehouse.FieldName = "IDWarehouse";
            this.colIDWarehouse.Name = "colIDWarehouse";
            this.colIDWarehouse.Visible = true;
            this.colIDWarehouse.VisibleIndex = 3;
            // 
            // repositoryItemGudang
            // 
            this.repositoryItemGudang.AutoHeight = false;
            this.repositoryItemGudang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGudang.Name = "repositoryItemGudang";
            // 
            // colIDCustomer
            // 
            this.colIDCustomer.Caption = "Customer";
            this.colIDCustomer.ColumnEdit = this.repositoryItemCustomer;
            this.colIDCustomer.FieldName = "IDCustomer";
            this.colIDCustomer.Name = "colIDCustomer";
            this.colIDCustomer.Visible = true;
            this.colIDCustomer.VisibleIndex = 4;
            // 
            // repositoryItemCustomer
            // 
            this.repositoryItemCustomer.AutoHeight = false;
            this.repositoryItemCustomer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCustomer.Name = "repositoryItemCustomer";
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 5;
            this.colNote.Width = 116;
            // 
            // colIDUserEntri
            // 
            this.colIDUserEntri.Caption = "User Entri";
            this.colIDUserEntri.ColumnEdit = this.repositoryItemUser;
            this.colIDUserEntri.FieldName = "IDUserEntri";
            this.colIDUserEntri.Name = "colIDUserEntri";
            this.colIDUserEntri.Visible = true;
            this.colIDUserEntri.VisibleIndex = 6;
            // 
            // repositoryItemUser
            // 
            this.repositoryItemUser.AutoHeight = false;
            this.repositoryItemUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemUser.Name = "repositoryItemUser";
            // 
            // colTglEntri
            // 
            this.colTglEntri.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTglEntri.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglEntri.FieldName = "TglEntri";
            this.colTglEntri.Name = "colTglEntri";
            this.colTglEntri.Visible = true;
            this.colTglEntri.VisibleIndex = 7;
            // 
            // colIDUserEdit
            // 
            this.colIDUserEdit.Caption = "User Edit";
            this.colIDUserEdit.ColumnEdit = this.repositoryItemUser;
            this.colIDUserEdit.FieldName = "IDUserEdit";
            this.colIDUserEdit.Name = "colIDUserEdit";
            this.colIDUserEdit.Visible = true;
            this.colIDUserEdit.VisibleIndex = 8;
            // 
            // colTglEdit
            // 
            this.colTglEdit.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTglEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglEdit.FieldName = "TglEdit";
            this.colTglEdit.Name = "colTglEdit";
            this.colTglEdit.Visible = true;
            this.colTglEdit.VisibleIndex = 9;
            // 
            // colIDUserHapus
            // 
            this.colIDUserHapus.Caption = "User Hapus";
            this.colIDUserHapus.ColumnEdit = this.repositoryItemUser;
            this.colIDUserHapus.FieldName = "IDUserHapus";
            this.colIDUserHapus.Name = "colIDUserHapus";
            this.colIDUserHapus.Visible = true;
            this.colIDUserHapus.VisibleIndex = 10;
            // 
            // colTglHapus
            // 
            this.colTglHapus.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTglHapus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglHapus.FieldName = "TglHapus";
            this.colTglHapus.Name = "colTglHapus";
            this.colTglHapus.Visible = true;
            this.colTglHapus.VisibleIndex = 11;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dateEdit2);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1102, 36);
            this.panelControl1.TabIndex = 9;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = new System.DateTime(2023, 10, 2, 10, 27, 44, 361);
            this.dateEdit2.EnterMoveNextControl = true;
            this.dateEdit2.Location = new System.Drawing.Point(190, 9);
            this.dateEdit2.MenuManager = this.barManager1;
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(169, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(15, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "s/d";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2023, 10, 2, 10, 27, 44, 361);
            this.dateEdit1.EnterMoveNextControl = true;
            this.dateEdit1.Location = new System.Drawing.Point(63, 9);
            this.dateEdit1.MenuManager = this.barManager1;
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Periode";
            // 
            // colConditionDelivery
            // 
            this.colConditionDelivery.FieldName = "ConditionDelivery";
            this.colConditionDelivery.Name = "colConditionDelivery";
            this.colConditionDelivery.Visible = true;
            this.colConditionDelivery.VisibleIndex = 12;
            this.colConditionDelivery.Width = 110;
            // 
            // colContainerNo
            // 
            this.colContainerNo.FieldName = "ContainerNo";
            this.colContainerNo.Name = "colContainerNo";
            this.colContainerNo.Visible = true;
            this.colContainerNo.VisibleIndex = 13;
            // 
            // colFinish
            // 
            this.colFinish.FieldName = "Finish";
            this.colFinish.Name = "colFinish";
            this.colFinish.Visible = true;
            this.colFinish.VisibleIndex = 14;
            // 
            // colPlant
            // 
            this.colPlant.FieldName = "Plant";
            this.colPlant.Name = "colPlant";
            this.colPlant.Visible = true;
            this.colPlant.VisibleIndex = 15;
            // 
            // colSalesOrderNo
            // 
            this.colSalesOrderNo.FieldName = "SalesOrderNo";
            this.colSalesOrderNo.Name = "colSalesOrderNo";
            this.colSalesOrderNo.Visible = true;
            this.colSalesOrderNo.VisibleIndex = 16;
            this.colSalesOrderNo.Width = 95;
            // 
            // colSealNo
            // 
            this.colSealNo.FieldName = "SealNo";
            this.colSealNo.Name = "colSealNo";
            this.colSealNo.Visible = true;
            this.colSealNo.VisibleIndex = 17;
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.FieldName = "VehicleNo";
            this.colVehicleNo.Name = "colVehicleNo";
            this.colVehicleNo.Visible = true;
            this.colVehicleNo.VisibleIndex = 18;
            // 
            // colVoid
            // 
            this.colVoid.FieldName = "Void";
            this.colVoid.Name = "colVoid";
            this.colVoid.Visible = true;
            this.colVoid.VisibleIndex = 19;
            // 
            // frmDaftarPengirimanBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 674);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDaftarPengirimanBarang";
            this.Text = "Daftar Pengiriman Barang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDaftarPengirimanBarang_FormCLossing);
            this.Load += new System.EventHandler(this.frmDaftarPengirimanBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGudang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem mnBaru;
        private DevExpress.XtraBars.BarButtonItem mnEdit;
        private DevExpress.XtraBars.BarButtonItem mnHapus;
        private DevExpress.XtraBars.BarButtonItem mnRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemGudang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemUser;
        private System.Windows.Forms.BindingSource DOBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNoReff;
        private DevExpress.XtraGrid.Columns.GridColumn colIDWarehouse;
        private DevExpress.XtraGrid.Columns.GridColumn colIDCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserEntri;
        private DevExpress.XtraGrid.Columns.GridColumn colTglEntri;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colTglEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserHapus;
        private DevExpress.XtraGrid.Columns.GridColumn colTglHapus;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.BarButtonItem mnCetakInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn colConditionDelivery;
        private DevExpress.XtraGrid.Columns.GridColumn colContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn colFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colPlant;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSealNo;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleNo;
        private DevExpress.XtraGrid.Columns.GridColumn colVoid;
    }
}