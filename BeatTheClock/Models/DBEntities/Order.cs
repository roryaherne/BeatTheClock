using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        //foreign keys
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UnitId { get; set; }
        [Required]
        public string OrderedById { get; set; }

        [Required]
        public int PlaceId { get; set; }

        [Required]
        public int OrderStateId { get; set; }

        //navigation properties
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        [ForeignKey("OrderedById")]
        public virtual ApplicationUser OrderedBy { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
        [ForeignKey("OrderStateId")]
        public virtual OrderState OrderState { get; set; }
    }
}