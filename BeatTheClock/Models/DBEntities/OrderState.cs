using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class OrderState
    {
        public OrderState()
        {
            Orders = new List<Order>();
        }

        public int OrderStateId { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(512, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        //foreign keys
        [Required]
        [StringLength(128)]
        public string CreatedById { get; set; }

        //navigation properties
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Order> Orders { get; set; }        
    }
}