using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class OrderState
    {
        public int OrderStateId { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(512, MinimumLength = 1)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        //foreign keys
        public string CreatedById { get; set; }

        //navigation properties
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        
    }
}