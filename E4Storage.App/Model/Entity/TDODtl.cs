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
    [Table("TDODtl")]
    public class TDODtl : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid IDDO { get; set; }
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
        [StringLength(255)]
        public string Note { get; set; }
        public bool Finish { get; set; }

        public virtual TDO DO { get; set; }
        public virtual TUOM UOM { get; set; }
        public virtual TInventor Inventor { get; set; }
    }
}
