using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class ProductState
    {
        public ProductState()
        {
            Products = new List<Product>();
        }
        public int ProductStateId { get; set; }

        [Required]
        [StringLength(128, MinimumLength =1)]
        public string Title { get; set; }

        [StringLength(512, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        //foreign keys
        [Required]
        public string CreatedById { get; set; }

        //navigation properties
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}