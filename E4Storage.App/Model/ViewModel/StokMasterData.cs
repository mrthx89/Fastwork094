﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Model.ViewModel
{
    public class StokMasterData : Entity.BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public DateTime Tanggal { get; set; }
        [StringLength(30)]
        public string DocNo { get; set; }
        [Required]
        public Guid IDInventor { get; set; }
        [Required]
        public Guid IDWarehouse { get; set; }
        [Required]
        public Guid IDUOM { get; set; }
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Qty yang diinputkan salah")]
        public float Qty { get; set; }
        public Guid? IDBelt { get; set; }
        [Required]
        [StringLength(150)]
        public string PIC { get; set; }
        [StringLength(255)]
        public string Keterangan { get; set; }
        public Guid? IDCategory { get; set; }
        [Range(0, int.MaxValue)]
        public int? Cabinet { get; set; }
        [StringLength(255)]
        public string Row { get; set; }
        public float Saldo { get; set; }

        public string NamaBarang { get; set; }
    }
}
