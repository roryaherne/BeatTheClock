using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Unit
    {
        public int UnitId { get; set; }

        [StringLength(255, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [StringLength(128, MinimumLength = 1)]
        public string ShortName { get; set; }
        public string Description { get; set; }
        public double BasisFactor { get; set; }
        public DateTime DateCreated { get; set; }

        //foreign keys
        public string CreatedById { get; set; }

        //navigation properties        
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}