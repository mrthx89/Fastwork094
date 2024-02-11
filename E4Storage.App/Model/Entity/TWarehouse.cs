using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model.Entity
{
    [Table("TWarehouse")]
    public partial class TWarehouse : BaseTable
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<TStockIn> StockIns { get; set; }
        public virtual ICollection<TStockOut> StockOuts { get; set; }
        public virtual ICollection<TStockCard> StockCards { get; set; }
        public virtual ICollection<TStockPengembalian> StockPengembalians { get; set; }
        public virtual ICollection<TStockMasterData> StockMasterDatas { get; set; }
        public virtual ICollection<TPurchase> Purchases { get; set; }
        public virtual ICollection<TDO> DOs { get; set; }
    }
}
