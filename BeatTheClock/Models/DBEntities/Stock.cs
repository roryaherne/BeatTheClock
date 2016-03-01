using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Stock
    {
        public int StockId { get; set; }

        [Required]
        public int Amount { get; set; }

        public DateTime Expires { get; set; }
        public DateTime Delivered { get; set; }

        [Required]
        public float PurchPrice { get; set; }

        //foreign keys
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string CreatedById { get; set; }

        //navigation properties
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }
    }
}