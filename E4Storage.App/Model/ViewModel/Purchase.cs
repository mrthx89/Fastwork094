using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model.ViewModel
{
    public class Purchase : Entity.BaseTable
    {
        public Purchase()
        {
            this.ID = Guid.NewGuid();
            this.PurchaseDtl = new List<PurchaseDtl>();
        }

        [Required]
        public Guid ID { get; set; }
        [StringLength(20)]
        public string DocNo { get; set; }
        [Required]
        public DateTime DocDate { get; set; }
        public string NoReff { get; set; }
        [Required]
        public Guid IDWarehouse { get; set; }
        [Required]
        public Guid IDVendor { get; set; }
        public double SubTotal
        {
            get
            {
                return Math.Round(PurchaseDtl != null ? PurchaseDtl.Sum(o => o.Amount) : 0d, 2);
            }
        }
        [Range(0, 2)]
        public int TaxType { get; set; }
        public double TaxDefault
        {
            get
            {
                return Math.Round(TaxType == 1 ? (SubTotal - Disc) / (1d + (TaxProsen / 100d)) : (SubTotal - Disc), 2);
            }
        }
        public double TaxProsen { get; set; }
        private double _Tax = 0.0;
        public double Tax
        {
            get
            {
                return Math.Round(TaxType == 0 ? 0d : TaxType == 1 ? (SubTotal - Disc) - TaxDefault : TaxDefault * (TaxProsen / 100d), 2);
            }
        }
        [Range(0, 100)]
        public double DiscProsen { get; set; }
        public double Disc
        {
            get
            {
                return Math.Round(SubTotal * (DiscProsen / 100d), 2);
            }
        }
        public double Total
        {
            get
            {
                return Math.Round((SubTotal - Disc) + (TaxType == 2 ? Tax : 0d), 2);
            }
        }
        [StringLength(255)]
        public string Note { get; set; }
        public bool Void { get; set; }

        public List<PurchaseDtl> PurchaseDtl { get; set; }
    }

    public class PurchaseDtl : Entity.BaseTable
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public Guid IDPurchase { get; set; }
        public int NoUrut { get; set; }
        [Required]
        public Guid IDInventor { get; set; }
        public string Desc { get; set; }
        [Required]
        public Guid IDUOM { get; set; }
        [Required]
        [Range(0, 999999999)]
        public double Qty { get; set; }
        [Required]
        [Range(0, 999999999)]
        public double UnitPrice { get; set; }
        [Range(0, 100)]
        public double DiscProsen { get; set; }
        public double Disc
        {
            get
            {
                return Math.Round((Qty * UnitPrice) * (DiscProsen / 100d), 2);
            }
        }
        public double TaxDefault { get; set; }
        public double TaxProsen { get; set; }
        public double Tax { get; set; }
        public double Amount { get { return Math.Round((Qty * UnitPrice) - Disc, 2); } }
        [Range(0, 100)]
        public double Disc1Prosen { get; set; }
        public double Disc1 { get; set; }
        [StringLength(255)]
        public string Note { get; set; }
    }
}
