using Inventory.App.Model.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model.ViewModel
{
    public class DO : BaseTable
    {
        public DO() {
            this.ID = Guid.NewGuid();
            this.DODtl = new List<DODtl>();
        }
        public Guid ID { get; set; }
        [StringLength(20)]
        public string DocNo { get; set; }
        [Required]
        public DateTime DocDate { get; set; }
        public string NoReff { get; set; }
        [Required]
        public Guid IDWarehouse { get; set; }
        [Required]
        public Guid IDCustomer { get; set; }
        [StringLength(255)]
        public string SealNo { get; set; }
        [StringLength(255)]
        public string ContainerNo { get; set; }
        [StringLength(255)]
        public string ConditionDelivery { get; set; }
        [StringLength(255)]
        public string Plant { get; set; }
        [StringLength(255)]
        public string VehicleNo { get; set; }
        [StringLength(255)]
        public string SalesOrderNo { get; set; }
        [StringLength(255)]
        public string Note { get; set; }
        public bool Void { get; set; }
        public bool Finish { get; set; }

        public List<DODtl> DODtl { get; set; }
    }

    public class DODtl : BaseTable
    {
        public Guid ID { get; set; }
        public Guid IDDO { get; set; }
        public int NoUrut { get; set; }
        [Required]
        public Guid IDInventor { get; set; }
        public string Desc { get; set; }
        [Required]
        public Guid IDUOM { get; set; }
        [Required]
        [Range(0, 999999999)]
        public double Qty { get; set; }
        [Range(0, 999999999)]
        public double QtyVoid { get; set; }
        [StringLength(255)]
        public string Note { get; set; }
        public bool Finish { get; set; }
    }
}
