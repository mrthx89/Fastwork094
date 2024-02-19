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
    [Table("TIV")]
    public class TIV : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(20)]
        public string DocNo { get; set; }
        [Required]
        public DateTime DocDate { get; set; }
        public string NoReff { get; set; }
        public string NoFakturPajak { get; set; }
        [Range(0, 2)]
        public int TaxType { get; set; }
        public double TaxDefault { get; set; }
        public double TaxProsen { get; set; }
        public double Tax { get; set; }
        [Required]
        public Guid IDCustomer { get; set; }
        [StringLength(255)]
        public string SalesOrderNo { get; set; }
        [Range(0, 2)]
        public int Due { get; set; }
        public DateTime DueDate { get; set; }
        [StringLength(255)]
        public string Note { get; set; }
        public bool Void { get; set; }
        public bool Finish { get; set; }

        public virtual TContact Customer { get; set; }
        public virtual ICollection<TIVDtl> IVDtls { get; set; }
    }
}
