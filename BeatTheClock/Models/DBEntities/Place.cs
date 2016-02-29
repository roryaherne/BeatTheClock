using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Place
    {
        public int PlaceId { get; set; }

        [StringLength(255, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }

        [Display(Name = "Seats")]
        public int Capacity { get; set; }

        //foreign keys
        public string CreatedById { get; set; }

        //navigation properties
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}