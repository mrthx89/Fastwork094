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
    [Table("TDO")]
    public class TDO : BaseTable
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

        public virtual TWarehouse Warehouse { get; set; }
        public virtual TContact Customer { get; set; }
        public virtual ICollection<TDODtl> DODtls { get; set; }
    }
}
