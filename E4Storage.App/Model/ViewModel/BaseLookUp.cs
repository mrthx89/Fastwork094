using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model.ViewModel
{
    public class BaseLookUp
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
