using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model.Entity
{
    [Table("TContact")]
    public partial class TContact : BaseTable
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

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Cell { get; set; }

        [StringLength(50)]
        public string ContactPerson { get; set; }

        public bool Active { get; set; }

        public bool Vendor { get; set; }

        public bool Customer { get; set; }

        [StringLength(50)]
        public string NPWP { get; set; }

        public virtual ICollection<TPurchase> Purchases { get; set; }
        public virtual ICollection<TDO> DOs { get; set; }
    }
}
