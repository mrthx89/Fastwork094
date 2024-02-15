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
    [Table("TPurchaseDtl")]
    public class TPurchaseDtl : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid IDPurchase { get; set; }
        public int NoUrut { get; set; }
        [Required]
        public Guid IDInventor { get; set; }
        [Required]
        public Guid IDUOM { get; set; }
        [Required]
        [Range(0, 999999999)]
        public double Qty { get; set; }
        [Range(0, 999999999)]
        public double QtyVoid { get; set; }
        [Required]
        [Range(0, 999999999)]
        public double UnitPrice { get; set; }
        [Range(0, 100)]
        public double DiscProsen { get; set; }
        public double Disc { get; set; }
        public double TaxDefault { get; set; }
        public double TaxProsen { get; set; }
        public double Tax { get; set; }
        public double Amount { get; set; }
        public double AmountVoid { get; set; }
        [Range(0, 100)]
        public double Disc1Prosen { get; set; }
        public double Disc1 { get; set; }
        [StringLength(255)]
        public string Note { get; set; }

        public virtual TPurchase Purchase { get; set; }
        public virtual TUOM UOM { get; set; }
        public virtual TInventor Inventor { get; set; }
    }
}
