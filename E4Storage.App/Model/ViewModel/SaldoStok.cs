using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model.ViewModel
{
    public class SaldoStok : ItemMaster
    {
        [Required]
        public Guid IDWarehouse { get; set; }
        public string Warehouse { get; set; }
    }
}
