using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model
{
    public class AppSetting
    {
        public string KoneksiString { get { return ConfigurationManager.ConnectionStrings["Inventory"].ConnectionString; } }
        public string Theme { get; set; }
    }
}
