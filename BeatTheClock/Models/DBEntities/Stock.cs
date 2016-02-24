using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Stock
    {
        public int StockId { get; set; }
        public float Amount { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Delivered { get; set; }
        public float PPrice { get; set; }

        //foreign keys
        public int ProductId { get; set; }
        public string CreatedById { get; set; }

        //navigation properties
        public virtual Product Product { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}