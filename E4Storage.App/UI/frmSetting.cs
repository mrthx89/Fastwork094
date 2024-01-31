﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E4Storage.App.UI
{
    public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    {
        public Model.AppSetting AppSetting;
        public frmSetting(Model.AppSetting AppSetting)
        {
            InitializeComponent();

            this.AppSetting = AppSetting;
        }

        private void mnSimpan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Validate();

            using (Data.E4StorageContext context = new Data.E4StorageContext(AppSetting.KoneksiString))
            {
                try
                {
                    context.Database.Connection.Open();
                    E4Storage.App.Helper.MsgBoxHelper.MsgInfo($"{this.Name}.mnSimpan_ItemClick", "Koneksi terhubung!");

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.mnSimpan_ItemClick", ex);
                }
            }
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            appSettingBindingSource.DataSource = AppSetting;
        }
    }
}