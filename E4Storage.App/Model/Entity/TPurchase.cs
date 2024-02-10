using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model.Entity
{
    [Table("TPurchase")]
    public class TPurchase : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(20)]
        public string DocNo { get; set; }
        [Required]
        public DateTime DocDate { get; set; }
        public string NoReff { get; set; }
        [Required]
        public Guid IDWarehouse { get; set; }
        [Required]
        public Guid IDVendor { get; set; }
        public double SubTotal { get; set; }
        [Range(0, 2)]
        public int TaxType { get; set; }
        public double TaxDefault { get; set; }
        public double TaxProsen { get; set; }
        public double Tax { get; set; }
        [Range(0, 100)]
        public double DiscProsen { get; set; }
        public double Disc { get; set; }
        public double Total { get; set; }
        [StringLength(255)]
        public string Note { get; set; }

        public virtual TWarehouse Warehouse { get; set; }
        public virtual TContact Vendor { get; set; }
        public virtual ICollection<TPurchaseDtl> PurchaseDtls { get; set; }
    }
}
