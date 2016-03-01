using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Unit
    {
        public Unit()
        {
            Orders = new List<Order>();
            ProductsStock = new List<Product>();
            ProductsServe = new List<Product>();
        }
        public int UnitId { get; set; }

        [StringLength(255, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [StringLength(128, MinimumLength = 1)]
        public string ShortName { get; set; }
        public string Description { get; set; }

        [Required]
        public double BasisFactor { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        //foreign keys
        [Required]
        public string CreatedById { get; set; }

        //navigation properties    
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Product> ProductsStock { get; set; }
        public virtual ICollection<Product> ProductsServe { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}