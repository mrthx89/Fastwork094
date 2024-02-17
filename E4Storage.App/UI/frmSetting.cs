using DevExpress.XtraEditors;
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

namespace Inventory.App.UI
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

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            appSettingBindingSource.DataSource = AppSetting;
        }
    }
}