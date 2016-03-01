using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Product
    {
        public Product()
        {
            Stocks = new List<Stock>();
            ServingUnits = new List<Unit>();
            Orders = new List<Order>();
        }
        public int ProductId { get; set; }

        [StringLength(128, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [StringLength(512, MinimumLength = 1)]
        public string Description { get; set; }

        public int ExperationPeriod { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        //foreign keys
        [Required]
        public int StockUnitId { get; set; }

        [Required]
        public string CreatedById { get; set; }

        [Required]
        public int ProductStateId { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        //navigation properties

        [ForeignKey("StockUnitId")]
        public virtual Unit StockUnit { get; set; }

        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }

        [ForeignKey("ProductStateId")]
        public virtual ProductState ProductState { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Unit> ServingUnits { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}